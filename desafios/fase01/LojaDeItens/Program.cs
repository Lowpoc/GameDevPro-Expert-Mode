namespace LojaDeItens
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = new Player(5);
            var merchant = new Merchant(player);
            merchant.OpenStore();
        }
    }
}