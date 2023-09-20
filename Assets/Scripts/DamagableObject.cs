using UnityEngine;

public class DamagableObject : MonoBehaviour
{
    public event System.Action OnDied;

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
        if (currentHealth < 0)
            OnDied?.Invoke();
    }

    public void FullHeal()
    {
        currentHealth = maxHealth;
    }
}
