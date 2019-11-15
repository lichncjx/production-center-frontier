using System;

namespace CentersFrontier.Production.Entities
{
    public interface IHasReceptionTime : IReceivable
    {
        DateTime ReceptionTime { get; set; }
    }
}