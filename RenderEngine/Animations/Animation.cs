using RenderEngine.Animations;

namespace RenderEngine.Animations
{
    public class Animation
    {
        public SpriteSheet SpriteSheet { get; set; }
        private int NeededFrameCount { get; set; }
        private int CurrentFrameCount { get; set; }
        public int CurrentSpriteNumber { get; set; }

        public Animation(SpriteSheet spriteSheet, int animationSpeedMilis, int fps)
        {
            SpriteSheet = spriteSheet;
            NeededFrameCount = animationSpeedMilis * fps / 1000;
        }

        public void IncreaseFrameCount()
        {
            CurrentFrameCount += 1;
            if (CurrentFrameCount == NeededFrameCount)
            {
                CurrentFrameCount = 0;
                IncreaseSpriteNumber();
            }
        }

        private void IncreaseSpriteNumber()
        {
            CurrentSpriteNumber += 1;
            if (SpriteSheet.SpriteNumber == CurrentSpriteNumber)
                CurrentSpriteNumber = 0;
        }

        public bool IsNewSprite()
        {
            return CurrentFrameCount == 0;
        }
    }
}