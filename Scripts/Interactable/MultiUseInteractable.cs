using UnityEngine;
using AYellowpaper;

public class MultiUseInteractable : Interactable
{
    [SerializeField] private InterfaceReference<ICanBeActivated> _activateEachInteraction;
    [SerializeField] private InterfaceReference<ICanBeActivated> _activateOnFinish;
    [SerializeField] private int _maxInteractions;
    private int _interactionsCount;
    private bool _canInteract = true;

    public override void Interact(GameObject user)
    {
        _interactionsCount++;
        if(_activateEachInteraction.Value != null)
        {
            _canInteract = false;

            _activateEachInteraction.Value.Activate(() => _canInteract = true);
        }

        if (_interactionsCount == _maxInteractions)
        {
            _activateOnFinish.Value.Activate(() => { });
        }
    }

    public override bool IsAvailable()
    {
        return _canInteract && _interactionsCount < _maxInteractions;
    }
}