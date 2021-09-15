using System;
using System.Collections.Generic;
using System.Linq;

namespace BluePokemonDialog
{
    public class BluePokemonDialog
    {
        private Queue<string> _messages;
        private Queue<string> _questions;
        private Queue<string> _awnsers;
        private int _indexGetName;
        private string _nickName;

        public BluePokemonDialog()
        {
            _messages = new Queue<string>();

            _messages.Enqueue("Olá Pessoal! Bem vindos ao mundo do Pokémon!");
            _messages.Enqueue("Sou Cavarlho. Pode me chamar de POKÈMON PROF!");
            _messages.Enqueue("Esse mundo é habitado por seres chamados Pokémon");
            _messages.Enqueue("Pessoas usam Pokémons para cuidar ou em confrontos");
            _messages.Enqueue("Já eu...");
            _messages.Enqueue("Estudo Pokemons como profissão.\n");
            _messages.Enqueue("-------------------------------");

            _questions = new Queue<string>();
            
            _questions.Enqueue("Primeiro, qual é o seu nome? --> ");
            _questions.Enqueue("Apresento o meu neto. Ele é seu rival desde que vocês nasceram\n... Eu esqueci o nome do rapaz! você pode me lembrar? -->");

            _awnsers = new Queue<string>();

            _awnsers.Enqueue("Tudo bem! Seu nome é: {0}");
            _awnsers.Enqueue("Claro! Eu me lembro agora! O nome dele é: {0}");
            _indexGetName = 0;
        }
        
        public void Start()
        {
            while (_messages.Any())
            {
                Console.WriteLine(_messages.Dequeue());
                Console.ReadKey();
            }

            IList<string> privateAwnsers = new List<string> {};
            
            while (_questions.Any())
            {
                Console.WriteLine(_questions.Dequeue());
                var response = Console.ReadLine();
                privateAwnsers.Add(response);
                Console.WriteLine(_awnsers.Dequeue(), response?.Trim());
                Console.WriteLine("\n-----------------------------------------");
            }

            Console.WriteLine("{0}!", privateAwnsers.First());
        }
    }
}