using System.ComponentModel.DataAnnotations;
using WebApplication.Filters.Startup.Abstracts;

namespace WebApplication.Settings.Json
{
    public sealed class MySettings : DataAnnotationSettingValidation
    {
        public int Setting1 { get; set; }

        [Required]
        public string Setting2 { get; set; }
    }
}
