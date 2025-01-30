using System.ComponentModel.DataAnnotations;

namespace Moment2.Models
{

    public class UserModel
    {
        [Required(ErrorMessage = "Fältet får inte lämnas tomt")]
        [Display(Name = "Namn:")]
        public required string User { get; set; }
    }

    public class Text {
        public required string BodyText { get; set; }
        public required string DescText { get; set; }
    }

    public class MediaModel
    {
        [Required(ErrorMessage = "Fältet får inte lämnas tomt")]
        [Display(Name = "Namn:")]
        public required string MediaName { get; set; }

        // blev en string variabel för att jag kunde inte få mitt custom errormessage att fungera när det är int, error var när select var valt
        [Display(Name = "Score:")]
        public required string MediaScore { get; set; }

        // Tvingades göra variablerna nullable för att errormessage ska funka
        [Required(ErrorMessage = "Fältet får inte lämnas tomt")]
        [Display(Name = "Kapitel/Episoder:")]
        [Range(0, int.MaxValue, ErrorMessage = "Värdet på fältet får inte vara negativt")]
        public required int? MediaEpisodesChapters { get; set; }

        [Required(ErrorMessage = "Fältet får inte lämnas tomt")]
        [Display(Name = "Säsonger/Volymer:")]
        [Range(0, int.MaxValue, ErrorMessage = "Värdet på fältet får inte vara negativt")]
        public required int? MediaSeasonsVolumes { get; set; }

        public required string MediaType { get; set; }

        [Display(Name = "Kategorier:")]
        public required string[] MediaTags { get; set; }

        public DateTime Date { get; set; }

    }
}