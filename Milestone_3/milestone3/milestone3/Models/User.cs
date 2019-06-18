namespace milestone3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [Key]
        public int Userid { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)] //password format
        [StringLength(50)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Pseudonym is required.")]
        [StringLength(50)]
        public string Pseudonym { get; set; }

        //payment information is optional
        [StringLength(100)]
        [DataType(DataType.CreditCard)]
        public string PaymentInformation { get; set; }
    }
}
