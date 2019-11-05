using System.ComponentModel;

namespace CentersFrontier.Production.Drawings
{
    /// <summary>
    /// 零件类别
    /// </summary>
    public enum PartSort
    {
        [Description("标准件")] Standard,
        [Description("成品件")] Finished,
        [Description("通用件")] Universal,
        [Description("专用件")] Special,
        [Description("辅材")] Auxiliary
    }
}