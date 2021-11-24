using System;
using System.Text;
using System.Threading.Tasks;
using Hangfire.Downloader.Downloaders;
using Hangfire.Downloader.MetaDataHelpers;

namespace Hangfire.UI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            ConsoleWriter.WriteTitle($"YouTube-Downloader with Hangfire {Environment.NewLine}",ConsoleColor.Cyan);

            ConsoleWriter.WriteText($"{Environment.NewLine} Please enter your YouTube-link", ConsoleColor.White);
            ConsoleWriter.WriteText("Link : ", ConsoleColor.Cyan, false);
            var link = Console.ReadLine();
            Console.Clear();

            ConsoleWriter.WriteText($"{Environment.NewLine} Please enter your desired filename.", ConsoleColor.White);
            ConsoleWriter.WriteText("filename : ", ConsoleColor.Cyan, false);
            var filename = Console.ReadLine();
            Console.Clear();

            var result = YoutubeDownloader.DownloadAsync(link, filename);
            var info = await YouTubeInfo.GetVideoData(link);

            ConsoleWriter.WriteText($"You chose to download the video: \"{info.Title}\" {Environment.NewLine}", ConsoleColor.White);
            ConsoleWriter.WriteText($"Video title: {info.Title}", ConsoleColor.White);
            ConsoleWriter.WriteText($"Video duration: {info.Duration}", ConsoleColor.White);
            ConsoleWriter.WriteText($"Video upload date: {info.UploadDate}", ConsoleColor.White);
            ConsoleWriter.WriteText($"Video author: {info.Author}", ConsoleColor.White);
            ConsoleWriter.WriteText($"Video description: {info.Description} {Environment.NewLine}", ConsoleColor.White);



            if (result.IsCompletedSuccessfully)
            {
                ConsoleWriter.WriteText($"Your YouTube-video was succesfully download", ConsoleColor.Green);
                ConsoleWriter.WriteText($"link: {link} {Environment.NewLine}filename: {filename}", ConsoleColor.White);
            }
            ConsoleWriter.WriteText($"link: {link} {Environment.NewLine}filename: {filename}", ConsoleColor.Green);






        }
    }
}
