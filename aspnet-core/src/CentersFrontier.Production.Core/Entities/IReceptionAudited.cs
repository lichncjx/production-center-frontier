namespace CentersFrontier.Production.Entities
{
    public interface IReceptionAudited : IHasReceptionTime
    {
        long? RecipientUserId { get; set; }
    }
}