using UnityEngine;

public class Lock : Interactable
{
    private Inventory _inventory;

    protected override void Start()
    {
        _inventory = FindFirstObjectByType<Inventory>();
        base.Start();
    }

    public override void Interact(GameObject user)
    {
        Destroy(gameObject);
        base.Interact(user);
    }

    public override bool IsAvailable()
    {
        return _inventory.HaveKey;
    }
}