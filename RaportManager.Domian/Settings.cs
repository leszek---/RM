using System.ComponentModel;

namespace RaportManager.Domian
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Settings
    {
        public Settings()
        {
            Item = new HashSet<Item>();
        }

        public int SettingsID { get; set; }

        [DisplayName("Aktywna")]
        public bool isActive { get; set; }

        [Required]
        [StringLength(500)]
        [DisplayName("Opis")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public virtual ICollection<Item> Item { get; set; }
    }
}
