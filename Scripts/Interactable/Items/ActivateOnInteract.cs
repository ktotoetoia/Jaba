using UnityEngine;
using AYellowpaper;

public class ActivateOnInteract : Interactable
{
    [SerializeField] private InterfaceReference<ICanBeActivated> _toActivate;

    public override void Interact(GameObject user)
    {
        _toActivate.Value.Activate(() => { });
        base.Interact(user);
    }
}