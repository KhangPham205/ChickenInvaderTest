using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier_Base : MonoBehaviour
{
    public Spawn_Manager_Obj Mng_Val;
    public int HP = 1500;
    protected int dmg = 100;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            HP = HP - dmg;
            Destroy(other.gameObject);
        }
    }

    protected void Break()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
            Mng_Val.score += 100;
        }
    }
}
