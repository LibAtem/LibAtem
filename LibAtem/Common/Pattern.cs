
namespace LibAtem.Common
{
    [XmlAsString]
    public enum Pattern
    {
        LeftToRightBar = 0,
        TopToBottomBar = 1,
        HorizontalBarnDoor = 2,
        VerticalBarnDoor = 3,
        CornersInFourBox = 4,
        RectangleIris = 5,
        DiamondIris = 6,
        CircleIris = 7,
        TopLeftBox = 8,
        TopRightBox = 9,
        BottomRightBox = 10,
        BottomLeftBox = 11,
        TopCentreBox = 12,
        RightCentreBox = 13,
        BottomCentreBox = 14,
        LeftCentreBox = 15,
        TopLeftDiagonal = 16,
        TopRightDiagonal = 17,
    }

    [XmlAsString]
    public enum BorderBevel
    {
        None = 0,
        InOut = 1,
        In = 2,
        Out = 3,
    }
}
