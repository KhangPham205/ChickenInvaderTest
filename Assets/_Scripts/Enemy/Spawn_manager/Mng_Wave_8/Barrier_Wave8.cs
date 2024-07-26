using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier_Wave8 : Barrier_Base
{
    public Transform center;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Break();

        Vector2 direction = center.position - transform.position;
        //// Lấy góc quay
        float angle_Object = Mathf.Atan2(direction.x, direction.y) * 180.0f / Mathf.PI;
        //// Quay súng về phía player
        transform.rotation = Quaternion.Euler(0, 0, -angle_Object);

    }
}
