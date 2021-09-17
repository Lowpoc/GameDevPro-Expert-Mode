using System;
using System.Linq;

namespace ChooseYourGear
{
    class Program
    {
        private static Item[] _items = new Item[3];
        private static int contador = 0;
        
        enum Item
        {
            DESCONHECIDO = -1,
            PANELA,
            TRAVESSEIRO,
            ARMA,
            GAMEBOY,
            BARRADECHOCOLATE,
            CAMISA,
        }
        
        static void Main(string[] args)
        {
            PrintAndWait("Um apocalipse zumbi acabou de acontecer do nada na sua cidade");
            PrintAndWait("Você começa a correr e pega tudo que vê pela frente....");
            Separator();
            PrintOnly($"Você se depara com uma {Item.PANELA} e um {Item.TRAVESSEIRO}");
            ReadItem();
            PrintOnly($"Você se depara com uma {Item.ARMA} e um {Item.GAMEBOY}");
            ReadItem();
            PrintOnly($"Você se depara com uma {Item.CAMISA} e um {Item.BARRADECHOCOLATE}");
            ReadItem();
            PrintItens();
        }


        private static void PrintAndWait(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }
        
        private static void PrintOnly(string message)
        {
            Console.WriteLine(message);
        }
        
        private static void ReadItem()
        {
           var item = Console.ReadLine();

           var result = Enum.TryParse<Item>(item?.Trim().ToUpper(), out var value);

           if (contador < 0 || contador >= _items.Length) return;

           if (!result)
           {
               Console.WriteLine("Você não escolheu nenhum item.");
               _items[contador] = Item.DESCONHECIDO;
           }
           else
           {
               _items[contador] =  value;
           }

           contador++;
        }
        
        private static void Separator()
        {
            Console.WriteLine("");
            Console.WriteLine("-------------------------");
            Console.WriteLine("");
        }
        
        private static void PrintItens()
        {
            PrintAndWait($"Suas escolhas foram: {string.Join(",", _items)}");
        }
    }
}