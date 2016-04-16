namespace RenderEngine.Models
{
    public class RawModel
    {
        public int VaoID { get; set; }
        public int VertexCount { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        public RawModel(int vaoId, int vertexCount, float width, float height)
        {
            VaoID = vaoId;
            VertexCount = vertexCount;
            Width = width;
            Height = height;
        }
    }
}