using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesManagerScrips : MonoBehaviour
{
    public void LoadScene(string Scene_Name)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(Scene_Name);
    }
    public void Exit_Game()
    {
        Application.Quit();
    }
}
