﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Super_Egg : MonoBehaviour
{
    private float speed;
    // Kích thước màn hình
    private Vector3 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(0.0f, 1.0f);
        // Khởi tạo kích thước màn hình
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.nearClipPlane));
    }

    // Update is called once per frame
    void Update()
    {
        // Kiểm tra vị trí vật thể
        Vector3 objectPosition = transform.position;

        // Xóa vật thể nếu ra khỏi khung màn hình
        if (objectPosition.x < -screenBounds.x ||
            objectPosition.x > screenBounds.x ||
            objectPosition.y < -screenBounds.y ||
            objectPosition.y > screenBounds.y)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}