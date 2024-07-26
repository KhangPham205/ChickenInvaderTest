using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenWave7 : ChickenInfo
{
    private int Random_Number;
    public int Number_Spawn = 1;
    public int Min_Rand = 1;
    public int Max_Rand = 10000;

    public GameObject eggPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1) Random_Number = Random.Range(Min_Rand, Max_Rand);
        if (Random_Number == 1)
        {
            GameObject egg = Instantiate(eggPrefab, transform.position, Quaternion.identity);
            //GetComponent<AudioSource>().Play();
        }
        if (health <= 0) Die();
    }
}
