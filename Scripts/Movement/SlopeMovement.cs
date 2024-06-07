using UnityEngine;

public class SlopeMovement : MonoBehaviour, ICanMove
{
    [SerializeField] private float _speed = 5;
    private Rigidbody2D _rigidbody;
    private IGroundInfo _groundInfo;
    
    public bool IsMoving { get; private set; }

    private void Start()
    {
        _groundInfo = GetComponent<IGroundInfo>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {

    }

    public void Move(float direction)
    {
        MoveWithCustomSpeed(direction, _speed);
    }

    public void MoveWithCustomSpeed(float direction, float speed)
    {
        if (_groundInfo.IsOnGround())
        {
            _rigidbody.velocity = _groundInfo.Product(new Vector2(direction, 0)).normalized * speed;
            IsMoving = direction != 0;
        }
    }
}