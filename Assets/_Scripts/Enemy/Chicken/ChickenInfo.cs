using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenInfo : MonoBehaviour
{
    public Spawn_Manager_Obj Mng_Val;
    public int health = 1000;
    public int dmg = 100;
    public Vector2 position;

    public Vector2 Target_Position;
    public int Reward_Number = 1;
    public int Type_Of_Gift = 0;
    public int Rand_Num_Min = 1;
    public int Rand_Num_Max = 10;
    public GameObject GIFT;

    [SerializeField] public GameObject[] GiftPrefabs;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            health = health - dmg;
            Debug.Log("HUHUHUHUHUHUHU");
        }
    }   

    protected void Die()
    {
        Destroy(gameObject);
        MusicManager.Instance.PlaySoundChicken();
        Mng_Val.score += 100;
        if (Reward_Number == Random.Range(Rand_Num_Min, Rand_Num_Max))
        {
            switch (Random.Range(0,6))
            {
                case 0:
                    GIFT = GiftPrefabs[0];
                    break;
                case 1:
                    GIFT = GiftPrefabs[1];
                    break;
                case 2:
                    GIFT = GiftPrefabs[2];
                    break;
                case 3:
                case 4:
                case 5:
                    GIFT = GiftPrefabs[3];
                    break;
                default: 
                    break;
            }
            GameObject GIFT_Clone = Instantiate(GIFT, transform.position, transform.rotation);
        }
    }
}
