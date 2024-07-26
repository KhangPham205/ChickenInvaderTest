using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Wave4 : MonoBehaviour
{
    public GameObject chickenPrefab;
    public float spawnRate = 1f;
    private int i = 0;

    private float spawnTimer = 0f;

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnRate && i < 3)
        {
            spawnTimer = 0f;

            GameObject chicken = Instantiate(chickenPrefab, transform.position, Quaternion.identity);
            i++;
            //chicken.GetComponent<AudioSource>().Play();
        }
    }
}
