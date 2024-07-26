using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg_Basic : MonoBehaviour
{
    // Kích thước màn hình
    private Vector3 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
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
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Impacted!");
            Destroy(gameObject);
            // Hiển thị thông báo "Impacted"
        }
    }
}