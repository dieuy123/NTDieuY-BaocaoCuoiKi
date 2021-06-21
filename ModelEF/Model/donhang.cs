namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("donhang")]
    public partial class donhang
    {
        [Key]
        [StringLength(20)]
        public string maDH { get; set; }

        [Required]
        [StringLength(10)]
        public string maKH { get; set; }

        [Required]
        [StringLength(10)]
        public string masp { get; set; }

        public DateTime? ngaytaoDH { get; set; }

        [Required]
        [StringLength(50)]
        public string diachigiaohang { get; set; }

        [StringLength(10)]
        public string SDTgiaohang { get; set; }

        public DateTime? ngaythanhtoan { get; set; }

        public DateTime? ngaygiaohang { get; set; }

        [Required]
        [StringLength(100)]
        public string trangthaiDonHang { get; set; }

        public virtual customer customer { get; set; }

        public virtual Product Product { get; set; }
    }
}
