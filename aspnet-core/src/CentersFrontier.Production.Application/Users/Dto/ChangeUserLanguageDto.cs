using System.ComponentModel.DataAnnotations;

namespace CentersFrontier.Production.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}