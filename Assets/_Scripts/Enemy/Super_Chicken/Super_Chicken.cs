using JetBrains.Annotations;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Super_Chicken : MonoBehaviour
{
    [SerializeField] private GameObject[] coinPrefabs;
    public Spawn_Manager_Obj Mng_Val;
    public int health = 40000;
    public int max_health = 40000;
    public int dmg = 100;
    public Camera mainCamera; // camera tham chiếu cho việc di chuyển.
    public GameObject Center;
    public float Wait_Time = 3f;
    public float Spawn_Rate = 5.0f;
    public GameObject Egg_Prefab;
    public GameObject Plasma_Prefab;
    public GameObject cBullet_Prefab;
    private Vector2 targetPosition;
    //UI
    public TextMeshProUGUI Percent_Health_Point;
    public Image Health_Bar;
    public bool isDeath = false;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = Center.transform.position;
        StartCoroutine(Change_Point());
        StartCoroutine(Active_Skill());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Check_HP();
        Random_Move();
        Update_Cur_Health();
    }
    private void Random_Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, 3 * Time.deltaTime);
        KeepWithinScreenLimits();
    }
    private void KeepWithinScreenLimits()
    {
        // Tính toán kích thước khung hình
        Vector3 screenBounds = mainCamera.ScreenToViewportPoint(new Vector3(Screen.width, Screen.height, 0.0f));
        // Giới hạn vị trí object trên trục X
        float xMin = mainCamera.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, 0.0f)).x + 3f;
        float xMax = mainCamera.ViewportToWorldPoint(new Vector3(screenBounds.x, 0.0f, 0.0f)).x - 3f;
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, xMin, xMax),
            transform.position.y,
            transform.position.z
        );

        // Giới hạn vị trí object trên trục Y
        float yMin = mainCamera.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, 0.0f)).y + 6f;
        float yMax = mainCamera.ViewportToWorldPoint(new Vector3(0.0f, screenBounds.y, 0.0f)).y - 2f;
        transform.position = new Vector3(
            transform.position.x,
            Mathf.Clamp(transform.position.y, yMin, yMax),
            transform.position.z
        );
    }
    void ResetPosition()
        {
            // Tạo vị trí đích ngẫu nhiên
            targetPosition = new Vector2(Random.Range(-Screen.width / 2, Screen.width / 2),
                                         Random.Range(-Screen.height / 2, Screen.height / 2));
        }

    IEnumerator Change_Point()
    {
        while (true)
        {
            yield return new WaitForSeconds(Wait_Time);
            ResetPosition();
        }
    }
    IEnumerator Active_Skill()
    {
        while (true)
        {
            yield return new WaitForSeconds(Spawn_Rate);
            Active_Random_Skill();
        }
    }
    private void Active_Random_Skill()
    {
        int x =  Random.Range(0,3);
        switch (x)
        {
            case 0: Spawn(); break;
            case 1: Plasma(); break;
            case 2: Shoot(); break;
            default: break;
        }
    }
    private void Spawn()
    {
        for (int i = 0; i < Random.Range(10, 15); i++)
        {
            Vector3 Rand_Vector = new Vector3 (Random.Range(-1.5f, 1.5f), 0f, 0f);
            Vector3 Spawn_Point = gameObject.transform.position + Rand_Vector;
            GameObject Egg = Instantiate(Egg_Prefab, Spawn_Point, transform.rotation);
        }
    }
    private void Plasma()
    {
        GameObject Plasma = Instantiate(Plasma_Prefab, transform.position, transform.rotation);
    }
    private void Shoot()
    {
        for(int i=0; i < Random.Range(15,20); i++)
        {
            GameObject cBullet = Instantiate(cBullet_Prefab, transform.position, transform.rotation);
            cBullet.transform.Rotate(0f, 0f, Random.Range(0f, 360f));
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            health = health - dmg;
            Destroy(other.gameObject);
        }
    }
    private void Check_HP()
    {
        if (health <= 0)
        {
            isDeath = true;
            Destroy(gameObject);
            MusicManager.Instance.PlaySoundChicken();
            Mng_Val.score += 10000;
            for (int i = 0; i < 10; i++)
            {
                Vector3 Rand_Vector = new Vector3(Random.Range(-2.0f, 2.0f), 0f, 0f);
                Vector3 Spawn_Point = gameObject.transform.position + Rand_Vector;
                GameObject coinPrefab = coinPrefabs[Random.Range(0,3)];
                GameObject coin = Instantiate(coinPrefab, Spawn_Point, Quaternion.identity);
            }
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
