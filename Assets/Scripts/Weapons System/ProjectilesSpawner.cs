using UnityEngine;

public class ProjectilesSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform projectilesContainer;

    public Projectile SpawnProjectile(Projectile template, Transform origin)
    {
        var projectile = Instantiate(template, origin.position, origin.rotation, projectilesContainer);
        return projectile;
    }
}
