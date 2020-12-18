using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CPRG102.Final.Roland.UI.ViewModels
{
    public class AssignmentPageViewModel
    {
        [Display(Name ="Select Employee")]
        public SelectList UnassignedEmployees { get; set; }
        [Display(Name = "Filter Asset Type")]
        public SelectList AssetTypes { get; set; }

        [Display(Name = "Select Asset")]
        public SelectList Assets { get; set; }
    }
}
