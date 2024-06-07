using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void Update()
    {
        transform.position = (Vector2)_target.position;
    }
}