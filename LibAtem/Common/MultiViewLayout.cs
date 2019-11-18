namespace LibAtem.Common
{
    public enum MultiViewLayout
    {
        ProgramTop = 0,
        ProgramBottom = 1,
        ProgramLeft = 2,
        ProgramRight = 3,
    }

    public enum MultiViewLayoutV8
    {
        Default = 0,
        TopLeftSmall = 1,
        TopRightSmall = 2,
        ProgramBottom = TopLeftSmall | TopRightSmall,
        BottomLeftSmall = 4,
        ProgramRight = TopLeftSmall | BottomLeftSmall,
        BottomRightSmall = 8,
        ProgramLeft = TopRightSmall | BottomRightSmall,
        ProgramTop = BottomLeftSmall | BottomRightSmall
    }
}