using OpenTK;

namespace RenderEngine.Entities
{
    public class Camera
    {
        private Vector3 position = new Vector3(0, 0, 0);
        private float distanceFromScreen;

        public Camera(Vector3 position, float distanceFromScreen)
        {
            this.position = position;
            this.distanceFromScreen = distanceFromScreen;
        }

        public Vector3 getPosition()
        {
            return position;
        }

        public void increasePosition(float x, float y)
        {
            this.position.X += x;
            this.position.Y += y;
        }

        public void setPosition(Vector3 position)
        {
            this.position = position;
        }

        public float getDistanceFromScreen()
        {
            return distanceFromScreen;
        }

        public void setDistanceFromScreen(float distanceFromScreen)
        {
            this.distanceFromScreen = distanceFromScreen;
        }
    }
}