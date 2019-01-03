using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebApplication6.Models
{
    public class EmployeeModel
    {
        public int? year { get; set; }
        public int month { get; set; }
        public int buttonvalue { get; set; }
        public int lob { get; set; }
        public string from { get; set; }
        public string till { get; set; }
        public int? tempid { get; set; }
        public long client { get; set; }
        public long country { get; set; }
        public string clid { get; set; }
       
        [RegularExpression(@"^((\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)\s*[;]{0,1}\s*)+$", ErrorMessage ="Enter valid email address")]
        [Display(Name = "To")]
        [Required]
        public string ToEmail { get; set; }
        [Display(Name = "Body")]
        [DataType(DataType.MultilineText)]
        public string EMailBody { get; set; }
        [Display(Name = "Subject")]
        public string EmailSubject { get; set; }

       
        [RegularExpression(@"^((\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)\s*[;]{0,1}\s*)+$", ErrorMessage = "Enter valid email address")]
        [Display(Name = "CC")]
        public string EmailCC { get; set; }

      
        [Display(Name = "BCC")]
        [RegularExpression(@"^((\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)\s*[;]{0,1}\s*)+$", ErrorMessage = "Enter valid email address")]
        public string EmailBCC { get; set; }
    }
}