using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPRG102.Final.Roland.Domain
{
    [Table("Asset")]
    public class Asset
    {        
        public int Id { get; set; }
        [Required]
        [DisplayName("Tag Number")]
        public string TagNumber { get; set; }
        [Required]
        [DisplayName("Asset Type")]
        public int AssetTypeId { get; set; }
        [Required]
        [DisplayName("Manufacturer")]
        public int ManufacturerId { get; set; }
        [Required]
        public int ModelId { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// the employee number from the HR database
        /// </summary>
        [DisplayName("Assigned To")]
        public string AssignedTo { get; set; }
        [Required]
        [DisplayName("Serial Number")]
        public string SerialNumber { get; set; }
        [NotMapped]
        public string AssetDetails 
        {
            get 
            {
                var employeeId = AssignedTo == null ? "Not Assigned" : AssignedTo;
                return $"{Manufacturer.Name} {Model.Name} ({employeeId})";
            }
        }

        #region Navigation Properties
        public AssetType AssetType { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public Model Model { get; set; }
        #endregion
    }
}
