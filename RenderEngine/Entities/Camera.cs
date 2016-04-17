using OpenTK;

namespace RenderEngine.Entities
{
    public class Camera
    {
        private Vector3 _position = new Vector3(0, 0, 0);
        private float _distanceFromScreen;

        public Camera(Vector3 position, float distanceFromScreen)
        {
            this._position = position;
            this._distanceFromScreen = distanceFromScreen;
        }

        public Vector3 GetPosition()
        {
            return _position;
        }

        public void IncreasePosition(float x, float y)
        {
            this._position.X += x;
            this._position.Y += y;
        }

        public void SetPosition(Vector3 position)
        {
            this._position = position;
        }

        public float GetDistanceFromScreen()
        {
            return _distanceFromScreen;
        }

        public void SetDistanceFromScreen(float distanceFromScreen)
        {
            this._distanceFromScreen = distanceFromScreen;
        }
    }
}