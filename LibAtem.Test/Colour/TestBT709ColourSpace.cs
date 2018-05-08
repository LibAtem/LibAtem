using System;
using LibAtem.Util.Media;
using Xunit;

namespace LibAtem.Test.Colour
{
    public class TestBT709ColourSpaceConverter
    {
        private void RunTest(byte r, byte g, byte b)
        {
            (int y10, int cb10, int cr10) = BT709ColourSpaceConverter.ToYCbCr10(r, g, b);
            (byte r2, byte g2, byte b2) = BT709ColourSpaceConverter.ToRGB8(y10, cb10, cr10);

            AssertEqual(r, r2);
            AssertEqual(g, g2);
            AssertEqual(b, b2);
        }

        [Fact]
        public void TestToAndFromYCbCr()
        {
            RunTest(255, 255, 255);
            RunTest(12, 235, 45);
            RunTest(195, 211, 95);
            RunTest(87, 133, 73);
        }

        [Fact]
        public void TestFFFF00WithYCbCr()
        {
            const byte r = 255;
            const byte g = 255;
            const byte b = 0;

            const int y = 0x36c;
            const int cb = 0x3e;
            const int cr = 0x228;

            (int y10, int cb10, int cr10) = BT709ColourSpaceConverter.ToYCbCr10(r, g, b);

            AssertEqual(y, y10, 10);
            AssertEqual(cb, cb10, 10);
            AssertEqual(cr, cr10, 10);

            (byte r2, byte g2, byte b2) = BT709ColourSpaceConverter.ToRGB8(y10, cb10, cr10);

            AssertEqual(r, r2);
            AssertEqual(g, g2);
            AssertEqual(b, b2);
        }

        private static void AssertEqual(int e, int a, int tol = 1)
        {
            Assert.True(Math.Abs(e - a) <= tol);
        }
    }
}
