using CPRG102.Final.Roland.Domain;
using CPRG102.Final.Roland.UI.HRData;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG102.Final.Roland.UI.ViewModels
{
    public class AssignmentPageViewModel
    {
        [Display(Name ="Employee")]
        public SelectList UnassignedEmployees { get; set; }
        [Display(Name = "Asset Type")]
        public SelectList AssetTypes { get; set; }
        public SelectList Assets { get; set; }
    }
}
