using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data")]
public class Spawn_Manager_Obj : ScriptableObject
{
    public int HP = 5;
    public int score = 0;
    public int Basic_Bullet_Level = 1;
    public int Segment_Bullet_Level = 1;
    public int Forks_Bullet_Level = 1;
    public int Type = 1;
    public bool isClear = false;
    public int Coin = 0;
}
