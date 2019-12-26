using LibAtem.Serialization;
using System;
using System.Collections.Generic;

namespace LibAtem.State.Tolerance
{
    public class ToleranceAttribute : Attribute, IEqualityComparer<double>
    {
        public double Tolerance { get; }

        public ToleranceAttribute(double tolerance)
        {
            Tolerance = tolerance;
        }

        public virtual bool AreEqual(double a, double b)
        {
            return Math.Abs(a - b) <= Tolerance;
        }

        public bool Equals(double x, double y)
        {
            return AreEqual(x, y);
        }

        public int GetHashCode(double obj)
        {
            return obj.GetHashCode();
        }
    }
    public class UintToleranceAttribute : Attribute
    {
        public uint Tolerance { get; }

        public UintToleranceAttribute(uint tolerance)
        {
            Tolerance = tolerance;
        }

        public virtual bool AreEqual(uint a, uint b)
        {
            uint c = Math.Min(a, b);
            uint d = Math.Max(a, b);
            return d - c <= Tolerance;
        }
    }

    public sealed class DecibelToleranceAttribute : ToleranceAttribute
    {
        public DecibelToleranceAttribute(double tolerance) : base(tolerance)
        {
        }

        public override bool AreEqual(double a, double b)
        {
            var a2 = (double)DecibelsAttribute.DecibelToUInt(a);
            var b2 = (double)DecibelsAttribute.DecibelToUInt(b);

            return Math.Abs(a2 - b2) <= Tolerance;
        }
    }

}
