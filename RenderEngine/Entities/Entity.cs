using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace RenderEngine.Entities
{
    class Entity
    {
        public Vector2d Position { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float RotZ { get; set; }
        public float Scale { get; set; }

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
