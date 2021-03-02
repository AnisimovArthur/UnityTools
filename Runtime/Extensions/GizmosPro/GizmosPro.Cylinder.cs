using UnityEngine;

namespace UnityTools
{
    public static partial class GizmosPro
    {
        public static void DrawWireCylinder(Vector3 center, Vector3 direction, float radius, float height, Color color, int sideLines = 4, int circles = 0, int segments = 36)
        {
            Gizmos.color = color;
            DrawWireCylinder(center, direction, radius, height, sideLines, circles, segments);
        }

        public static void DrawWireCylinder(Vector3 center, Vector3 direction, float radius, float height, int sideLines = 4, int circles = 0, int segments = 36)
        {
            Vector3 up = direction.normalized;
            Vector3 forward = Vector3.Slerp(up, -up, 0.5f);
            Vector3 right = Vector3.Cross(up, forward).normalized;

            Vector3 start = center - up * height / 2;
            Vector3 end = center + up * height / 2;

            DrawWireCircle(start, up, radius, segments);
            DrawWireCircle(end, up, radius, segments);

            for (int i = 0; i < sideLines; i++)
            {
                float angle = 360.0f / sideLines * i;
                Vector3 offset = Quaternion.AngleAxis(angle, up) * right * radius;
                Gizmos.DrawLine(start + offset, end + offset);
            }

            for (int i = 0; i < circles; i++)
            {
                float distance = height / (circles + 1) * (i + 1);
                DrawWireCircle(start + up * distance, up, radius, segments);
            }
        }
    }
}
