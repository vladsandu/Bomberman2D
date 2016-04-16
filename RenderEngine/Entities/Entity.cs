using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using RenderEngine.Models;

namespace RenderEngine.Entities
{
    class Entity
    {
        public TexturedModel Model { get; set; }
        public Vector2d Position { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float RotZ { get; set; }
        public float Scale { get; set; }

        public Entity(TexturedModel model, Vector2d position)
        {
            Model = model;
            Position = position;
            Width = model.RawModel.Width;
            Height = model.RawModel.Height;
            RotZ = 0;
            Scale = 1;
        }

        public void IncreasePosition(float dx, float dy)
        {
            Vector2d.Add(Position, new Vector2d(dx, dy));
;       }

        public void IncreaseRotation(float rz)
        {
            RotZ += rz;
        }
    }
}
