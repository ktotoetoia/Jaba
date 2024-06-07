using UnityEngine;

public class InputAdaptor : MonoBehaviour
{
    [SerializeField] private float _timeToGetMaxPowerInSec = 0.5f;
    private Interactor _interactor;
    private ICanMove _canMove;
    private ICanJumpInDirection _canJump;

    public float Horizontal { get; set; }
    public float JumpPower { get; set; }
    public bool Jumped { get; set; }
    public bool Interact { get; set; }

    private void Start()
    {
        _interactor = GetComponent<Interactor>();
        _canMove = GetComponent<ICanMove>();
        _canJump = GetComponent<ICanJumpInDirection>();
    }

    private void Update()
    {
        if(Interact)
        {
            _interactor.Interact();
            Interact = false;
        }
    }

    private void FixedUpdate()
    {
        _canMove.Move(Horizontal);

        if (Jumped)
        {
            JumpPower = Mathf.Clamp(JumpPower,0, _timeToGetMaxPowerInSec);
            _canJump.TryJump(Horizontal, JumpPower / _timeToGetMaxPowerInSec);

            Jumped = false;
            JumpPower = 0;
        }
    }
}