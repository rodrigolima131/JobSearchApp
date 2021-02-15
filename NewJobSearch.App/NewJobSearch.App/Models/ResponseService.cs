using System;
using System.Collections.Generic;
using System.Text;

namespace NewJobSearch.App.Models
{
    public class ResponseService<T>
    {
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }

        public T Data { get; set; }
        public Dictionary<string, List<String>> Errors { get; set; }
    }
}
