using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveManger : MonoBehaviour
{
    public float speed = 2f;
    // Biên giới trái và phải của main camera
    private float leftBorder;
    private float rightBorder;

    void Start()
    {
        // Tính toán biên giới trái và phải của main camera
        leftBorder = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x;
        rightBorder = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x;
        Invoke("Update", 5.0f);
    }

    void Update()
    {
        // Di chuyển sang trái hoặc phải
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        // Giới hạn vị trí di chuyển của gà
        if (transform.position.x < leftBorder + 5)
        {
            speed *= -1;
            transform.position = new Vector3(leftBorder + 5, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > rightBorder - 6)
        {
            speed *= -1;
            transform.position = new Vector3(rightBorder - 6, transform.position.y, transform.position.z);
        }
    }
}
