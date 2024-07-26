using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GIFT: MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject, 0.1f);
        }
    }
}
