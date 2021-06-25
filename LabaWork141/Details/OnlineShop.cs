using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaWork141
{
    class OnlineShop
    {
        public delegate void EventHandler<GoodsInfoEventArgs>(object sender, GoodsInfoEventArgs e);
        // 4) declare event of type EventHandler<GoodsInfoEventArgs>
        public event EventHandler<GoodsInfoEventArgs> OnlineShopHandler;

        // 5) declare method NewGoods for event initiation
        // use parameter string to get GoodsName
        public void NewGoods(string name)
        {
            //// don't forget to check if event is not null
            //// in true case intiate the event
            //// use next line
            //// your_event_name(this, new GoodsInfoEventArgs(GoodsName));
            if (OnlineShopHandler is not null)
            {
                Console.WriteLine($"OnlineShop use OnlineShopHandler in NewGoods to inform about {name}");
                OnlineShopHandler(this, new GoodsInfoEventArgs(name));
                Console.WriteLine($"OnlineShop finished inform in NewGoods about {name}");
            }               
            //simple call:
            //OnlineShopHandler?.Invoke(this, new GoodsInfoEventArgs(name));
        }      

    }
}
