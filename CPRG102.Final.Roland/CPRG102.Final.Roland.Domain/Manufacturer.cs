using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CPRG102.Final.Roland.Domain
{
    [Table("Manufacturer")]
    public class Manufacturer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        #region Navigation Properties
        public ICollection<Asset> Assets { get; set; }
        public ICollection<Model> Models { get; set; }
        #endregion
    }
}
