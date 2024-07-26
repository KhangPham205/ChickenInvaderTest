using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    // Tốc độ di chuyển của object
    public float speed = 2f;

    // Biên giới trái và phải của main camera
    private float leftBorder;
    private float rightBorder;


    void Start()
    {
        // Tính toán biên giới trái và phải của main camera
        leftBorder = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x;
        rightBorder = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x;
    }

    void Update()
    {
        // Di chuyển gà sang trái hoặc phải
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        // Giới hạn vị trí di chuyển của gà
        if (transform.position.x < leftBorder)
        {
            transform.position = new Vector3(rightBorder, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > rightBorder)
        {
            transform.position = new Vector3(leftBorder, transform.position.y, transform.position.z);
        }
    }
}