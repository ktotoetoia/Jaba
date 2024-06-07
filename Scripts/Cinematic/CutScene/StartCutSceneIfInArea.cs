using UnityEngine;

public class StartCutSceneIfInArea : MonoBehaviour
{
    [SerializeField] private Transform _activator;
    [SerializeField] private Vector2 _extents;
    [SerializeField] private bool _drawGizmos;
    private ICutScene _cutScene;

    [field: SerializeField] public bool IsActive { get; set; } = true;

    private void Start()
    {
        _cutScene = GetComponent<ICutScene>();
    }

    private void Update()
    {
        if (_activator.position.IsInside(transform.position, _extents) && IsActive)
        {
            _cutScene.StartCutScene();
            IsActive = false;
        }
    }

    private void OnDrawGizmos()
    {
        if (_drawGizmos)
        {
            Gizmos.DrawWireCube(transform.position, _extents * 2);
        }
    }
}