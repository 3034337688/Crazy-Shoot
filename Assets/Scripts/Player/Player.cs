
using UnityEngine;

public class Player : LiveDamage
{
    public event System.Action<float, float> OnPlayerHealthChange;
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        OnPlayerHealthChange.Invoke(currentHealth, maxHealth);
    }
}
