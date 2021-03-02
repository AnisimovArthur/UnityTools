using UnityEngine;

namespace UnityTools
{
    public static partial class GizmosPro
    {
        public static void DrawWireCircle(Vector3 center, Vector3 direction, float radius, Color color, int segments = 36)
        {
            Gizmos.color = color;
            DrawWireCircle(center, direction, radius, segments);
        }

        public static void DrawWireCircle(Vector3 center, Vector3 direction, float radius, int segments = 36)
        {
            Vector3 up = ((direction == Vector3.zero) ? Vector3.up : direction).normalized;
            Vector3 forward = Vector3.Slerp(up, -up, 0.5f);
            Vector3 right = Vector3.Cross(up, forward).normalized;

            Matrix4x4 matrix = new Matrix4x4();

            matrix[0] = right.x;
            matrix[1] = right.y;
            matrix[2] = right.z;

            matrix[4] = up.x;
            matrix[5] = up.y;
            matrix[6] = up.z;

            matrix[8] = forward.x;
            matrix[9] = forward.y;
            matrix[10] = forward.z;

            Vector3 lastPoint = center + matrix.MultiplyPoint3x4(new Vector3(Mathf.Cos(0) * radius, 0, Mathf.Sin(0) * radius));
            Vector3 nextPoint = Vector3.zero;

            for (var i = 0; i < segments + 1; i++)
            {
                float angle = 360f / segments * i;

                nextPoint.x = Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
                nextPoint.z = Mathf.Sin(angle * Mathf.Deg2Rad) * radius;
                nextPoint.y = 0;
                nextPoint = center + matrix.MultiplyPoint3x4(nextPoint);

                Gizmos.DrawLine(lastPoint, nextPoint);
                lastPoint = nextPoint;
            }
        }
    }
}
