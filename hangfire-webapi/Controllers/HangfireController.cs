using System;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.Downloader.Downloaders;
using Hangfire.Downloader.MetaDataHelpers;
using Microsoft.AspNetCore.Mvc;
using YoutubeExplode.Videos;

namespace hangfire_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HangfireController : ControllerBase
    {

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult>Download(string link, string fileName)
        {
            fileName = "test";
            link = "https://www.youtube.com/watch?v=d95PPykB2vE";
            var jobId = BackgroundJob.Enqueue(() => YoutubeDownloader.DownloadAsync(link, fileName));

            Console.WriteLine($"Started downloading Url: {link} {Environment.NewLine} .");
            Video info = await YouTubeInfo.GetVideoData(link);
            Console.WriteLine($"Video title: {info.Title}");
            Console.WriteLine($"Video Author: {info.Author}");
            Console.WriteLine($"Video Duration: {info.Duration}");
            Console.WriteLine($"Video Description: {info.Description}{Environment.NewLine}");

            Console.ForegroundColor = ConsoleColor.White;

            return Ok($"Job ID: {jobId}. VideoLink: {link} started downloading.");
        }

    }
}
