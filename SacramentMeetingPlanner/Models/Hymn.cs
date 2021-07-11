using System.Text.Json.Serialization;

namespace SacramentMeetingPlanner.Models
{
    public class Hymn
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("artist")]
        public string Artist { get; set; }
        [JsonPropertyName("book")]
        public string Book { get; set; }
        [JsonPropertyName("bookFilter")]
        public string BookFilter { get; set; }
        [JsonPropertyName("collectionFilter")]
        public string CollectionFilter { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("alturl")]
        public string AltUrl { get; set; }
        [JsonPropertyName("mp3")]
        public string Mp3 { get; set; }
        [JsonPropertyName("playerlink")]
        public string PlayerLink { get; set; }
        [JsonPropertyName("pdf")]
        public string Pdf { get; set; }
        [JsonPropertyName("video1")]
        public string Video1 { get; set; }
        [JsonPropertyName("video2")]
        public string Video2 { get; set; }
        [JsonPropertyName("showAsterisk")]
        public bool ShowAsterisk { get; set; }
        [JsonPropertyName("hasDownload")]
        public bool HasDownload { get; set; }
        [JsonPropertyName("midi")]
        public object Midi { get; set; }
        [JsonPropertyName("songid")]
        public string SongId { get; set; }
        [JsonPropertyName("songNumber")]
        public string SongNumber { get; set; }
        [JsonPropertyName("detailColumn")]
        public string DetailColumn { get; set; }

        [JsonIgnore]
        public string DisplayName => SongNumber + " - " + Name;
    }

}
