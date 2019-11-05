using System.ComponentModel;

namespace CentersFrontier.Production.Models
{
    public enum DevelopmentStage
    {
        [Description("模态")] M,

        [Description("初样")] C,

        [Description("试样")] S,

        [Description("定型")] D
    }
}