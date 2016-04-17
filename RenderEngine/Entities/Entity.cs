using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using RenderEngine.Models;

namespace RenderEngine.Entities
{
    public class Entity
    {
        public TexturedModel Model { get; set; }
        public Vector2 Position { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float RotZ { get; set; }
        public float Scale { get; set; }
        public int Layer { get; set; }
        public float XOffset { get; set; }
        public float YOffset { get; set; }

        public Entity(TexturedModel model, Vector2 position, int layer)
        {
            Model = model;
            Position = position;
            Width = model.RawModel.Width;
            Height = model.RawModel.Height;
            Layer = layer;
            RotZ = 0;
            Scale = 1;
        }

        public void IncreasePosition(float dx, float dy)
        {
            Position = Vector2.Add(Position, new Vector2(dx, dy));
;       }

        public void IncreaseRotation(float rz)
        {
            RotZ += rz;
        }
    }
}
