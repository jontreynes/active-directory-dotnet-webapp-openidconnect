using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp_OpenIDConnect_DotNet.Models
{
    [JsonObject]
    [Serializable]
    public class MathModelClass
    {
        [Required]
        [RegularExpression(@"^\d$", ErrorMessage = "Only allows numbers")]
        public int x_number { get; set; }
        [Required]
        [RegularExpression(@"^\d$", ErrorMessage = "Only allows numbers")]
        public int y_number { get; set; }
    }
}