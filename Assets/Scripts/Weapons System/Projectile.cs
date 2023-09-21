using UnityEngine;

public class Projectile : MonoBehaviour
{
    public event System.Action<Projectile> OnMaxDistanceTraveled;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float maxDistance;
    private float currentDistance;

    private int damage;

    public void Shoot(int damage)
    {
        this.damage = damage;
        enabled = true;
        currentDistance = 0;
    }

    private void Update()
    {
        float distanceThisFrame = speed * Time.deltaTime;
        transform.Translate(distanceThisFrame * Vector3.forward);
        currentDistance += distanceThisFrame;
        if (currentDistance > maxDistance)
            OnMaxDistanceTraveled.Invoke(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var damagable = collision.gameObject.GetComponentInParent<DamagableObject>();
        if (damagable)
        {
            damagable.Damage(damage);
            OnMaxDistanceTraveled.Invoke(this);
        }
    }
}
