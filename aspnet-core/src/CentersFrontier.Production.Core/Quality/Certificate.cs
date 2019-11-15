using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace CentersFrontier.Production.Quality
{
    public class Certificate : Entity<string>
    {
        public int Quantity { get; set; }

        [Required]public string QcCardId { get; set; }
        public QcCard QcCard { get; set; }
    }

    public class QcCard : Entity<string>
    {

    }
}