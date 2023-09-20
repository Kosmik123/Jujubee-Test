using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField]
    private EnemyController enemyTemplate;
    [SerializeField]
    private List<EnemyController> enemies;
    [SerializeField]
    private float spawnDistance;
    [SerializeField]
    private Transform player;

    private void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = GetSpawnPosition();
        var enemy = Instantiate(enemyTemplate, spawnPosition, Quaternion.identity, transform);
        enemy.Target = player;  
        enemy.OnDied += Enemy_OnDied;
        enemies.Add(enemy);
    }

    private Vector3 GetSpawnPosition()
    {
        float angle = Random.Range(-180, 180);
        Vector3 offset = Quaternion.AngleAxis(angle, Vector3.up) * Vector3.forward * Random.Range(spawnDistance - 1, spawnDistance + 1);
        Vector3 spawnPosition = transform.position + offset;
        return spawnPosition;
    }

    private void Enemy_OnDied(DamagableObject enemy)
    {
        if (enemies[enemies.Count - 1].DamagableObject == enemy)
            Invoke(nameof(SpawnEnemy), 5);
        enemy.transform.position = GetSpawnPosition();
        enemy.FullHeal();
    }

    private void OnDestroy()
    {
        foreach (var enemy in enemies)
            enemy.OnDied -= Enemy_OnDied;
    }
}
