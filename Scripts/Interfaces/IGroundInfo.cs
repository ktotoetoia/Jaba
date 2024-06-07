using UnityEngine;

public interface IGroundInfo
{
    bool IsOnGround();
    Vector2 Product(Vector2 direction);
    Vector2 GetNormal(Vector2 direction);
    Vector2 GetAverageGroundNormal();
    public void IgnoreGround(int frameCount);
}