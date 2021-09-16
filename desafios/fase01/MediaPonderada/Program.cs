using System;

namespace MediaPonderada
{
    class Program
    {
        private static int[] _notas = new int[3];
        
        static void Main(string[] args)
        {
            Console.Write("Insira a primeira nota ->");
            var nota1 = int.Parse(Console.ReadLine());
            
            Console.Write("Insira a segunda nota ->");
            var nota2 = int.Parse(Console.ReadLine());
            
            Console.Write("Insira a terceira nota ->");
            var nota3 = int.Parse(Console.ReadLine());

            var mediaPonderada = (nota1 + nota2 * 2 + nota3 * 3) / 6;
            Console.Write("Media com peso (1,2,3): {0}\n", mediaPonderada);
            Console.Write("Aluno passou: {0}", mediaPonderada >= 60);
        }
    }
}