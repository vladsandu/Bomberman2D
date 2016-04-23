using System;
using BombermanGame.Entities;

namespace BombermanGame.Collision
{
    public class CollisionDetector
    {
        private CurrentData CurrentData { get; set; }

        public CollisionDetector(CurrentData currentData)
        {
            CurrentData = currentData;
        }

        public bool IsLocalPlayerColliding()
        {
            MapRegion currentRegion = GetCurrentMapRegion();
            if (currentRegion == null)
                return false;
            foreach (Tile tile in currentRegion.Tiles)
            {
                if (!tile.Walkable && tile.CollisionBox.Intersects(CurrentData.LocalPlayer.CollisionBox))
                    return true;
            }
            return false;
        }

        private MapRegion GetCurrentMapRegion()
        {
            foreach (MapRegion region in CurrentData.Map.Regions)
            {
                if (region.Contains(CurrentData.LocalPlayer.Position))
                    return region;
            }
            return null;
        }
    }
}