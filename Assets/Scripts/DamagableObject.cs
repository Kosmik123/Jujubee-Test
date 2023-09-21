using UnityEngine;

public class DamagableObject : MonoBehaviour
{
    public event System.Action OnDied;
    public event System.Action<int> OnHealthChanged;

    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private int currentHealth;

    private void Start()
    {
        FullHeal();
    }

    public void Damage(int damage)
    {
        currentHealth -= damage;
        OnHealthChanged.Invoke(-damage);        
        if (currentHealth < 0)
            OnDied?.Invoke();
    }

    public void FullHeal()
    {
        var change = maxHealth - currentHealth;
        currentHealth = maxHealth;
        OnHealthChanged?.Invoke(change);
    }
}
