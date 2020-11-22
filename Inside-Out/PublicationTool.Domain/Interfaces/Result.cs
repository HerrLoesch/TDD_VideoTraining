using System.Collections.Generic;

namespace PublicationTool.Domain.Interfaces
{
    public class Result
    {
        private string error = "";

        public Result()
        {
            Errors = new List<string>();
        }

        public bool WasSuccessful => string.IsNullOrEmpty(Error);

        public string Error
        {
            get => error;
            set
            {
                error = value;
                Errors.Add(error);
            } 
        }

        public List<string> Errors { get; set; }
    }
}