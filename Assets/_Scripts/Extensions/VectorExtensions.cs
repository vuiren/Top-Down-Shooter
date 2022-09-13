
using UnityEngine;

namespace Client.Extensions
{
    public static class VectorExtensions
    {
        public static Vector2 Vector2(this Vector3 vector3)
        {
            return new Vector2(vector3.x, vector3.y);
        }

        public static Vector2 Rotate90Clockwise(this Vector2 vector2)
        {
            return new Vector2(vector2.y, -vector2.x);
        }

        public static Vector2 Rotate90AntiClockwise(this Vector2 vector2)
        {
            return new Vector2(-vector2.y, vector2.x);
        }

        public static Vector3Int Vector3Int(this Vector2Int vector2)
        {
            return new Vector3Int(vector2.x, vector2.y, 0);
        }

        public static Vector2Int Vector2Int(this Vector3Int vector3Int)
        {
            return new Vector2Int(vector3Int.x, vector3Int.y);
        }
    }
}