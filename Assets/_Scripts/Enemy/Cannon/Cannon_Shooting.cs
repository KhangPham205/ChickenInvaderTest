using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.GraphicsBuffer;

public class Cannon_Shooting : MonoBehaviour
{
    public Spawn_Manager_Obj Mng_Val;
    public int health = 10000;
    public int max_health = 10000;
    private int dmg = 100;
    // Prefab quả trứng
    public GameObject eggPrefab;
    public Transform Fire_Point;

    private int Number_Of_Egg = 4;
    // Vị trí player
    private Transform playerTransform;

    // Thời gian chờ trước khi quay và bắn
    private float Wait_Time_Before_Action = 5.0f;
    //UI
    public TextMeshProUGUI Percent_Health_Point;
    public Image Health_Bar;
    public bool isDeath = false;
    //UI
    // Khởi tạo
    void Start()
    {
        // Tìm kiếm player
        StartAction();
    }

    // Cập nhật
    void FixedUpdate()
    {
        isDead();
        Update_Cur_Health();
    }

    // Bắt đầu hành động
    void StartAction()
    {
        StartCoroutine(RotateToPlayer());
    }

    // Quay về hướng player
    IEnumerator RotateToPlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(Wait_Time_Before_Action);
            Rotate();
        }
    }
    void Rotate()
    {

        playerTransform = GameObject.Find("Center").transform;
        //// Tính toán hướng từ súng đến player
        Vector2 direction = playerTransform.position - transform.position;

        //// Lấy góc quay
        float angle = Mathf.Atan2(direction.y, direction.x) * 180.0f / Mathf.PI;
        //// Quay súng về phía player
        transform.rotation = Quaternion.Euler(0, 0, angle);
        StartCoroutine(Shoot());
    }
    // Bắn trứng
    IEnumerator Shoot()
    {
        int i = 0;
        while (i != Number_Of_Egg)
        {
            yield return new WaitForSeconds(0.1f);
            Fire();
            i++;
        }
    }
    private void Fire()
    {
        GameObject Egg_Clone = Instantiate(eggPrefab, Fire_Point.position, Fire_Point.rotation);
        return;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Debug.Log("Impacted!");
            health -= dmg;
            Destroy(other.gameObject);
        }
    }
    public void isDead()
    {
        if (health <= 0)
        {
            isDeath = true;
            Destroy(gameObject);
            Mng_Val.score += 10000;
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
