using System;

namespace LojaDeItens
{
    public class Merchant
    {
        private Player _player;
        private Item[] _store;

        public Merchant(Player player)
        {
            _player = player;
            _store = new[]
            {
                new Item { Name  = "Pão de Queijo", Coin = 1 },
                new Item { Name  = "Acarajé", Coin = 3 },
                new Item { Name  = "Feijoada", Coin = 2 } 
            };
        }

        public void OpenStore()
        {
            PrintAndWait("Bem vindo a nossa loja!");
            PrintAndWait("Eu vejo que você tem muitos coins com você.");
            PrintAndWait("Humm... você quer dar uma olhada no nosso inventário? Sim ou Sim?");
            Separator();
            PrintItens();
            BuyItemsUntilFinish();
            PrintBagOfPlayer();
        }
        
        private void PrintAndWait(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }

        private void Separator()
        {
            Console.WriteLine("");
            Console.WriteLine("---------------------Loja de ITEMS------------------------");
            Console.WriteLine("");
        } 
        
        private void PrintItens()
        {
            Console.WriteLine("Essas são as nossas opções:");
            for (int i = 0; i < _store.Length; i++)
            {
                Console.WriteLine("{0}: {1} ${2}", i+1, _store[i].Name, _store[i].Coin);
            }
        }
        
        private void PrintBagOfPlayer()
        {
            Console.WriteLine("Você não tem mais dinheiro! Esses são seus items:");
            for (var index = 0; index < _player.Bag.Count; index++)
            {
                var item = _player.Bag[index];
                Console.WriteLine("{0}: {1} ${2}", index, item.Name, item.Coin);
            }

            Console.ReadKey();
        }
        
        private void BuyItemsUntilFinish()
        {
            bool valideInput;
            
            while (_player.Coin > 0)
            {
                valideInput = false;
                while (!valideInput)
                {
                    Console.Write("Digite o número do item que você quer comprar -->");
                    valideInput = ReadInput();
                }
            }
        }

        private bool ReadInput()
        {
            var x = Console.ReadLine()?.Trim();

            int.TryParse(x, out var index);

            index--;
            
            if (index < 0 || index >= _store.Length)
            {
                Console.WriteLine("Eu não conheco esse item. E Você  não sai daqui até comprar!");
                return false;
            }
            
            var item = _store[index];
            var result = _player.BuyItem(item);

            if (result) return true;

            Console.WriteLine("Você não tem coins suficiente ${0}", _player.Coin);
            return false;
        }
    }
}