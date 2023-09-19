using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using static UnityEngine.UI.Image;

public class ProjectilesSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform projectilesContainer;

    private readonly Dictionary<Projectile, ObjectPool<Projectile>> poolsByPrefab = new Dictionary<Projectile, ObjectPool<Projectile>>(); 

    public Projectile SpawnProjectile(Projectile template, Transform origin)
    {
        if (poolsByPrefab.TryGetValue(template, out var pool) == false)
        {
            pool = new ObjectPool<Projectile>(() => Instantiate(template, projectilesContainer));
            poolsByPrefab.Add(template, pool);
        }

        var projectile = pool.Get();
        projectile.transform.SetPositionAndRotation(origin.position, origin.rotation);
        return projectile;
    }
}
