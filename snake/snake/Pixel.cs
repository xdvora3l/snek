namespace snake
{
    class Pixel
    {
        public Pixel(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Pixel()
        {

        }

        public int X { get; set; }
        public int Y { get; set; }
        public ConsoleColor displayColor { get; set; }

        public void printPixel()
        {
            Console.SetCursorPosition(this.X, this.Y);
            Console.ForegroundColor = this.displayColor;
            Console.Write("■");
        }
    }
}
