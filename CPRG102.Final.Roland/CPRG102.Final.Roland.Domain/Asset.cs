using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CPRG102.Final.Roland.Domain
{
    [Table("Asset")]
    public class Asset
    {        
        public int Id { get; set; }
        [Required]
        public string TagNumber { get; set; }
        [Required]
        public int AssetTypeId { get; set; }
        [Required]
        public int ManufacturerId { get; set; }
        [Required]
        public int ModelId { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// the employee number from the HR database
        /// </summary>
        public string AssignedTo { get; set; }
        [Required]
        public string SerialNumber { get; set; }

        #region Navigation Properties
        public AssetType AssetType { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public Model Model { get; set; }
        #endregion
    }
}
