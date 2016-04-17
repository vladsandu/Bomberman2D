namespace BombermanGame.Maps
{
    public class MapLoader
    {
        private EntityFactory EntityFactory { get; set; }

        public MapLoader(EntityFactory entityFactory)
        {
            EntityFactory = entityFactory;
        }
    }
}