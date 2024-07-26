using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space_Ship : MonoBehaviour
{
    public Spawn_Manager_Obj Mng_Val;
    protected Vector3 touchPosition; // Vị trí ngón tay chạm vào màn hình
    protected float speed = 20f; // Tốc độ di chuyển phi thuyền
    public int Respawn_Time = 50;
    public bool isDead = false;
    protected void Move()
    {
        if (Input.touchCount > 0)
        {
            // Get the first finger's position
            touchPosition = Input.GetTouch(0).position;

            // trans to position in Unity
            touchPosition = Camera.main.ScreenToWorldPoint(touchPosition);
            // set a rectangle (limit)
            touchPosition.x = Mathf.Clamp(touchPosition.x, -Screen.width / 2 + transform.localScale.x / 2, Screen.width / 2 - transform.localScale.x / 2);
            touchPosition.y = Mathf.Clamp(touchPosition.y, -Screen.height / 2 + transform.localScale.y / 2, Screen.height / 2 - transform.localScale.y / 2);
            // Move()
            transform.position = Vector2.MoveTowards(transform.position, touchPosition, speed * Time.unscaledDeltaTime);
        }
    }
    //CHỌN ĐẠN
    public GameObject Bullet_Prefab;
    public GameObject Basic_Bullet;
    public GameObject BLv1;
    public GameObject BLv2;
    public GameObject BLv3;
    public GameObject BLv4;
    public GameObject BLv5;
    public GameObject Segment_Bullet;
    public GameObject Forks_Bullet;
    public GameObject FLv1;
    public GameObject FLv2;
    public GameObject FLv3;
    public GameObject FLv4;
    public GameObject FLv5;
    public int S_Style = 1;
    protected float Angle = 10f;
    protected void Choosing_Bullet()
    {
        if (Mng_Val.Type == 1) Bullet_Prefab = Basic_Bullet;
        if (Mng_Val.Type == 2) Bullet_Prefab = Segment_Bullet;
        if (Mng_Val.Type == 3) Bullet_Prefab = Forks_Bullet;
    }//Type of player's bullet will be changed when they collect the gift
    protected void Current_Bullet_T1(int level)
    {
        switch (level)
        {
            case 1: Basic_Bullet = BLv1; break;
            case 2: Basic_Bullet = BLv2; break;
            case 3: Basic_Bullet = BLv3; break;
            case 4: Basic_Bullet = BLv4; break;
            case 5: Basic_Bullet = BLv5; break;
            default: break;
        }
    }
    protected void Current_Bullet_T3(int level)
    {
        switch (level)
        {
            case 1: Forks_Bullet = FLv1; break;
            case 2: Forks_Bullet = FLv2; break;
            case 3: Forks_Bullet = FLv3; break;
            case 4: Forks_Bullet = FLv4; break;
            case 5: Forks_Bullet = FLv5; break;
            default: break;
        }
    }
    protected void Update_Type()
    {
        if (Mng_Val.Type == 1) Current_Bullet_T1(Mng_Val.Basic_Bullet_Level);
        if (Mng_Val.Type == 2) return;
        if (Mng_Val.Type == 3)
        {
            if (S_Style != 3) Current_Bullet_T3(Mng_Val.Forks_Bullet_Level);
            else Forks_Bullet = FLv1;
        }
    }
    
}
