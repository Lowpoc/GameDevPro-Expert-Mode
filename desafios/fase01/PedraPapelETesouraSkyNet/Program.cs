using System;

namespace PedraPapelETesouraSkyNet
{
    class Program
    {
        public enum Action
        {
            Rock,
            Paper,
            Scissor,
        }
        
        static void Main(string[] args)
        {
            PrintAndWait("Bem vindo ao Rock Paper Scissor com uma IA!");
            PrintAndWait("Esse é o meu território, então você não tem chance.");
            PrintAndWait("(é serio, eu que fiz esse jogo)");
            PrintAndWait("");
            PrintAndWait("---------------------------------------");

            var action = ReadAction();
            
            IAVictoryAlways(action);
        }

        public static void PrintAndWait(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }

        public static Action ReadAction()
        {
            var isActionValid = false;
            var value = default(Action);

            while (!isActionValid)
            {
                Console.Write("Escolha Rock, Paper ou Scissor --> ");
                var choice = Console.ReadLine()?.Trim();

                isActionValid = Enum.TryParse<Action>(choice, out value);
            }

            return value;
        }

        private static void IAVictoryAlways(Action action)
        {
            switch (action)
            {
                case Action.Paper:
                    VictoryMessageIA(Action.Scissor);
                    break;
                    
                case Action.Rock:
                    VictoryMessageIA(Action.Paper);
                    break;
                    
                case Action.Scissor:
                    VictoryMessageIA(Action.Rock);
                    break;
                default:
                    Console.Write("Essa opção não existe hahaha {0}", action);
                    break;
            };
        }

        private static void VictoryMessageIA(Action action)
        {
            Console.Write("Eu escolhi {0}. Você perdeu!", action);
            Console.ReadKey();
        }
    }
}
