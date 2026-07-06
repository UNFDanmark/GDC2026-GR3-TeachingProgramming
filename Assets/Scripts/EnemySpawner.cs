using System;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnCooldown = 5;
    float timeLeft;
    void Update()
    {
        timeLeft = timeLeft - Time.deltaTime;
        if (timeLeft <= 0)
        {
            Spawn();
            timeLeft = spawnCooldown;
        }
    }

    void Spawn()
    {
        var spawnPos = transform.position;
        spawnPos.x = spawnPos.x + Random.Range(-2, 3);
        spawnPos.z = spawnPos.z + Random.Range(-2, 3);
        Instantiate(enemyPrefab, spawnPos, quaternion.identity);
    }
}
