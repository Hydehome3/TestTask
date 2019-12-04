using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestApp.Tests.Deserialization
{
    class RootObject
    {
        [JsonProperty("results")]
        public Result[] Results { get; set; }
    }

    class Result
    {
        [JsonProperty("descriptions")]
        public Description[] Descriptions { get; set; }
    }

    class Description
    {
        [JsonProperty("content")]
        public string Content { get; set; }
    }
}
