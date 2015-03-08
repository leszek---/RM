using System.ComponentModel;

namespace RaportManager.Domian
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Item")]
    public partial class Item
    {
        public int ItemID { get; set; }

        [DisplayName("Numer Zmiany")]
        public int ShiftNumber { get; set; }

        [DisplayName("Data")]
        public DateTime DateCreated { get; set; }

        public bool Status { get; set; }

        public int? SettingsID { get; set; }

        public virtual Settings Settings { get; set; }
    }
}
