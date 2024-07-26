using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenMove_W3 : ChickenInfo
{
    // Tốc độ di chuyển của object
    public float speed = 2f;

    public GameObject eggPrefab;

    // Số random của bngyl
    private int Random_Number;
    public int Number_Spawn = 1;
    public int Min_Rand = 1;
    public int Max_Rand = 10000;


    void Start()
    {
        
    }

    void Update()
    {
        // Tạo trứng (của Bngyl)
        if( Time.timeScale == 1) Random_Number = Random.Range(Min_Rand, Max_Rand);
        if (Random_Number == 1)
        {
            GameObject egg = Instantiate(eggPrefab, transform.position, Quaternion.identity);
            //GetComponent<AudioSource>().Play();
        }
        if (health <= 0) Die();
    }
}
