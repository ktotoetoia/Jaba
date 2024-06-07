using UnityEngine;

public class ChangeBooleanOnInteract : Interactable, IBoolean
{
    [field: SerializeField] public bool Boolean { get; private set; }

    public override void Interact(GameObject user)
    {
        Boolean = !Boolean;
        base.Interact(user);
    }
}