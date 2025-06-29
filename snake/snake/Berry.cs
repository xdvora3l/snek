
namespace snake
{
    class Berry : Pixel
    {

        private Random randomNumber = new Random();
        static int game_Width = 32;
        static int game_Height = 16;

        public Berry(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.displayColor = ConsoleColor.Cyan;
        }

        public Berry()
        {
            this.X = this.randomNumber.Next(0, game_Width - 2);
            this.Y = this.randomNumber.Next(0, game_Height - 2);
            this.displayColor = ConsoleColor.Cyan;
        }


        public void MoveBerry()
        {
            this.X = this.randomNumber.Next(0, game_Width - 2);
            this.Y = this.randomNumber.Next(0, game_Height - 2);
        }
    }
}
