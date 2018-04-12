using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LibAtem.XmlState.GenerateMacroOperation
{
    public class GenerateMacroOperation
    {
        private static ExpressionSyntax ConvertVariable(ExpressionSyntax expr, string fromType, string toType)
        {
            if (toType == fromType)
                return expr;
            
            if (fromType == "LibAtem.Common.VideoSource" && toType == "LibAtem.XmlState.MacroInput")
                return SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, expr, SyntaxFactory.IdentifierName("ToMacroInput()"));
            if (fromType == "LibAtem.XmlState.MacroInput" && toType == "LibAtem.Common.VideoSource")
                return SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, expr, SyntaxFactory.IdentifierName("ToVideoSource()"));

            if (fromType == "LibAtem.Common.AudioSource" && toType == "LibAtem.XmlState.MacroInput")
                return SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, expr, SyntaxFactory.IdentifierName("ToMacroInput()"));
            if (fromType == "LibAtem.XmlState.MacroInput" && toType == "LibAtem.Common.AudioSource")
                return SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, expr, SyntaxFactory.IdentifierName("ToAudioSource()"));

            if (fromType == "System.Boolean" && toType == "LibAtem.XmlState.AtemBool")
                return SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, expr, SyntaxFactory.IdentifierName("ToAtemBool()"));
            if (fromType == "LibAtem.XmlState.AtemBool" && toType == "System.Boolean")
                return SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, expr, SyntaxFactory.IdentifierName("Value()"));

