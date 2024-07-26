using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Metal_Egg : Metal_Egg_Manager
{
    public TextMeshProUGUI Percent_Health_Point;
    public Image Health_Bar;
    public bool isDeath = false;
    public Camera mainCamera; // camera tham chiếu cho việc di chuyển.
    public float Wait_Time = 5f;
    private int dmg = 100;

    private Vector2 targetPosition;
    public GameObject Plasma;
    public float Time_Per_Shoot = 5;
    public float Number_Of_Plasma=6;
    public float Angle = 360/6;

    public float Rotate_Degree = 10.0f;
    private float Sign = 1;

    public float maxSpeed = 5.0f;

    // Biên độ di chuyển ngẫu nhiên
    public float movementRange = 2.0f;

    void Start()
    {
        StartCoroutine(Shooting_Plasma());
        StartCoroutine(Change_Point());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Random_Move();
        Random_Rotate(); 
        Update_Cur_Health();
        isDead();
    }
    IEnumerator Shooting_Plasma()
    {
        while (true)
        {
            yield return new WaitForSeconds(Time_Per_Shoot);
                Fire(); 
        }
    }
    private void Fire()
    {
        maxSpeed = 0.0f ; movementRange = 0.0f;
        Angle = 0; Sign *= -1; // đổi chiều quay
        for (int i = 0; i < Number_Of_Plasma; i++)
        {
            GameObject Plasma_Clone = Instantiate(Plasma, transform.position, transform.rotation);
            Plasma_Clone.transform.Rotate(0.0f, 0.0f, Angle);
            Angle += 360.0f/Number_Of_Plasma;
        }
        maxSpeed = 5.0f; movementRange = 2.0f;
        return;
    }

    private void KeepWithinScreenLimits()
    {
        // Tính toán kích thước khung hình
        Vector3 screenBounds = mainCamera.ScreenToViewportPoint(new Vector3(Screen.width, Screen.height, 0.0f));
        // Giới hạn vị trí object trên trục X
        float xMin = mainCamera.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, 0.0f)).x + 3f; 
        float xMax = mainCamera.ViewportToWorldPoint(new Vector3(screenBounds.x, 0.0f, 0.0f)).x -3f;
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, xMin, xMax),
            transform.position.y,
            transform.position.z
        );

        // Giới hạn vị trí object trên trục Y
        float yMin = mainCamera.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, 0.0f)).y + 3f;
        float yMax = mainCamera.ViewportToWorldPoint(new Vector3(0.0f, screenBounds.y, 0.0f)).y -3f;
        transform.position = new Vector3(
            transform.position.x,
            Mathf.Clamp(transform.position.y, yMin, yMax),
            transform.position.z
        );
    }
    private void Random_Rotate()
    {
        transform.Rotate(0.0f, 0.0f, Sign * Rotate_Degree ); //Random.Range(Sign * Min_Rotate,Sign * Max_Rotate)
    }
    void Random_Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, 2 * Time.deltaTime);
        KeepWithinScreenLimits();
    }
    void ResetPosition()
    {
        // Tạo vị trí đích ngẫu nhiên
        targetPosition = new Vector2(Random.Range(-Screen.width / 2, Screen.width / 2),
                                     Random.Range(-Screen.height / 2, Screen.height / 2));

        // Khởi tạo lại tốc độ
        //rb.velocity = Vector2.zero;

    }

    IEnumerator Change_Point()
    {
        while (true)
        {
            yield return new WaitForSeconds(Wait_Time);
            ResetPosition();
        }
    }
    public void isDead()
    {
        if(health <= 0)
        {
            isDeath = true;
            Destroy(gameObject);
            Mng_Val.score += 10000;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Debug.Log("Impacted!");
            Destroy(other.gameObject);
            health -= dmg;
        }
    }
    public void Update_Cur_Health()
    {
        if (isDeath == false)
        {
            Health_Bar.fillAmount = (float)health / max_health;
            this.Percent_Health_Point.text = ((float)health / max_health * 100.0f).ToString() + '%';
        }
    }
}
