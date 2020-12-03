using CPRG102.Final.Roland.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG102.Final.Roland.UI.ViewModels
{
    public class AssetViewModel
    {
        [DisplayName("Tag Number")]
        public string TagNumber { get; set; }
        [DisplayName("Serial Number")]
        public string SerialNumber { get; set; }
        [DisplayName("Asset Type")]
        public int AssetTypeId { get; set; }
        [DisplayName("Manufacturer")]
        public int ManufacturerId { get; set; }
        [DisplayName("Model")]
        public int ModelId { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// the employee number from the HR database
        /// </summary>
        [DisplayName("Assigned To")]
        public string AssignedTo { get; set; }
        public SelectList AssetTypeList { get; set; }
        public SelectList ManufacturerList { get; set; }
        public SelectList ModelList { get; set; }
        public SelectList EmployeeList { get; set; }
    }
}
