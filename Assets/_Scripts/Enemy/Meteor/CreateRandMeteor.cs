using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRandMeteor : MonoBehaviour
{
    [SerializeField] private GameObject[] meteorPrefabs; // Array to hold meteor prefabs (small, medium, big)
    [SerializeField] private float spawnRate = 2.0f; // Rate of meteor spawning (seconds)

    private float nextSpawnTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnMeteor();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    private void SpawnMeteor()
    {
        // Choose a random meteor prefab (small, medium, or big)
        int randomIndex = Random.Range(0, meteorPrefabs.Length);
        GameObject meteorPrefab = meteorPrefabs[randomIndex];

        // Create a new meteor GameObject from the prefab
        GameObject meteor = Instantiate(meteorPrefab, transform.position, Quaternion.identity);
    }
}