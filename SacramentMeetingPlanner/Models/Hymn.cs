using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;

namespace SacramentMeetingPlanner.Models
{
    public static class HymnExtensions
    {
        // from https://github.com/beandog/lds-scriptures
        public static void AddHymns(this IServiceCollection services)
        {
            var library = new HymnLibrary();
            library.Load();
            services.AddSingleton(library);
        }

        
    }

    public class HymnLibrary
    {
        private Dictionary<int, Hymn> _hymns = new();



        public void Load()
        {
            var hymnList = LoadJson();
            foreach (var entry in hymnList)
            {
                //_hymns.Add(int.Parse(entry.Number),entry.Hymn);
                _hymns.Add(int.Parse(entry.SongNumber), entry);
            }
        }

        private static List<Hymn> LoadJson()
        {
            var json = System.IO.File.ReadAllText("data/hymns.json");
            var entries = JObject.Parse(json);

            var hymns = new List<Hymn>();
            for (int i = 0; i < entries.Count; i++)
            {
                var jToken = ((JContainer)entries.Children().ElementAt(i)).First;
                if (jToken != null)
                {
                    var hymnJson = jToken.ToString();
                    var hymn = JsonSerializer.Deserialize<Hymn>(hymnJson);
                    hymns.Add(hymn);
                }
            }

            return hymns;
            //return entries.Select(x=>x.Value).ToList();

        }
    }

    public class HymnEntry {
        public string Number { get; set; }
        public Hymn Hymn { get; set; }
    }

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
    }

}
