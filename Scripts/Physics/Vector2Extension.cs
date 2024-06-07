using UnityEngine;

public static class VectorExtension
{
    public static float GetDegreesOfNormal(this Vector2 normal)
    {
        return Mathf.Atan2(Mathf.Abs(normal.x), Mathf.Abs(normal.y)) * Mathf.Rad2Deg;
    }

    public static bool IsInside(this Vector2 position, Vector2 center, Vector2 extents)
    {
        float left = center.x - extents.x;
        float right = center.x + extents.x;
        float bottom = center.y - extents.y;
        float top = center.y + extents.y;

        return position.x >= left && position.x <= right && position.y >= bottom && position.y <= top;
    }

    public static bool IsInside(this Vector3 position, Vector3 center, Vector3 extents)
    {
        float left = center.x - extents.x;
        float right = center.x + extents.x;
        float bottom = center.y - extents.y;
        float top = center.y + extents.y;
        float back = center.z - extents.z;
        float front = center.z + extents.z;

        return position.x >= left && position.x <= right
            && position.y >= bottom && position.y <= top
            && position.z >= back && position.z <= front;
    }
}