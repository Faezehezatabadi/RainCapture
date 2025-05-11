using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject fishPrefab;
    public float spawnInterval = 1f;
    public float xRange = 8f;

    void Start()
    {
        // شروع تولید ماهی‌ها به صورت دوره‌ای
        InvokeRepeating("SpawnFish", 1f, spawnInterval);
    }

    void SpawnFish()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-xRange, xRange), 6, 0);
        GameObject fish = Instantiate(fishPrefab, spawnPos, Quaternion.identity);
    }
}
