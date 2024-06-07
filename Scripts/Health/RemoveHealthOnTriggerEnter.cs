using UnityEngine;

public class RemoveHealthOnTriggerEnter : MonoBehaviour
{
    [SerializeField] private float _amount; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out IHealth health))
        {
            RemoveHealth(health);
        }
    }

    private void RemoveHealth(IHealth health)
    {
        health.AddHealth(-_amount);
    }
}