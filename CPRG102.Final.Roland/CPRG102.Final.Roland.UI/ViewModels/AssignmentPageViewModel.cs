using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

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
