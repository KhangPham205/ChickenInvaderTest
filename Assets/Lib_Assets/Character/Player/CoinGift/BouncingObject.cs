using UnityEngine;

public class BouncingObject : MonoBehaviour
{
    private Rigidbody2D rb; // Tham chiếu đến Rigidbody2D của vật thể
    private float bottomBoundary; // Biến lưu trữ vị trí rìa màn hình dưới
    public Spawn_Manager_Obj Mng_Val;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Lấy Rigidbody2D của vật thể
        bottomBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y; // Tính toán vị trí rìa màn hình dưới
    }

    void Update()
    {
        if (transform.position.y < bottomBoundary) // Kiểm tra vị trí y của vật thể
        {
            rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y); // Thay đổi hướng y của vận tốc
            rb.velocity *= 0.9f; // Giảm tốc độ theo thời gian
            //Color color = GetComponent<Renderer>().material.color; // Lấy màu của vật thể
            //color.a -= 0.01f; // Giảm độ alpha (độ mờ) của màu
            //GetComponent<Renderer>().material.color = color; // Cập nhật màu cho vật thể
        }
        Destroy(gameObject, 5.0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Mng_Val.Coin += 1;
            Debug.Log("Impact Coin");
            Destroy(gameObject);
        }
    }
}
