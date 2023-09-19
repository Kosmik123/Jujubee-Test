using UnityEngine;

public class ProjectilesSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform projectilesContainer;

    public Projectile SpawnProjectile(Projectile template)
    {
        var projectile = Instantiate(template, projectilesContainer);
        return projectile;
    }
}
