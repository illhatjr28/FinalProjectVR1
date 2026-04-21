using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [Header("Monster Library")]
    public GameObject[] monsterPrefabs; // Drag your monster prefabs here

    [Header("Spawn Settings")]
    public int totalToSpawn = 10;
    public float spawnRadius = 20f;
    public bool spawnOnStart = true;

    void Start()
    {
        if (spawnOnStart)
        {
            SpawnMonsters();
        }
    }

    public void SpawnMonsters()
    {
        for (int i = 0; i < totalToSpawn; i++)
        {
            // 1. Pick a random monster from the array
            int randomIndex = Random.Range(0, monsterPrefabs.Length);
            GameObject monsterToSpawn = monsterPrefabs[randomIndex];

            // 2. Pick a random position within a circle
            Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
            Vector3 spawnPos = new Vector3(
                transform.position.x + randomCircle.x,
                transform.position.y,
                transform.position.z + randomCircle.y
            );

            // 3. Create the monster in the scene
            Instantiate(monsterToSpawn, spawnPos, Quaternion.identity);
        }
    }
}