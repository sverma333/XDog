using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XDogService.Models
{
    public class FiveStringIntDblBindingModel
    {
        [Required]
        [Display(Name = "String sPrm1 (req)")]
        public string sPrm1 { get; set; }

        [Display(Name = "String sPrm2 (opt)")]
        public string sPrm2 { get; set; }

        [Display(Name = "String sPrm3 (opt)")]
        public string sPrm3 { get; set; }

        [Display(Name = "String sPrm4 (opt)")]
        public string sPrm4 { get; set; }

        [Display(Name = "String sPrm5 (opt)")]
        public string sPrm5 { get; set; }

        [Display(Name = "int iPrm1 (opt)")]
        public int iPrm1 { get; set; }

        [Display(Name = "int iPrm2 (opt)")]
        public string iPrm2 { get; set; }

        [Display(Name = "int iPrm3 (opt)")]
        public string iPrm3 { get; set; }

        [Display(Name = "int iPrm4 (opt)")]
        public string iPrm4 { get; set; }

        [Display(Name = "int iPrm5 (opt)")]
        public string iPrm5 { get; set; }

        [Display(Name = "double dPrm1 (opt)")]
        public int dPrm1 { get; set; }

        [Display(Name = "int dPrm2 (opt)")]
        public string dPrm2 { get; set; }

        [Display(Name = "int dPrm3 (opt)")]
        public string dPrm3 { get; set; }

        [Display(Name = "int dPrm4 (opt)")]
        public string dPrm4 { get; set; }

        [Display(Name = "int dPrm5 (opt)")]
        public string dPrm5 { get; set; }

    }
}