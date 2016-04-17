namespace RenderEngine.Animation
{
    public class Animation
    {
        public SpriteSheet SpriteSheet { get; set; }
        private int NeededFrameCount { get; set; }
        private double CurrentFrameCount { get; set; }
        private int CurrentSpriteNumber { get; set; }

        public Animation(SpriteSheet spriteSheet, int animationSpeedMilis, int fps)
        {
            SpriteSheet = spriteSheet;
            NeededFrameCount = animationSpeedMilis * fps / 1000;
        }
    }
}