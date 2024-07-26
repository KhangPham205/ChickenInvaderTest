using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    #region Singleton
    private static MusicManager _instance;
    public static MusicManager Instance => _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this);
        }
        else
            _instance = this;
    }

    #endregion Singleton

    //component phat ra sound
    public AudioSource _audioSourceStart;
    public AudioSource _audioSourceFX;
    public AudioSource _audioSourceChicken;


    public MusicConfigs _configs;

    public AudioClip GetClip(string fileName)
    {
        for (int i = 0; i < _configs._clips.Count; i++)
        {
            if (_configs._clips[i].name.Equals(fileName))
                return _configs._clips[i];
        }

        Debug.LogError("KHONG TIM THAY FILE VOI TEN " + fileName);
        return null;
    }

    void Start()
    {
        //phat nhac nen
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "StartScene")
        {
            _audioSourceStart.clip = GetClip("StartScene");
            _audioSourceStart.Play();
        }

        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "EndScene")
        {
            _audioSourceStart.clip = GetClip("EndScene");
            _audioSourceStart.Play();
        }
    }

    public void PlaySoundBullet()
    {
        _audioSourceFX.clip = GetClip("LaserSound");
        _audioSourceFX.Play();
    }

    public void PlaySoundChicken()
    {
        _audioSourceChicken.clip = GetClip("ChickenSound");
        _audioSourceChicken.Play();
    }
    public void PlaySoundBullet(string fileName)
    {
        _audioSourceFX.clip = GetClip(fileName);
        _audioSourceFX.Play();
    }
    /*public void PlaySoundLevelUp()
    {
        _audioSourceFX.clip = GetClip("LevelUp");
        _audioSourceFX.Play();
    }*/
}
