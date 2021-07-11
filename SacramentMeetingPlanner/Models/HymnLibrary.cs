using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;

namespace SacramentMeetingPlanner.Models
{
    public class HymnLibrary
    {
        private readonly Dictionary<int, Hymn> _hymns = new();
        private SelectList _hymnSelectList;

        public Hymn GetHymn(int hymnNumber)
        {
            if (_hymns.ContainsKey(hymnNumber))
                return _hymns[hymnNumber];
            return null;
        }

        public SelectList GetSelectionList()
        {
            if (_hymnSelectList != null)
                return _hymnSelectList;

            var hymnList = new List<SelectListItem>();
            foreach (var hymn in _hymns.Values)
            {
                hymnList.Add(new SelectListItem(hymn.SongNumber + " - " + hymn.Name, hymn.SongNumber));
            }

            _hymnSelectList = new SelectList(hymnList,"Value","Text");
            return _hymnSelectList;
        }

        public async Task Load()
        {
            var hymnList = await LoadJson();
            foreach (var entry in hymnList)
            {
                //_hymns.Add(int.Parse(entry.Number),entry.Hymn);
                _hymns.Add(int.Parse(entry.SongNumber), entry);
            }
        }

        private static async Task<List<Hymn>> LoadJson()
        {
            string json;

            try
            {
                HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

                var stringTask =
                    client.GetStringAsync(
                        "https://cdn.statically.io/gh/pseudosavant/LDSHymns/c3a00214e2f879a855f5894b345596dd6c547b70/hymns.json");

                json = await stringTask;
            }
            catch (Exception)
            {
                json = await System.IO.File.ReadAllTextAsync("data/hymns.json");
            }


            
            var entries = JObject.Parse(json);

            var hymns = new List<Hymn>();
            for (var i = 0; i < entries.Count; i++)
            {
                var jToken = ((JContainer)entries.Children().ElementAt(i)).First;
                if (jToken != null)
                {
                    var hymnJson = jToken.ToString();
                    var hymn = JsonSerializer.Deserialize<Hymn>(hymnJson);
                    if (hymn == null)
                        continue;

                    hymn.Url = CleanupUrl(hymn.Url);
                    hymn.AltUrl = CleanupUrl(hymn.AltUrl);
                    hymn.Mp3 = CleanupUrl(hymn.Mp3);
                    hymn.PlayerLink = CleanupUrl(hymn.PlayerLink);
                    hymn.Pdf = CleanupUrl(hymn.Pdf);
                    hymn.Video1 = CleanupUrl(hymn.Video1);
                    hymn.Video2 = CleanupUrl(hymn.Video2);

                    hymns.Add(hymn);
                }
            }

            return hymns;
            //return entries.Select(x=>x.Value).ToList();

        }

        private static string CleanupUrl(string url)
        {
            url = MakeHttps(url);
            url = RemoveDownload(url);
            return url;
        }

        private static string MakeHttps(string url)
        {
            if (url == null)
                return url;
            if (!url.Contains("http:"))
                return url;
            return url.Replace("http:", "https:");
        }

        private static string RemoveDownload(string url)
        {
            if (url == null)
                return url;
            if (!url.Contains("?download=true"))
                return url;
            return url.Replace("?download=true", "");
        }
    }
}