using System;
using UnityEngine;

public class StartParticleSystemOnActivated : MonoBehaviour, ICanBeActivated
{
    [SerializeField] private ParticleSystem _particleSystem;

    private void Start()
    {
        _particleSystem.Stop();
    }

    public void Activate(Action onCompleted)
    {
        _particleSystem.Play();
        
        onCompleted?.Invoke();
    }
}