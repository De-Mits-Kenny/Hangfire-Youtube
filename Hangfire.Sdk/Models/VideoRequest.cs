using System;
using System.Collections.Generic;
using System.Text;

namespace Hangfire.Sdk.Models
{
    public class VideoRequest
    {
        public string link { get; set; }
        public string fileName { get; set; }

        public VideoRequest(string Link, string Filename)
        {
            link = Link;
            fileName = Filename;    
        }
    }
}
