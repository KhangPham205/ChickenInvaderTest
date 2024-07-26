using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected float speed = 5;
    protected void Fly()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        // Destroy after 2seconds
        Destroy(gameObject, 4f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Chicken")
        {
            Debug.Log("Impacted!");
            Destroy(gameObject);
        }
    }
}
