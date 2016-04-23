namespace RenderEngine.Animations
{
    public class SpriteSheet
    {
        public float SpriteSizeX { get; set; }
        public float SpriteSizeY { get; set; }
        public int Rows { get; set; }
        public int Cols { get; set; }
        public int SpriteNumber { get; set; }
        public float ImageWidth { get; set; }
        public float ImageHeight { get; set; }

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