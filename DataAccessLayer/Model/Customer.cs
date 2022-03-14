using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Model
{
    public class Customer
    {
        /*Using data anotation [Key] for defining the Primary key for Customer table  */

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int CustomerId { get; set; }

        [Required(ErrorMessage ="Customer Name is required")]
        [StringLength(50,ErrorMessage ="Name Cannot be longer than 50 characters")]

        public string CustomerName{ get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email is not valid")]

        public string Email { get; set; }

        [Required]
        [DataType(DataType.DateTime)]

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Required]
     
        public bool IsDeleted { get; set; } = false;

        // For navigation between the two classes 

        public ICollection<Order> Orders { get; set; }


    }
}
