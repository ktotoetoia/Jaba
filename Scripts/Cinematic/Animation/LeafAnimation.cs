using UnityEngine;

public class LeafAnimation : MonoBehaviour
{
    private const string Down = "Down";
    private const string Up = "Up";

    private ThrowOnTriggerEnter _throw;
    private Animator _animator;

    void Start()
    {
        _throw = GetComponent<ThrowOnTriggerEnter>();
        _animator = GetComponent<Animator>();

        _throw.Throwed += () => _animator.SetTrigger(Up);
        _throw.Entered += () => _animator.SetTrigger(Down);
    }
}