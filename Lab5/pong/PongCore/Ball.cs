using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongCore
{
    [Serializable]
    public struct Vector2
    {
        public float x, y;

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2 operator+ (Vector2 a, Vector2 b)
        {
            Vector2 res = new Vector2();
            res.x = a.x + b.x;
            res.y = a.y + b.y;
            return res;
        }

        
        public static Vector2 operator- (Vector2 a, Vector2 b)
        {
            Vector2 res = new Vector2();
            res.x = a.x - b.x;
            res.y = a.y - b.y;
            return res;
        }
    }

    public class Ball
    {
        private Vector2 position, speed;

    }
}
