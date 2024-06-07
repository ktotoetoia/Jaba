using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
    public event System.Action<float> OnHealthChanged;
    [field: SerializeField] public float Health { get; private set; }
    [field: SerializeField] public float MaxHealth { get; private set; }
    public void AddHealth(float amount)
    {
        Health += amount;
        Health = Mathf.Clamp(Health, 0, MaxHealth);

        OnHealthChanged?.Invoke(Health);
    }
}