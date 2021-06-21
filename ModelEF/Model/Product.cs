namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
       

        [Key]
        [StringLength(10)]
        public string masp { get; set; }

        [Required]
        [StringLength(10)]
        public string maloai { get; set; }

        [Required]
        [StringLength(50)]
        public string tensp { get; set; }

        [Column(TypeName = "money")]
        public decimal? dongia { get; set; }

        public int? soluong { get; set; }

        [StringLength(200)]
        public string Image { get; set; }

        public bool FindName(string tensp)
        {
            throw new NotImplementedException();
        }

        [StringLength(30)]
        public string trangthai { get; set; }

        public string Insert(Product model)
        {
            throw new NotImplementedException();
        }

        [StringLength(50)]
        public string mota { get; set; }

        [StringLength(50)]
        public string mausac { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<donhang> donhangs { get; set; }
        public string Update(Product model)
        {
            throw new NotImplementedException();
        }
    }
}
