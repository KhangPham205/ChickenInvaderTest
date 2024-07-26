using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownChicken : ChickenInfo
{
    int Random_Number;
    int Min_Rand = 0; int Max_Rand = 10000;
    public GameObject eggPrefab;
    void Update()
    {
        if (health <= 0)
            Die();
        // Tạo trứng (của Bngyl)
        if (Time.timeScale == 1) Random_Number = Random.Range(Min_Rand, Max_Rand);
        if (Random_Number == 1)
        {
            GameObject egg = Instantiate(eggPrefab, transform.position, Quaternion.identity);
        }
    }
}
