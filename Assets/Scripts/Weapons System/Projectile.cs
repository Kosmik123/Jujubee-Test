using UnityEngine;

public class Projectile : MonoBehaviour
{
    public event System.Action<Projectile> OnMaxDistanceTraveled;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float maxDistance;
    private float currentDistance;
    
    public void Shoot()
    {
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
}
