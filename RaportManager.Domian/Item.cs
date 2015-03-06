namespace RaportManager.Domian
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Item")]
    public partial class Item
    {
        public Item()
        {
            Settings = new HashSet<Settings>();
        }

        public int ItemID { get; set; }

        public int ShiftNumber { get; set; }

        public DateTime DateCreated { get; set; }

        public bool Status { get; set; }

        public virtual ICollection<Settings> Settings { get; set; }
    }
}