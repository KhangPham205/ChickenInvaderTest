using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class MeteorMove : MonoBehaviour
{
    public Spawn_Manager_Obj Mng_Val;
    public float speed;

    public float health;
    public float dmg;

    [SerializeField] private GameObject[] coinPrefabs;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            health -= dmg;
            Debug.Log("Impact meteor");
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        for (int i = 0; i < coinPrefabs.Length; i++)
        {
            Vector3 Rand_Vector = new Vector3(Random.Range(-0.5f, 0.5f), 0f, 0f);
            Vector3 Spawn_Point = gameObject.transform.position + Rand_Vector;
            GameObject coinPrefab = coinPrefabs[i];
            GameObject coin = Instantiate(coinPrefab, Spawn_Point, Quaternion.identity);
        }
        
    }
}
