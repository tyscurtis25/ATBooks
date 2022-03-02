using ATBooks.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ATBooks.Models
{
    public class SessionShoppingCart : ShoppingCart
    {
        public static ShoppingCart GetShoppingCart (IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SessionShoppingCart shoppingCart = session?.GetJson<SessionShoppingCart>("ShoppingCart") ?? new SessionShoppingCart();

            shoppingCart.Session = session;

            return shoppingCart;
        }
        
        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(Books bk, int qty)
        {
            base.AddItem(bk, qty);
            Session.SetJson("ShopingCart", this);
        }

        public override void RemoveItem(Books bk)
        {
            base.RemoveItem(bk);
            Session.SetJson("ShoppingCart", this);
        }

        public override void ClearShoppingCart()
        {
            base.ClearShoppingCart();
            Session.Remove("ShoppingCart");
        }

    }
}
