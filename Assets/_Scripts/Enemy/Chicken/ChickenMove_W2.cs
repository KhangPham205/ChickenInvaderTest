using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenMove_W2 : ChickenInfo
{
    // Tốc độ di chuyển của object
    public float speed = 2f;

    // Biên giới trái và phải của main camera
    private float leftBorder;
    private float rightBorder;

    public GameObject eggPrefab;

    // Số random của bngyl
    private int Random_Number;
    public int Number_Spawn = 1;
    public int Min_Rand = 1;
    public int Max_Rand = 10000;


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
            speed *= -1;
            transform.position = new Vector3(leftBorder, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > rightBorder)
        {
            speed *= -1;
            transform.position = new Vector3(rightBorder, transform.position.y, transform.position.z);
        }

        // Tạo trứng (của Bngyl)
        if(Time.timeScale == 1) Random_Number = Random.Range(Min_Rand,Max_Rand);
        if(Random_Number == 1)
        {
            GameObject egg = Instantiate(eggPrefab, transform.position, Quaternion.identity);
        }
        if (health <= 0) Die();
    }
}
