using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomDrawingSample.Model {
    public partial class Order {
        [Key]
        public int OrderID { get; set; }

        [Column("EmployeeID")]
        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }

        [Column("Freight", TypeName = "smallmoney")]
        public decimal Freight { get; set; }

        [Column("OrderDate", TypeName = "datetime")]
        public DateTime OrderDate { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
