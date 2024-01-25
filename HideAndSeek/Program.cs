namespace HideAndSeek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameController gameController = new GameController();
            Console.WriteLine(gameController.Status);
            Console.WriteLine(gameController.Prompt);
            Console.WriteLine(gameController.ParseInput(Console.ReadLine()));
        }
    }
}
