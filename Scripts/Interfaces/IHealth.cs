using System;

public interface IHealth
{
    event Action<float> OnHealthChanged;
    float Health { get; }
    float MaxHealth { get; }
    void AddHealth(float amount);
}