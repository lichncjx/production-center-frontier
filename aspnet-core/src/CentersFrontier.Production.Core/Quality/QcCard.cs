using Abp.Domain.Entities;

namespace CentersFrontier.Production.Quality
{
    public class QcCard : Entity<string>
    {
        public int Quantity { get; set; }
    }
}