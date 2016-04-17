namespace RenderEngine.Animations
{
    public class SpriteSheet
    {
        internal float SpriteSizeX { get; set; }
        internal float SpriteSizeY { get; set; }
        internal int Rows { get; set; }
        internal int Cols { get; set; }
        internal int SpriteNumber { get; set; }
        internal float ImageWidth { get; set; }
        internal float ImageHeight { get; set; }

        public SpriteSheet(float spriteSizeX, float spriteSizeY, int rows, int cols, int spriteNumber)
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