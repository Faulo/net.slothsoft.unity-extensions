using System;
using UnityEngine;

namespace Slothsoft.UnityExtensions {
    public static class Vector3Extensions {
        public static void Deconstruct(this Vector3 vector, out float x, out float y, out float z) {
            x = vector.x;
            y = vector.y;
            z = vector.z;
        }

        public static Vector3 WithX(this Vector3 vector, float x) => new(x, vector.y, vector.z);
        public static Vector3 WithY(this Vector3 vector, float y) => new(vector.x, y, vector.z);
        public static Vector3 WithZ(this Vector3 vector, float z) => new(vector.x, vector.y, z);

        public static Vector2 SwizzleXY(this Vector3 vector) => new(vector.x, vector.y);
        public static Vector2 SwizzleXZ(this Vector3 vector) => new(vector.x, vector.z);
        public static Vector2 SwizzleYZ(this Vector3 vector) => new(vector.y, vector.z);

        [Obsolete("RoundToInt extension method is obsolete, use Vector3Int.RoundToInt instead.")]
        public static Vector3Int RoundToInt(this Vector3 vector) => new(
            Mathf.RoundToInt(vector.x),
            Mathf.RoundToInt(vector.y),
            Mathf.RoundToInt(vector.z)
        );

        public static Vector3Int SnapToCardinal(this Vector3 direction) {
            float x = Math.Abs(direction.x);
            float y = Math.Abs(direction.y);
            float z = Math.Abs(direction.z);
            if (Mathf.Approximately(x, y) && Mathf.Approximately(y, z)) {
                return Vector3Int.zero;
            }

            if (x > y && x > z) {
                return new Vector3Int(1, 0, 0) * Math.Sign(direction.x);
            }

            if (y > x && y > z) {
                return new Vector3Int(0, 1, 0) * Math.Sign(direction.y);
            }

            if (z > x && z > y) {
                return new Vector3Int(0, 0, 1) * Math.Sign(direction.z);
            }

            return Vector3Int.zero;
        }
    }
}