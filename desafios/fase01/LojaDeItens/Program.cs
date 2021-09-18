using System;

namespace LojaDeItens
{
    class Program
    {
        private static Item[] _items = new[]
        {
            new Item { Name  = "Pão de Queijo", Coin = 1 },
            new Item { Name  = "Acarajé", Coin = 3 },
            new Item { Name  = "Feijoada", Coin = 2 } 
        };

        private static Item[] _bag = Array.Empty<Item>();
        private static int coins = 5;
        
        static void Main(string[] args)
        {
            PrintAndWait("Bem vindo a nossa loja!");
            PrintAndWait("Eu vejo que você tem muitos coins com você.");
            PrintAndWait("Humm... você quer dar uma olhada no nosso inventário? Sim ou Sim?");
            Separator();
            PrintItens();
            BuyItemsUntilFinish();
            PrintBag();
        }

        private static void PrintAndWait(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }

        private static void Separator()
        {
            Console.WriteLine("");
            Console.WriteLine("---------------------Loja de ITEMS------------------------");
            Console.WriteLine("");
        } 
        
        private static void PrintItens()
        {
            Console.WriteLine("Essas são as nossas opções:");
            for (int i = 0; i < _items.Length; i++)
            {
                Console.WriteLine("{0}: {1} {2}", i+1, _items[i].Name, _items[i].Coin);
            }
        }
        
        private static void PrintBag()
        {
            Console.WriteLine("Você não tem mais dinheiro! Esses são seus items:");
            for (int i = 0; i < _bag.Length; i++)
            {
                Console.WriteLine("{0}: {1} {2}", i+1, _bag[i].Name, _bag[i].Coin);
            }

            Console.ReadKey();
        }
        
        private static void BuyItemsUntilFinish()
        {
            bool valideInput;
            var contador = 0;
            Array.Resize(ref _bag, _items.Length);
            
            while (coins > 0)
            {
                valideInput = false;
                while (!valideInput)
                {
                    Console.Write("Digite o número do item que você quer comprar -->");
                    valideInput = ReadInput(contador);
                }
                contador++;
            }
        }

        private static bool ReadInput(int contador)
        {
            var x = Console.ReadLine()?.Trim();

            int.TryParse(x, out var index);

            index--;
            
            if (index < 0 || index >= _items.Length)
            {
                Console.WriteLine("Eu não conheco esse item. E Você  não sai daqui até comprar!");
                return false;
            }
            
            var item = _items[index];

            if (item.Coin > coins)
            {
                Console.WriteLine("Você não tem coins suficiente {0}", coins);
                return false;
            }

            if (contador >= _bag.Length)
            {
                var newlength = contador + 1;
                Array.Resize(ref _bag, newlength);
            }

            Console.WriteLine("Você comprou {0} por {1} coin! você tem {2}",
                item.Name,
                item.Coin,
                coins - item.Coin);
            
            _bag[contador] = item;
            coins -= item.Coin;
            
            return true;
        }
    }
}