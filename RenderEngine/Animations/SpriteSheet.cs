namespace RenderEngine.Animations
{
    public class SpriteSheet
    {
        internal int SpriteSizeX { get; set; }
        internal int SpriteSizeY { get; set; }
        internal int Rows { get; set; }
        internal int Cols { get; set; }
        internal int SpriteNumber { get; set; }
        internal int ImageWidth { get; set; }
        internal int ImageHeight { get; set; }

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