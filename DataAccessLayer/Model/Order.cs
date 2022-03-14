using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer.Model
{
    public class Order
    {
        [Key]

        public int OrderId { get; set; }

       [Required(ErrorMessage = "Order Description Cannot be empty")]
       [StringLength(100, ErrorMessage ="Order description cannot be more than 100 charecters")]

        public string OrderDescription { get; set; }

        [Required(ErrorMessage ="Order Quantity Field Cannot be empty")]
        
        public int Orderquantity { get; set; }

        /* Customer and Order has one to many relationship, hence we need foreign key 
           to novigate between the exact configuration of 1- Many relation 
         is done in StoreDbContext Class
         */

        public int CustomerID { get; set; }

        public Customer Customer { get; set; }

        [Required]
        [DataType(DataType.DateTime)]

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Required]

        public bool IsDeleted { get; set; } = false;
    }
}
