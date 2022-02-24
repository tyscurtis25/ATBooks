using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATBooks.Models
{
    public class ShoppingCart
    {
        public List<ShoppingCartLineItem> Items { get; set; } = new List<ShoppingCartLineItem>();
        public void AddItem (Books bk, int qty)
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

        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * 25);

            return sum;
        }
    }

    
    public class ShoppingCartLineItem
    {
        public int LineID { get; set; }
        public Books Book { get; set; }
        public int Quantity { get; set; }
    }
}
