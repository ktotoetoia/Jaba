using UnityEngine;

public class RotateToTheGround : MonoBehaviour
{
    [SerializeField] private GroundInfo _groundInfo;

    private void Update()
    {
        Vector2 normal = _groundInfo.GetAverageGroundNormal();

        transform.rotation = Quaternion.FromToRotation(Vector2.up, normal);
    }
}
