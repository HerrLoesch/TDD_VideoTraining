using System.Collections.Generic;
using System.Linq;

namespace PublicationTool.Domain.Infrastructure
{
    public class Result
    {
        public bool Success => !Errors.Any();

        public List<string> Errors { get; set; }

        public Result()
        {
            Errors = new List<string> { };
        }
    }
}