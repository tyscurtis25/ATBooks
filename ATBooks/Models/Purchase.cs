using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ATBooks.Models
{
    public class Purchase
    {
        [Key]
        [BindNever]
        public int PurchaseId { get; set; }

        [BindNever]
        public ICollection<ShoppingCartLineItem> Lines { get; set; }

        [Required(ErrorMessage = "Please enter a name: ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter an email: ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a phone number: ")]
        public string Phone { get; set; }



    }
}
