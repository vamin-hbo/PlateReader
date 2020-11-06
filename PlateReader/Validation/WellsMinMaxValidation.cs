using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PlateReader.Validation
{
    /// <summary>
    /// This the validation class for validating if Wells are in a predefined range.
    /// </summary>
    public class WellsMinMaxValidation:ValidationRule
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public WellsMinMaxValidation()
        {
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int threshold = 0;

            try
            {
                if (((string)value).Length > 0)
                    threshold = Int32.Parse((String)value);
            }
            catch (Exception e)
            {
                return new ValidationResult(false, $"Illegal characters or {e.Message}");
            }

            if ((threshold < Min) || (threshold > Max))
            {
                return new ValidationResult(false,
                  $"Please enter threshold in the range: {Min}-{Max}.");
            }
            return ValidationResult.ValidResult;
        }
    }
}
