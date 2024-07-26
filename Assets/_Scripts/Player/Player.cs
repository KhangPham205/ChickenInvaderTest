//CODE XỬ LÝ HÀNH ĐỘNG BẮN VÀ LOGIC GAME
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Timeline;


public class Player : Space_Ship
{
    public TextMeshProUGUI Text_Score;
    public TextMeshProUGUI Text_Coin;
    public Image Over_Heat_Bar;
    public int Over_Heat_Point = 10000;
    public int Cur_Over_Heat_Point = 0;
    public bool Can_Fire = true;
    public int Over_Heat_Scale = 1;
    //for shooting
    public float Shooting_Rate = 5.0f;
    //for choosing type of bullet
    public Transform Fire_Point;
    public float Bullet_Force = 0;
    private void Start()
    {

        Over_Heat_Scale = 1;
        StartCoroutine(ShootingCoroutine());
    }
    private void FixedUpdate()
    {
        Update_Type();
        Choosing_Bullet();
        Over_Heat_Method();
        I_Frame();
        CheckHP();
        Update_Score_And_Coin(Mng_Val.score, Mng_Val.Coin);
        if(Mng_Val.isClear == true)
            Move_Out();
        else
            Move();
    }
    //XỬ LÝ ĐẠN BẮN CHO SPACE_SHIP
    //GỒM CHỌN ĐẠN, BẮN ĐẠN
    IEnumerator ShootingCoroutine()
    {
        while (Mng_Val.isClear == false)
        {
            yield return new WaitForSeconds(Shooting_Rate);
            Fire();
        }
    }
    private void Fire()
    {
        if (Input.touchCount > 0 && Can_Fire == true)
        {
            Cur_Over_Heat_Point += 400;
            MusicManager.Instance.PlaySoundBullet();
            if (Cur_Over_Heat_Point >= Over_Heat_Point)
            {
                Can_Fire = false;
                Over_Heat_Scale = 3;
            }
            if (Mng_Val.Type == 1)
            {
                GameObject bullet = Instantiate(Bullet_Prefab, Fire_Point.position, Fire_Point.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(Fire_Point.up * Bullet_Force, ForceMode2D.Impulse);
                return;
            }
            if(Mng_Val.Type == 2)
            {
                Segment_Fire(Mng_Val.Segment_Bullet_Level);
                return;
            }
            if (Mng_Val.Type == 3)
            {
                if(S_Style != 3)
                {
                    GameObject bullet = Instantiate(Bullet_Prefab, Fire_Point.position, Fire_Point.rotation);
                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                    rb.AddForce(Fire_Point.up * Bullet_Force, ForceMode2D.Impulse);
                    S_Style++;
                    return;
                }
                if(S_Style == 3)
                {
                    Segment_Fire(Mng_Val.Forks_Bullet_Level);
                    S_Style = 1;
                    return;
                }
            }
        }
        else return;
    }
    public void Segment_Fire(int level)
    {
        if (level % 2 == 1)
        {
            int a = 1;
            for (int i = 1; i <= level; i++)
            {
                GameObject bullet = Instantiate(Bullet_Prefab, Fire_Point.position, Fire_Point.rotation);
                if (i != 1 && i / 2 == 1)
                {
                    bullet.transform.Rotate(0.0f, 0.0f, a * (i / 2) * Angle);
                    a *= -1;
                }
                if (i != 1 && (i / 2 == 2))
                {
                    bullet.transform.Rotate(0.0f, 0.0f, a * (i / 2) * Angle);
                    a *= -1;
                }
            }
        }
        if (level % 2 == 0)
        {
            int a = 1;
            for (int i = 1; i <= level; i++)
            {
                GameObject bullet = Instantiate(Bullet_Prefab, Fire_Point.position, Fire_Point.rotation);
                if ((i - 1) / 2 == 0)
                {
                    bullet.transform.Rotate(0.0f, 0.0f, a * Angle / 2);
                    a *= -1;
                }
                if ((i - 1) / 2 == 1)
                {
                    bullet.transform.Rotate(0.0f, 0.0f, a * Angle * 1.5f);
                    a *= -1;
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "GIFT_Basic_Bullet")
        {
            if (Mng_Val.Type != 1) Mng_Val.Type = 1;
            Mng_Val.Basic_Bullet_Level++;
            if (Mng_Val.Basic_Bullet_Level > 5) Mng_Val.Basic_Bullet_Level = 5;
        }
        if (other.gameObject.tag == "GIFT_Segment_Bullet")
        {
            if (Mng_Val.Type != 2)  Mng_Val.Type = 2;
            Mng_Val.Segment_Bullet_Level++;
            if(Mng_Val.Segment_Bullet_Level > 5) Mng_Val.Segment_Bullet_Level = 5;
        }
        if (other.gameObject.tag == "GIFT_Forks_Bullet")
        {
            if (Mng_Val.Type != 3) Mng_Val.Type = 3;
            Mng_Val.Forks_Bullet_Level++;
            if (Mng_Val.Forks_Bullet_Level > 5) Mng_Val.Forks_Bullet_Level = 5;
        }
        if(other.gameObject.tag == "GIFT")
        {
            //levle up B_Bullet
            Mng_Val.Basic_Bullet_Level++;

            if (Mng_Val.Basic_Bullet_Level > 5) Mng_Val.Basic_Bullet_Level = 5;
            //Level up F_Bulelt
            Mng_Val.Forks_Bullet_Level++;

            if (Mng_Val.Forks_Bullet_Level > 5) Mng_Val.Forks_Bullet_Level = 5;
            //Level up S_Bullet
            Mng_Val.Segment_Bullet_Level++;

            if (Mng_Val.Segment_Bullet_Level > 5) Mng_Val.Segment_Bullet_Level = 5;
        }
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Egg" || other.gameObject.tag == "Cannon" || other.gameObject.tag == "Chicken")
        {
            Respawn();
        }
    }
    public string Scene_Name = "EndScene";
    public void CheckHP()
    {
        if (Mng_Val.HP <= 0) SceneManager.LoadScene(Scene_Name);
    }

    public GameObject Respawn_Point;
    protected void Respawn()
    {
        if (!isDead == true)
        {
            Mng_Val.HP--;
            if (Mng_Val.Type == 1 && Mng_Val.Basic_Bullet_Level != 1) { Mng_Val.Basic_Bullet_Level--; }
            if (Mng_Val.Type == 2 && Mng_Val.Segment_Bullet_Level != 1) { Mng_Val.Segment_Bullet_Level--; }
            if (Mng_Val.Type == 3 && Mng_Val.Forks_Bullet_Level != 1) { Mng_Val.Forks_Bullet_Level--; }
        }
        isDead = true;
        Can_Fire = false;
        this.transform.position = Respawn_Point.transform.position;
    }
    protected void I_Frame()
    {
        if (isDead == true)
        {
            speed = 0f;
            Respawn_Time -= 1;
        }
        if (Respawn_Time < 0)
        {
            Respawn_Time = 50;
            isDead = false;
            speed = 20f;
            Can_Fire = true;
        }
    }
    protected void Over_Heat_Method()
    {
        Cur_Over_Heat_Point -= 20 * Over_Heat_Scale;
        if (Cur_Over_Heat_Point <= 0)
        {
            Can_Fire = true;
            Cur_Over_Heat_Point = 0;
            Over_Heat_Scale = 1;
        }
        Over_Heat_Bar.fillAmount = (float)Cur_Over_Heat_Point / Over_Heat_Point;
    }
    void Update_Score_And_Coin(int _score, int _coin)
    {
        this.Text_Score.text = _score.ToString();
        this.Text_Coin.text = _coin.ToString();
    }
    void Move_Out()
    {
        if (Mng_Val.isClear)
        {
            Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
            // Set gravity scale
            rigidbody.gravityScale = 2.0f;
        }
    }
}
