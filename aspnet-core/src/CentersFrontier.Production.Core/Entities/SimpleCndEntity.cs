using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace CentersFrontier.Production.Entities
{
    public abstract class SimpleCndEntity : Entity
    {
        public const int MaxCodeLength = 32;
        public const int MaxNameLength = 32;
        public const int MaxDescriptionLength = 256;

        private string _code;

        [Required]
        [MaxLength(MaxCodeLength)]
        public string Code
        {
            get => _code;
            set => _code = value.Trim().ToUpper();
        }

        [Required] [MaxLength(MaxNameLength)] public string Name { get; set; }

        [MaxLength(MaxDescriptionLength)] public string Description { get; set; }
    }
}