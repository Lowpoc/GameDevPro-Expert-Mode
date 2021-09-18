using System;
using System.Collections.Generic;

namespace LojaDeItens
{
    public class Player
    {
        public int Coin { get; private set; }
        public IList<Item> Bag { get; }

        public Player(int coin)
        {
            this.Coin = coin;
            Bag = new List<Item>();
        }

        public bool BuyItem(Item item)
        {
            if (item.Coin > this.Coin) return false;

            this.Coin -= item.Coin;
            
            Console.WriteLine("Você comprou {0} por {1} coin! você tem {2}",
                    item.Name,
                    item.Coin,
                    this.Coin);
            
            Bag.Add(item);
            return true;
        }
    }
}