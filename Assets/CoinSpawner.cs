using Unity.VisualScripting;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] GameObject coinPrefab;
    [SerializeField] float spawnCooldown = 2;
    float cooldown;
    [SerializeField] int maxCoins;
    int currentCoins;

    [SerializeField] Collider spawnZone;
    // Update is called once per frame
    void Update()
    {
        cooldown = cooldown - Time.deltaTime;
        
        if (cooldown <= 0 && currentCoins <= maxCoins)
        {
            var spawnPos = new Vector3(Random.Range(spawnZone.bounds.min.x, spawnZone.bounds.max.x), -0.8f,
                Random.Range(spawnZone.bounds.min.z, spawnZone.bounds.max.z));
            Instantiate(coinPrefab, spawnPos, coinPrefab.transform.rotation);
            currentCoins++;
        }
    }
}
