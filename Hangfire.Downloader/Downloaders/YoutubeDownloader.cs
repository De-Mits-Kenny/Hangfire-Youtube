using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Hangfire.Models;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace Hangfire.Downloader.Downloaders
{
    public static class YoutubeDownloader
    {
        public static string ExtractYoutubeId(string link)
        {
            var YoutubeLinkRegex = "(?:.+?)?(?:\\/v\\/|watch\\/|\\?v=|\\&v=|youtu\\.be\\/|\\/v=|^youtu\\.be\\/)([a-zA-Z0-9_-]{11})+";
            var regex = new Regex(YoutubeLinkRegex, RegexOptions.Compiled);
            foreach (Match match in regex.Matches(link))
            {
                //Console.WriteLine(match);
                foreach (var groupdata in match.Groups.Cast<Group>().Where(groupdata => !groupdata.ToString().StartsWith("http://")
                             && !groupdata.ToString().StartsWith("https://")
                             && !groupdata.ToString().StartsWith("youtu")
                             && !groupdata.ToString().StartsWith("www.")))
                {
                    return groupdata.ToString();
                }
            }
            return string.Empty;
        }

        public static async Task<StreamManifest> GetStreamManifest(string link)
        {
            var youtube = new YoutubeClient();
            var Id = ExtractYoutubeId(link);
            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(Id);
            return streamManifest;
        }

        public static IVideoStreamInfo GetStreamInfoMuxed(StreamManifest streamManifest)
        {
            return streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();
        }

        public static async Task DownloadAsync(VideoRequest request)
        {
            var youtube = new YoutubeClient();
            var streamManifest = GetStreamManifest(request.link);
            var streamInfo = GetStreamInfoMuxed(streamManifest.Result);
            var stream = await youtube.Videos.Streams.GetAsync(streamInfo);
            await youtube.Videos.Streams.DownloadAsync(streamInfo, $"C:\\Users\\kdemi\\Desktop\\YouTubeVideosTest\\{request.fileName}.{streamInfo.Container}");
        }
    }
}