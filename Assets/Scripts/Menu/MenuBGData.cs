using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Menu",menuName ="BGData")]
public class MenuBGData : ScriptableObject
{
    public Texture img;
    public AudioClip bgm;
    public float BPM;
    public bool isVideo;
}
