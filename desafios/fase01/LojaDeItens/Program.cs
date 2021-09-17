using System;

namespace LojaDeItens
{
    class Program
    {
        private static string[] _items = new[] {"Pão de Queijo", "Acarajé", "Feijoada"};
        private static string[] _bag = Array.Empty<string>();
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
                Console.WriteLine("{0}: {1}", i+1, _items[i]);
            }
        }
        
        private static void PrintBag()
        {
            Console.WriteLine("Você não tem mais dinheiro! Esses são seus items:");
            for (int i = 0; i < _bag.Length; i++)
            {
                Console.WriteLine("{0}: {1}", i+1, _bag[i]);
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
                    valideInput = ReadInput(contador, coins);
                }

                coins--;
                contador++;
            }
        }

        private static bool ReadInput(int contador, int coins)
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

            if (contador >= _bag.Length)
            {
                var newlength = contador + 1;
                Array.Resize(ref _bag, newlength);
            }
            
            Console.WriteLine("Você comprou {0} por 1 coin! você tem {1}", item, coins - 1);
            
            _bag[contador] = item;
            
            return true;
        }
    }
}