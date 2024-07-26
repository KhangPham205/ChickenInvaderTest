using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMove : MonoBehaviour
{
    //Cacs biến để di chuyển theo hình tròn
    public Transform center;
    public float radius = 0;
    public float speed = 2f;
    private float angle = 0;
    public float angleOffset;
    //Di chuyển đến center
    public float Flexible_Radius;
    // Start is called before the first frame update
    void Start()
    {
        Set_Radius();
    }
    void Update()
    {
        Move();
    }
    private void Move()
    {
        Vector3 prePosition = transform.position;
        angle += speed * Time.deltaTime;
        float x = center.position.x + radius * Mathf.Cos(angle + angleOffset);
        float y = center.position.y + radius * Mathf.Sin(angle + angleOffset);
        transform.position = new Vector3(x, y, transform.position.z);
        //Tính toán hướng mới
        //gameObject.transform.Rotate(0f, 0f, Mathf.Abs(prePosition.z-transform.position.z));
        //rotate để cho vật hướng mặt về trung tâm trong lúc 

    }
    private void Set_Radius()
    {
        radius = Flexible_Radius; // set goc ban đầu
    }
}
