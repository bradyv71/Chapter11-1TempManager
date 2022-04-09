using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
namespace TempManager.Models
{
    public class Temp
    {
        public int Id { get; set; }

        [Required]
        [Remote("CheckDate", "Validation")]
        [DataType(DataType.DateTime)] 
        public DateTime? Date { get; set; }

        [Required] 
        [Range(-200, 200, ErrorMessage = "Please enter value in range between -200 and 200")] 
        public double? Low { get; set; }

        [Required] 
        [Range(-200, 200, ErrorMessage = "Please enter value in range between -200 and 200")] 
        public double? High { get; set; }
    }
}
