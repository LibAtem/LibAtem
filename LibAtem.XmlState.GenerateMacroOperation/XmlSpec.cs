using System;
using System.Collections.Generic;
using System.Linq;

namespace LibAtem.XmlState.GenerateMacroOperation
{
    public class FieldEntry : IEquatable<FieldEntry>
    {
        public FieldEntry(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; }
        public string Type { get; }

        public bool Equals(FieldEntry other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Name, other.Name) && string.Equals(Type, other.Type);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((FieldEntry) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ (Type != null ? Type.GetHashCode() : 0);
            }
        }
    }

    public class Field : IEquatable<Field>
    {
        public Field(string id, string name, string type, bool isEnum, bool enumAsString) :
            this(id, new List<FieldEntry> { new FieldEntry(name, type)}, enumAsString, isEnum)
        {
        }
        
        public Field(string id, IReadOnlyList<FieldEntry> entries, bool enumAsString, bool isEnum)
        {
            Id = id;
            Entries = entries;
            IsEnum = isEnum;
            EnumAsString = enumAsString;
        }

        public string Id { get; }
        public bool IsEnum { get; }
        public IReadOnlyList<FieldEntry> Entries { get; }
        public bool EnumAsString { get; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Id, string.Join(", ", Entries.Select(e => e.Name + "-" + e.Type)));
        }

        public bool Equals(Field other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Id, other.Id) && IsEnum == other.IsEnum && Entries.SequenceEqual(other.Entries) && EnumAsString == other.EnumAsString;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Field) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Id != null ? Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ IsEnum.GetHashCode();
                hashCode = (hashCode * 397) ^ Entries.Sum(e => e.GetHashCode());
                hashCode = (hashCode * 397) ^ EnumAsString.GetHashCode();
                return hashCode;
            }
        }
    }
    
    public class Operation
    {
        public Operation(string id, string classname, IEnumerable<OperationField> fields, bool allowNoFields)
        {
            Id = id;
            Classname = classname;
            Fields = fields.ToList();
            AllowNoFields = allowNoFields;
        }

        public string Id { get; }
        public string Classname { get; }
        public IReadOnlyList<OperationField> Fields { get; }
        public bool AllowNoFields { get; }
    }

    public class OperationField
    {
        public string Id { get; }
        public string FieldName { get; }
        public string PropName { get; }
        public string Type { get; }

        public OperationField(string id, string fieldName, string propName, string type)
        {
            Id = id;
            FieldName = fieldName;
            PropName = propName;
            Type = type;
        }
        
    }
}