//            if (fromType == "System.UInt32" && toType == "LibAtem.Common.DownstreamKeyId")
//                return CastExpression(ParseTypeName("LibAtem.Common.DownstreamKeyId"), expr);
//            if (fromType == "LibAtem.Common.DownstreamKeyId" && toType == "System.UInt32")
//                return CastExpression(ParseTypeName("System.UInt32"), expr);

            return expr;
        }
        
        private static Tuple<List<Operation>, List<Field>> FakeSpec()
        {
            var operations = new List<Operation>();
            var fields = new List<Field>();

            IReadOnlyDictionary<MacroOperationType, Type> types = MacroOpManager.FindAll();
            foreach (var t in types)
            {
                MacroOperationType id = t.Key;
                Type type = t.Value;
                
                IEnumerable<PropertyInfo> props = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Where(prop => prop.GetCustomAttribute<NoSerializeAttribute>() == null);

                var opFields = new List<OperationField>();
                foreach (PropertyInfo prop in props)
                {
                    var fieldAttr = prop.GetCustomAttribute<MacroFieldAttribute>();
                    if (fieldAttr == null)
                        continue;


                    Tuple<string, bool> mappedType = TypeMappings.MapTypeFull(prop.PropertyType);
                    fields.Add(new Field(fieldAttr.Id, fieldAttr.Name, mappedType.Item1, mappedType.Item2, prop.PropertyType.GetCustomAttributes<FlagsAttribute>().Any() || prop.PropertyType.GetCustomAttributes<XmlAsStringAttribute>().Any()));

                    opFields.Add(new OperationField(fieldAttr.Id, fieldAttr.Name, prop.Name, prop.PropertyType.ToString()));
                }

                operations.Add(new Operation(id.ToString(), type.FullName, opFields, type.GetCustomAttributes<NoMacroFieldsAttribute>().Any()));
            }

            fields = fields.Distinct().OrderBy(f => f.Id).ToList();
            operations = operations.OrderBy(o => o.Id).ToList();

            var res = new List<Field>();
            foreach (IGrouping<string, Field> grp in fields.GroupBy(f => f.Id))
            {
                FieldEntry[] newTypes = grp.SelectMany(g => g.Entries).ToArray();
                Field f = grp.First();
                res.Add(new Field(f.Id, newTypes, f.EnumAsString, f.IsEnum));
            }

            return Tuple.Create(operations, res);
        }

        public static void Main(string[] args)
        {
            Tuple<List<Operation>, List<Field>> spec = FakeSpec();

            if (spec.Item1.Select(o => o.Id).Distinct().Count() != spec.Item1.Count)
                throw new Exception("Found duplicated Operation Ids");

            if (spec.Item1.Any(o => !o.AllowNoFields && o.Fields.Count == 0))
                throw new Exception("Found some Operation with no fields");

            Console.WriteLine(string.Format("Loaded spec with {0} Fields and {1} Operations", spec.Item2.Count, spec.Item1.Count));

            string code = GenerateClass(spec.Item1, spec.Item2);

            // Save to file
            File.WriteAllText("../LibAtem.XmlState/MacroOperation.cs", code);

            // Output new code to the console
            Console.WriteLine(code);

            // Wait to exit
            // Console.Read();
        }

        private static string GetGetter(Field field, string stringPropName, FieldEntry ent)
        {
            if (!field.IsEnum)
                return string.Format("{1}.Parse({0});", stringPropName, ent.Type);

            if (field.EnumAsString)
                return string.Format("({1})Enum.Parse(typeof({1}), {0});", stringPropName, ent.Type);

            return string.Format("({1}){0};", stringPropName, ent.Type);
        }

        private static string GetSetter(Field field, string stringPropName)
        {
            if (!field.IsEnum || field.EnumAsString)
                return string.Format("{0} = value.ToString();", stringPropName);

            return string.Format("{0} = (int)value;", stringPropName);
        }

        private static IEnumerable<MemberDeclarationSyntax> GenerateField(Field field, IReadOnlyList<Operation> operations)
        {
            List<string> opNames = operations.Where(o => o.Fields.Any(f => f.Id == field.Id)).Select(o => o.Id).OrderBy(n => n).ToList();
            if (opNames.Count == 0)
                throw new Exception("Found Field with no usages: " + field.Entries);

            if (field.Entries.Count > 1)
            {
                string stringPropName = field.Id.First().ToString().ToUpper() + field.Id.Substring(1) + (!field.IsEnum || field.EnumAsString ? "String" : "Int");

                yield return CreateAutoProperty(stringPropName, !field.IsEnum || field.EnumAsString ? "string" : "int", CreateAttribute(field.Id));
                yield return CreateCanSerializeAt(stringPropName, opNames);

                foreach (FieldEntry ent in field.Entries)
                {
                    string getStr = GetGetter(field, stringPropName, ent);
                    string setStr = GetSetter(field, stringPropName);

                    yield return CreateProperty(ent.Name, ent.Type, CreateIgnoreAttribute())
                        .AddAccessorListAccessors(CreateArrowExpression(SyntaxKind.GetAccessorDeclaration, getStr))
                        .AddAccessorListAccessors(CreateArrowExpression(SyntaxKind.SetAccessorDeclaration, setStr));
                }

                yield break;
            }

            FieldEntry entry = field.Entries.First();
            if (field.EnumAsString)
            {
                yield return CreateAutoProperty(entry.Name, entry.Type, CreateIgnoreAttribute());

                string getStr = string.Format("{0}.ToString();", entry.Name);
                string setStr = string.Format("{0} = ({1})Enum.Parse(typeof({1}), value);", entry.Name, entry.Type);

                yield return CreateProperty(entry.Name + "String", "string", CreateAttribute(field.Id))
                    .AddAccessorListAccessors(CreateArrowExpression(SyntaxKind.GetAccessorDeclaration, getStr))
                    .AddAccessorListAccessors(CreateArrowExpression(SyntaxKind.SetAccessorDeclaration, setStr));

                yield return CreateCanSerializeAt(entry.Name + "String", opNames);

                yield break;
            }

            yield return CreateAutoProperty(entry.Name, entry.Type, CreateAttribute(field.Id));

            yield return CreateCanSerializeAt(entry.Name, opNames);
        }

        private static AccessorDeclarationSyntax CreateArrowExpression(SyntaxKind kind, string expression)
        {
            return SyntaxFactory.AccessorDeclaration(kind, SyntaxFactory.List<AttributeListSyntax>(), SyntaxFactory.TokenList(), SyntaxFactory.ArrowExpressionClause(SyntaxFactory.ParseExpression(expression)));
        }

        private static MethodDeclarationSyntax CreateCanSerializeAt(string name, IReadOnlyList<string> opNames)
        {
            IEnumerable<SwitchLabelSyntax> labels = opNames.Select(o => SyntaxFactory.CaseSwitchLabel(SyntaxFactory.ParseExpression("MacroOperationType." + o)));
            var switchTrue = SyntaxFactory.SwitchSection(SyntaxFactory.List(labels), SyntaxFactory.List(new StatementSyntax[] { SyntaxFactory.ReturnStatement(SyntaxFactory.ParseExpression("true"))}));

            var switchFalse = SyntaxFactory.SwitchSection(SyntaxFactory.List(new SwitchLabelSyntax[] { SyntaxFactory.DefaultSwitchLabel()}), SyntaxFactory.List(new StatementSyntax[] { SyntaxFactory.ReturnStatement(SyntaxFactory.ParseExpression("false"))}));

            var switchStmt = SyntaxFactory.SwitchStatement(SyntaxFactory.ParseExpression("Id"));
            switchStmt = switchStmt.AddSections(switchTrue, switchFalse);

            return SyntaxFactory.MethodDeclaration(SyntaxFactory.ParseTypeName("bool"), "ShouldSerialize" + name)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddBodyStatements(switchStmt);
        }

        private static PropertyDeclarationSyntax CreateProperty(string name, string type, AttributeListSyntax attribute)
        {
            return SyntaxFactory.PropertyDeclaration(SyntaxFactory.ParseTypeName(type), name)
                .AddAttributeLists(attribute)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword));
        }

        private static PropertyDeclarationSyntax CreateAutoProperty(string name, string type, AttributeListSyntax attribute)
        {
            return CreateProperty(name, type, attribute)
                .AddAccessorListAccessors(
                    SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
                    SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)));
        }

        private static AttributeListSyntax CreateAttribute(string fieldName)
        {
            AttributeArgumentSyntax arg = SyntaxFactory.AttributeArgument(SyntaxFactory.ParseExpression("\"" + fieldName + "\""));
            AttributeSyntax attr = SyntaxFactory.Attribute(SyntaxFactory.ParseName("XmlAttribute")).AddArgumentListArguments(arg);
            return SyntaxFactory.AttributeList(SyntaxFactory.SeparatedList(new[] {attr}));
        }

        private static AttributeListSyntax CreateIgnoreAttribute()
        {
            AttributeSyntax attr = SyntaxFactory.Attribute(SyntaxFactory.ParseName("XmlIgnore"));
            return SyntaxFactory.AttributeList(SyntaxFactory.SeparatedList(new[] {attr}));
        }

        private static string GenerateClass(List<Operation> operations, List<Field> fields)
        {
            // Create CompilationUnitSyntax
            var newFile = SyntaxFactory.CompilationUnit();

            // Add using statements
            var namespaces = new[]
            {
                "System",
                "System.Xml.Serialization",
                "LibAtem.Common",
                "LibAtem.MacroOperations",
            };
            newFile = newFile.AddUsings(namespaces.Select(n => SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(n))).ToArray());

            // Create Id Property
            var idProp = CreateAutoProperty("Id", "MacroOperationType", CreateAttribute("id"));
            
            // Create class
            var newClass = SyntaxFactory.ClassDeclaration("MacroOperation").AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword));

            newClass = newClass.AddMembers(idProp)
                .AddMembers(fields.SelectMany(f => GenerateField(f, operations)).ToArray());
            
            var opExtClass = SyntaxFactory.ClassDeclaration("MacroOpExtensions")
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.StaticKeyword));
            opExtClass = opExtClass.AddMembers(GenerateMacroOpToXml(operations));

            var operationsExtClass = SyntaxFactory.ClassDeclaration("MacroOperationsExtensions")
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.StaticKeyword));
            operationsExtClass = operationsExtClass.AddMembers(GenerateXmlToMacroOp(operations));

            // Create namespace
            var newNamespace = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName("LibAtem.XmlState"))
                .AddMembers(newClass, opExtClass, operationsExtClass);

            // Add the namespace to the file
            newFile = newFile.AddMembers(newNamespace);

            // Normalize and get code as string
            return newFile
                .NormalizeWhitespace()
                .ToFullString();
        }

        private static MemberDeclarationSyntax GenerateMacroOpToXml(IReadOnlyList<Operation> operations)
        {
            var switchStmt = SyntaxFactory.SwitchStatement(SyntaxFactory.MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                SyntaxFactory.IdentifierName("op"),
                SyntaxFactory.IdentifierName("GetType().FullName")));

            foreach (Operation op in operations)
            {
                var label = SyntaxFactory.CaseSwitchLabel(SyntaxFactory.ParseExpression("\"" + op.Classname + "\""));
                var opCase = SyntaxFactory.SwitchSection(SyntaxFactory.List(new SwitchLabelSyntax[] { label }), SyntaxFactory.List(GenerateMacroOpToXml(op).ToArray()));
                switchStmt = switchStmt.AddSections(opCase);
            }

            var throwStmt = SyntaxFactory.ThrowStatement(SyntaxFactory.ParseExpression("new Exception(string.Format(\"Unknown type: {0}\", op.Id))"));
            var defaultCase = SyntaxFactory.SwitchSection(SyntaxFactory.List(new SwitchLabelSyntax[] {SyntaxFactory.DefaultSwitchLabel()}), SyntaxFactory.List(new StatementSyntax[] {throwStmt}));
            switchStmt = switchStmt.AddSections(defaultCase);

            return SyntaxFactory.MethodDeclaration(SyntaxFactory.ParseTypeName("MacroOperation"), "ToMacroOperation")
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.StaticKeyword))
                .AddParameterListParameters(SyntaxFactory.Parameter(SyntaxFactory.Identifier("op")).AddModifiers(SyntaxFactory.Token(SyntaxKind.ThisKeyword)).WithType(SyntaxFactory.IdentifierName("MacroOpBase")))
                .AddBodyStatements(switchStmt);
        }

        private static IEnumerable<StatementSyntax> GenerateMacroOpToXml(Operation op)
        {
            string[] nameParts = op.Classname.Split(".");
            string id = nameParts[nameParts.Count() - 1];

            var props = SyntaxFactory.SeparatedList<ExpressionSyntax>()
                .Add(SyntaxFactory.AssignmentExpression(
                    SyntaxKind.SimpleAssignmentExpression,
                    SyntaxFactory.IdentifierName("Id"),
                    SyntaxFactory.IdentifierName("MacroOperationType." + op.Id)));

            foreach (OperationField f in op.Fields)
            {
                var expr = SyntaxFactory.AssignmentExpression(
                    SyntaxKind.SimpleAssignmentExpression,
                    SyntaxFactory.IdentifierName(f.FieldName),
                    ConvertVariable(SyntaxFactory.MemberAccessExpression(
                            SyntaxKind.SimpleMemberAccessExpression,
                            SyntaxFactory.IdentifierName("op" + id),
                            SyntaxFactory.IdentifierName(f.PropName)),
                        f.Type, TypeMappings.MapType(f.Type)));
                
                props = props.Add(expr);
            }

            yield return SyntaxFactory.LocalDeclarationStatement(SyntaxFactory.VariableDeclaration(SyntaxFactory.IdentifierName("var"))
                .WithVariables(SyntaxFactory.SingletonSeparatedList(SyntaxFactory.VariableDeclarator(SyntaxFactory.Identifier("op" + id))
                    .WithInitializer(SyntaxFactory.EqualsValueClause(SyntaxFactory.CastExpression(SyntaxFactory.IdentifierName(op.Classname), SyntaxFactory.IdentifierName("op")))))));

            yield return SyntaxFactory.ReturnStatement(SyntaxFactory.ObjectCreationExpression(SyntaxFactory.IdentifierName("MacroOperation"))
                .WithNewKeyword(SyntaxFactory.Token(SyntaxKind.NewKeyword)).WithInitializer(SyntaxFactory.InitializerExpression(SyntaxKind.ObjectInitializerExpression, props)));
        }

        private static MemberDeclarationSyntax GenerateXmlToMacroOp(IReadOnlyList<Operation> operations)
        {
            var switchStmt = SyntaxFactory.SwitchStatement(SyntaxFactory.MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                SyntaxFactory.IdentifierName("mac"),
                SyntaxFactory.IdentifierName("Id")));

            foreach (Operation op in operations)
            {
                var label = SyntaxFactory.CaseSwitchLabel(SyntaxFactory.ParseExpression("MacroOperationType." + op.Id));
                var opCase = SyntaxFactory.SwitchSection(SyntaxFactory.List(new SwitchLabelSyntax[] {label}), SyntaxFactory.List(new StatementSyntax[] {GenerateXmlToMacroOp(op)}));
                switchStmt = switchStmt.AddSections(opCase);
            }

            var throwStmt = SyntaxFactory.ThrowStatement(SyntaxFactory.ParseExpression("new Exception(string.Format(\"Unknown type: {0}\", mac.Id))"));
            var defaultCase = SyntaxFactory.SwitchSection(SyntaxFactory.List(new SwitchLabelSyntax[] {SyntaxFactory.DefaultSwitchLabel()}), SyntaxFactory.List(new StatementSyntax[] {throwStmt}));
            switchStmt = switchStmt.AddSections(defaultCase);
            
            return SyntaxFactory.MethodDeclaration(SyntaxFactory.ParseTypeName("MacroOpBase"), "ToMacroOp")
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.StaticKeyword))
                .AddParameterListParameters(SyntaxFactory.Parameter(SyntaxFactory.Identifier("mac")).AddModifiers(SyntaxFactory.Token(SyntaxKind.ThisKeyword)).WithType(SyntaxFactory.IdentifierName("MacroOperation")))
                .AddBodyStatements(switchStmt);
        }

        private static ReturnStatementSyntax GenerateXmlToMacroOp(Operation op)
        {
            var props = SyntaxFactory.SeparatedList<ExpressionSyntax>();

            foreach (OperationField f in op.Fields)
            {
                var expr = SyntaxFactory.AssignmentExpression(
                    SyntaxKind.SimpleAssignmentExpression,
                    SyntaxFactory.IdentifierName(f.PropName),
                    ConvertVariable(SyntaxFactory.MemberAccessExpression(
                        SyntaxKind.SimpleMemberAccessExpression,
                        SyntaxFactory.IdentifierName("mac"),
                        SyntaxFactory.IdentifierName(f.FieldName)),
                        TypeMappings.MapType(f.Type), f.Type));

                props = props.Add(expr);
            }

            var inst = SyntaxFactory.ObjectCreationExpression(SyntaxFactory.IdentifierName(op.Classname))
                .WithNewKeyword(SyntaxFactory.Token(SyntaxKind.NewKeyword)).WithInitializer(SyntaxFactory.InitializerExpression(SyntaxKind.ObjectInitializerExpression, props));

            return SyntaxFactory.ReturnStatement(inst);
        }

    }
}