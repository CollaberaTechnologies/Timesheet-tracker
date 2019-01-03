//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace WebApplication6.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class hc_client_user
    {

        public string offemail { get; set; }
        public string peremail { get; set; }
        public string bothemail { get; set; }
        public long years { get; set; }
        [Required]
        public string months { get; set; }
        public string buttonvalue { get; set; }
        public long lobs { get; set; }
        public string from { get; set; }
        public string till { get; set; }
        public int? tempid { get; set; }
        public string clients { get; set; }
        public string monthdata { get; set; }

        [Display(Name = "year")]
        [Required]
        public long country { get; set; }
        public string clid { get; set; }

        [RegularExpression(@"^((\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)\s*[;]{0,1}\s*)+$", ErrorMessage = "Enter valid email address")]
        [Display(Name = "To")]

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

        [Required]
        [Display(Name = "From Date")]
        [DataType(DataType.Date)]

        public DateTime JoinDate { get; set; }
        public List<TimeSheetDetailsAgainstCandidate_Result> candidate { get; set; }
        [Required]
        [Display(Name = "To Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public string valclient { get; set; }
        public string val { get; set; }
        public long id { get; set; }

        [Required]
        public long[] client { get; set; }

        [Required]
        public long lob { get; set; }

        [Display(Name = "year")]
        [Required]
        public long year { get; set; }
        [Required]
        public long[] month { get; set; }
        public string message { get; set; }
        public int tempid1 { get; set; }
        public int tempid2 { get; set; }
        public int tempid3 { get; set; }
        public string name { get; set; }
        public long RID { get; set; }
        public long Clientid { get; set; }
        public long Userid { get; set; }
        public long Countryid { get; set; }
        public string Imagepath { get; set; }

        public virtual HC_CLIENTS HC_CLIENTS { get; set; }
        public virtual HCM_COUNTRIES HCM_COUNTRIES { get; set; }
        public virtual HC_USERS HC_USERS { get; set; }
    }
}
