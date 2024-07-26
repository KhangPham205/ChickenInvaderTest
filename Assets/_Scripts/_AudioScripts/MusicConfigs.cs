using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MusicConfigs", menuName = "Configs/MusicConfigs")]
public class MusicConfigs : ScriptableObject
{
    public List<AudioClip> _clips;
}
