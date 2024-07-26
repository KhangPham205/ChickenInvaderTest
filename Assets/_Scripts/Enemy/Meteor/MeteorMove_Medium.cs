using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMove_Medium : MeteorMove
{
    // Update is called once per frame
    void Update()
    {
        // Calculate the direction vector for a 30-degree downward angle
        Vector2 direction = new Vector2(-1f, Mathf.Tan(-30f * Mathf.Deg2Rad)); // Adjust angle as needed

        // Normalize the direction vector to maintain constant speed
        direction = direction.normalized;

        // Apply the movement using velocity
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction * speed;

        Destroy(gameObject, 30f);
        if (health <= 0)
        {
            Mng_Val.score += 100;
            Die();
        }
    }
}
