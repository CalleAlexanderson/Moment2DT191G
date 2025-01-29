namespace Moment2.Models
{
    public class MediaModel
    {
        public required string MediaName {get; set;}
        public required int MediaScore {get; set;}
        public required int MediaEpisodesChapters {get; set;}
        public required int MediaSeasonsVolumes {get; set;}
        public required string MediaType {get; set;}
        public required string[] MediaTags {get; set;}
    }
}