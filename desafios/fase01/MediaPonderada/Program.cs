using System;

namespace MediaPonderada
{
    class Program
    {
        private static int[] _notas = new int[3];
        
        static void Main(string[] args)
        {
            Console.Write("Insira a primeira nota ->");
            int.TryParse(Console.ReadLine(), out var nota1);
            
            Console.Write("Insira a segunda nota ->");
            int.TryParse(Console.ReadLine(), out var nota2);
            
            Console.Write("Insira a terceira nota ->");
            int.TryParse(Console.ReadLine(), out var nota3);

            var mediaPonderada = (float) (nota1 + nota2 * 2 + nota3 * 3) / 6;
            Console.Write("Media com peso (1,2,3): {0}\n", mediaPonderada);
            Console.Write("Aluno passou: {0}", mediaPonderada >= 60);
        }
    }
}