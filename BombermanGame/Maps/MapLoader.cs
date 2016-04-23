using System;
using System.IO;
using OpenTK;
using RenderEngine;
using RenderEngine.Entities;

namespace BombermanGame.Entities
{
    public class MapLoader
    {
        private EntityFactory EntityFactory { get; set; }

        public MapLoader(EntityFactory entityFactory)
        {
            EntityFactory = entityFactory;
        }

        public Map GenerateMap(string filePath, int tilePercentSize)
        {
            if (!File.Exists(filePath))
            {
                throw new IOException("Map: " + filePath + " could not be found.");
            }

            int xPoz = 0;
            int yPoz = 0;
            Map map = new Map();
            using (StreamReader reader = new StreamReader(filePath))
            {
                //TODO: use NLOG for logging exceptions
                while (!reader.EndOfStream)
                {
                    var position = GetPosition(xPoz, yPoz, tilePercentSize);
                           
                    var currentChar = (char) reader.Read();
                    switch (currentChar)
                    { 
                        case '.':
                            Tile dirtTile = EntityFactory.GetDirtTile(position,
                                tilePercentSize);
                            map.AddTile(dirtTile);
                            xPoz++;
                            break;
                        case '\n':
                            xPoz = 0;
                            yPoz++;
                            break;
                        case ' ':
                            Tile grassTile = EntityFactory.GetGrassTile(position,
                                tilePercentSize);
                            map.AddTile(grassTile);
                            xPoz++;
                            break;
                    }
                }
            }

            return map;
        }

        private Vector2 GetPosition(int xPoz, int yPoz, int tilePercentSize)
        {
            return new Vector2(
                xPoz*(float) tilePercentSize/50f, 
                -yPoz*(float) tilePercentSize * Game.GetAspectRatio()/50f);
        }
    }
}