using UnityEngine;

public class Key : Interactable
{
    public override void Interact(GameObject user)
    {
        user.GetComponent<Inventory>().HaveKey = true;
        base.Interact(user);
    }
}