using System.ComponentModel.DataAnnotations;

namespace  AlRayan.Attributes
{
    public class AllowedExtentionsAttribute : ValidationAttribute

    {
        private readonly string _allowedExtentions;
        public AllowedExtentionsAttribute(string allowedExtentions)
        {
            _allowedExtentions = allowedExtentions;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if(file is not null)
            {
                var extention = Path.GetExtension(file.FileName);
                var isAllowed =_allowedExtentions.Split(",").Contains(extention,StringComparer.OrdinalIgnoreCase) ;
                if (!isAllowed)
                {
                    return new ValidationResult($"Only {_allowedExtentions} are allowed !");
                }


            }

            return ValidationResult.Success;
        }
        

    }
}
