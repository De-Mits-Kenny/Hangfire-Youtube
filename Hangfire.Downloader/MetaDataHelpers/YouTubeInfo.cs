using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos;

namespace Hangfire.Downloader.MetaDataHelpers
{
    public static class YouTubeInfo
    {
        public static async Task<Video> GetVideoData(string link)
        {
            var youtube = new YoutubeClient();

            return await youtube.Videos.GetAsync(link);
        }
    }
}