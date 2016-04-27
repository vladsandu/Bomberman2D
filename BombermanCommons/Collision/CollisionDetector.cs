using System;
using RenderEngine.Entities;
using BombermanCommons.Entities;

namespace BombermanCommons.Collision
{
    public class CollisionDetector
    {
        private CurrentData CurrentData { get; set; }

        public CollisionDetector(CurrentData currentData)
        {
            CurrentData = currentData;
        }

        public bool IsCollidingMap(CollisionBox collisionBox)
        {
            MapRegion currentRegion = GetCurrentMapRegion(collisionBox);
            if (currentRegion == null)
                return false;
            foreach (Tile tile in currentRegion.Tiles)
            {
                if (!tile.Walkable && tile.CollisionBox.Intersects(collisionBox))
                    return true;
            }
            return false;
        }

        public bool IsCollidingExplosions(Player player)
        {
            foreach (Explosion explosion in CurrentData.Explosions)
            {
                if (explosion.CollisionBox.Intersects(player.CollisionBox))
                {
                    return true;
                }
            }
            return false;
        }

        private MapRegion GetCurrentMapRegion(CollisionBox collisionBox)
        {
            foreach (MapRegion region in CurrentData.Map.Regions)
            {
                if (region.Contains(collisionBox))
                    return region;
            }
            return null;
        }
    }
}