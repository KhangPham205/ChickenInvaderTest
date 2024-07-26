using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg_MoveForward : MonoBehaviour
{
    public float speed = 10f; // Tốc độ bay của đạn
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
        transform.Translate(Vector2.right * speed * Time.deltaTime);// move

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
}
