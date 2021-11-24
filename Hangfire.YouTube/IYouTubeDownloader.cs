using YoutubeExplode.Videos.Streams;

namespace Hangfire.YouTube;

public interface IYouTubeDownloader
{
    string ExtractYoutubeId(string link);
    Task<StreamManifest> GetStreamManifest(string link);
    IVideoStreamInfo GetStreamInfoMuxed(StreamManifest streamManifest);
    Task DownloadAsync(string link);

}