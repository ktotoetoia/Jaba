using UnityEngine;

public class DebugLogOnActivated : MonoBehaviour, ICanBeActivated
{
    [SerializeField] private string _text;

    public void Activate(System.Action onCompleted)
    {
        Debug.Log(_text);

        onCompleted?.Invoke();
    }
}