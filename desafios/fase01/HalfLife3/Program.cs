using System;

namespace HalfLife3
{
    class Program
    {
        public static int Maxretries = 3;
        private const string CorrectAnswer = "HALF LIFE 3";
        
        static void Main(string[] args)
        {
            PrintAndWait("Olá, eu sou um gênio e posso te conceder 3 desejos....");
            PrintAndWait("Mas antes, você tem que responder uma pergunta. Você tem 3 tentativas.");
            
            CheckAwnser();
        }

        static void PrintAndWait(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }
        
        static string ReadInput()
        {
            Console.Write("Qual é o melhor jogo do Universo?!");
            return Console.ReadLine();
        }

        static void WinGame()
        {
            PrintAndWait($"PARABÉMS!!! VOCÊ ACERTOU MISÉRAVEL! HAHAHA {CorrectAnswer}");
        }

        static void LossPoint(int retries)
        {
            switch (retries)
            {
                case 3: 
                    Console.WriteLine("Resposta errada! Você tem 2 tentativas!");
                    break;
                case 2:
                    Console.WriteLine("Resposta errada! Sua bata está assando!");
                    break;
                case 1:
                    Console.WriteLine("Você não sabe de nada mesmo... Vou procurar alguém que entende de jogos!");
                    break;
            }
        }

        static void CheckAwnser()
        {
            var contador = 3;
            bool isCorrectAwnser = false;

            while (!isCorrectAwnser && contador >= 1)
            {
                var awnser = ReadInput();

                if (awnser.Trim().ToUpper() is not CorrectAnswer)
                {
                    LossPoint(contador);
                    contador--;
                    continue;
                }
                isCorrectAwnser = true;
                WinGame();
            }

            Console.ReadKey();
        }
    }
}