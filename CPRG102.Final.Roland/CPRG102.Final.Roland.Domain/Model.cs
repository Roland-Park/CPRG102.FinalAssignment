using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CPRG102.Final.Roland.Domain
{
    [Table("Model")]
    public class Model
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int ManufacturerId { get; set; }

        #region Navigation Properties
        public ICollection<Asset> Assets { get; set; }
        #endregion
    }
}
