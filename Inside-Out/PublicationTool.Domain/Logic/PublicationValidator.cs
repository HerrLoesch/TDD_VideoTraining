using System;
using PublicationTool.Domain.Infrastructure;
using PublicationTool.Domain.Object;

namespace PublicationTool.Domain.Logic
{
    public class PublicationValidator
    {
        private readonly StringValidationRule titleValidationRule;
        private readonly ValidationRule dateValidationRule;

        public PublicationValidator()
        {
            titleValidationRule = new StringValidationRule(3, 120, true, "Title");
            dateValidationRule = new ValidationRule()
                {ErrorIfNull = true, PropertyName = "Date", TargetType = typeof(DateTime)};
        }

        public Result Validate(Publication publication)
        {
            var result = new Result();

            if (!titleValidationRule.Validate(publication.Title, out var errorText))
                result.Errors.Add(errorText);

            if (!dateValidationRule.Validate(publication.Date, out errorText))
                result.Errors.Add(errorText);

            return result;
        }
    }
}