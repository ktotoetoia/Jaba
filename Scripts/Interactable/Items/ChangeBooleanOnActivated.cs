using UnityEngine;

public class ChangeBooleanOnActivated : MonoBehaviour, ICanBeActivated, IBoolean
{
    [SerializeField] private bool _oneTime;
    private bool _wasActive;

    [field: SerializeField] public bool Boolean { get; private set; }


    public void Activate(System.Action onCompleted)
    {
        if(_wasActive && _oneTime)
        {
            return;
        }

        Boolean = !Boolean;

        onCompleted?.Invoke();
    }
}