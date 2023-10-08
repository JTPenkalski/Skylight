using System.ComponentModel.DataAnnotations;

namespace Skylight.WebModels.Forms
{
    /// <summary>
    /// Contains all validation messages for UI controls.
    /// These are defined in Resource files.
    /// </summary>
    public class FormControlValidationMessages
    {
        [Required]
        public string ErrorMaxDate => Resources.FormControlValidationMessages.Error_MaxDate;

        [Required]
        public string ErrorMaxLength => Resources.FormControlValidationMessages.Error_MaxLength;

        [Required]
        public string ErrorMaxValue => Resources.FormControlValidationMessages.Error_MaxValue;

        [Required]
        public string ErrorMinDate => Resources.FormControlValidationMessages.Error_MinDate;

        [Required]
        public string ErrorMinLength => Resources.FormControlValidationMessages.Error_MinLength;

        [Required]
        public string ErrorMinValue => Resources.FormControlValidationMessages.Error_MinValue;

        [Required]
        public string ErrorPattern => Resources.FormControlValidationMessages.Error_Pattern;

        [Required]
        public string ErrorRangeDate => Resources.FormControlValidationMessages.Error_RangeDate;

        [Required]
        public string ErrorRangeLength => Resources.FormControlValidationMessages.Error_RangeLength;

        [Required]
        public string ErrorRangeValue => Resources.FormControlValidationMessages.Error_RangeValue;

        [Required]
        public string ErrorRequired => Resources.FormControlValidationMessages.Error_Required;
    }
}
