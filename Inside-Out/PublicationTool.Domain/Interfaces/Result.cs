namespace PublicationTool.Domain.Interfaces
{
    public class Result
    {
        public Result()
        {
            Error = "";
        }

        public bool WasSuccessful => string.IsNullOrEmpty(Error);

        public string Error { get; set; }
    }
}