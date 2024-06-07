public interface ICanMove
{
    bool IsMoving { get; }

    void Move(float direction);
}

public interface ICanJumpInDirection
{
    void Jump(float direction, float power);
    bool TryJump(float direction, float power);
}