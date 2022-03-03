using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ATBooks.Models
{
    public class ShoppingCart
    {
        public List<ShoppingCartLineItem> Items { get; set; } = new List<ShoppingCartLineItem>();
        public virtual void AddItem (Books bk, int qty)
        {
            ShoppingCartLineItem line = Items
                .Where(b => b.Book.BookId == bk.BookId)
                .FirstOrDefault();
            if (line == null)
            {
                Items.Add(new ShoppingCartLineItem
                {
                    Book = bk,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public virtual void RemoveItem (Books bk)
        {
            Items.RemoveAll(x => x.Book.BookId == bk.BookId);
        }

        public virtual void ClearShoppingCart()
        {
            Items.Clear();
        }

        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);

            return sum;
        }
    }
    
    public class ShoppingCartLineItem
    {
        [Key]
        public int LineID { get; set; }
        public Books Book { get; set; }
        public int Quantity { get; set; }
    }
}
