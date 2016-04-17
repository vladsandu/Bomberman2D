namespace RenderEngine.Animation
{
    public class SpriteSheet
    {
        protected int SpriteSizeX { get; set; }
        protected int SpriteSizeY { get; set; }
        protected int Rows { get; set; }
        protected int Cols { get; set; }
        protected int SpriteNumber { get; set; }
        protected int ImageWidth { get; set; }
        protected int ImageHeight { get; set; }

        public SpriteSheet(int spriteSizeX, int spriteSizeY, int rows, int cols, int spriteNumber)
        {
            SpriteSizeX = spriteSizeX;
            SpriteSizeY = spriteSizeY;
            Rows = rows;
            Cols = cols;
            SpriteNumber = spriteNumber;
            ImageWidth = cols*SpriteSizeX;
            ImageHeight = rows*SpriteSizeY;
        }
    }
}