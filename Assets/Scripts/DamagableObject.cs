using UnityEngine;

public class DamagableObject : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;    
    }

    public void Damage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
            Destroy(gameObject);
    }
}
