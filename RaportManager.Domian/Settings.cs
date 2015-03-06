namespace RaportManager.Domian
{
    using System.ComponentModel.DataAnnotations;

    public partial class Settings
    {
        public int SettingsID { get; set; }

        public int ItemID { get; set; }

        public bool isActive { get; set; }

        [Required]
        [StringLength(500)]
        public string Content { get; set; }

        public virtual Item Item { get; set; }
    }
}