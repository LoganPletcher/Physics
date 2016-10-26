using System;

namespace Logan
{
    public class Agent
    {
        public struct Vector3
        {
            public float x, y, z;
            public Vector3(float x, float y, float z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
        }
        public Vector3 Norm(Vector3 x)
        {
            float e = ((x.x * x.x) + (x.y * x.y) + (x.z * x.z));
            float d = (float)Math.Sqrt(e);
            float q = x.x / d;
            float w = x.y / d;
            float t = x.z / d;
            Vector3 c = new Vector3(q, w, t);
            return c;
        }
        public Vector3 Position = new Vector3(0, 0, 0);
        public Vector3 Velocity = new Vector3(0, 0, 1);
        public float Mass = 10.0f;
        public Agent()
        {
            Position = new Vector3(0, 0, 0);
            Velocity = new Vector3(0, 0, 1);
            Mass = 10.0f;
        }
    }
}