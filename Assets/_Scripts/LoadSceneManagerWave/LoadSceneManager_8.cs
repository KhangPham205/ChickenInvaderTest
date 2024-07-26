using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadSceneManager_8 : MonoBehaviour
{
    public Spawn_Manager_Obj Player;
    public TextMeshProUGUI text_Clear;
    public TextMeshProUGUI text_Open_Wave;
    void Start()
    {
        this.text_Clear.fontSize = 0;
        StartCoroutine(Swap_Color());
        StartCoroutine(Check_Scene_Loader());
        StartCoroutine(Show_Open());
    }
    void Update()
    {
        if (Player.score >= 45200)
        {
            Player.isClear = true;
            this.text_Clear.fontSize = 40;
        }
    }
    IEnumerator Check_Scene_Loader()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            {
                if (Player.score >= 45200 && Player.isClear == true)
                {
                    Player.isClear = false;
                    SceneManager.LoadScene("Wave_9");
                }
            }
        }
    }
    IEnumerator Swap_Color()
    {
        int i = 1;
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            {
                if (i == 1)
                    this.text_Clear.faceColor = Color.red;
                else
                    this.text_Clear.faceColor = Color.yellow;
                i *= -1;
            }
        }
    }
    IEnumerator Show_Open()
    {
        int i = 0;
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            this.text_Open_Wave.fontSize = 40;
            i++;
            if (i == 10)
            {
                this.text_Open_Wave.fontSize = 0;
                break;
            }
        }
    }
}