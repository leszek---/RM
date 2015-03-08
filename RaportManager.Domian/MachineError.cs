using System.ComponentModel;

namespace RaportManager.Domian
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MachineError")]
    public partial class MachineError
    {
        public int MachineErrorID { get; set; }

        [DisplayName("Data")]
        public DateTime MachineErrorDate { get; set; }

        [Required]
        [StringLength(500)]
        [DisplayName("Opis")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}
