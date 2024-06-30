using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public MenuBGData menuBg;
    private BackgroundScript bgScript;
    public AudioSource bgm;
    public static MenuManager getInstance;
    public bool isReplaceClip;
    private void Awake()
    {
        getInstance = this;
    }
    void Start()
    {
        bgScript=GetComponent<BackgroundScript>();
        menuChange();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void menuChange()
    {
        if (!menuBg.isVideo)
        {
            bgScript.bg1.GetComponent<RawImage>().texture = menuBg.img;
            bgScript.bg2.GetComponent<RawImage>().texture = menuBg.img;
            bgScript.isMoving = true;
        }
        else
        {
            bgScript.bg1.GetComponent<RawImage>().texture = menuBg.img;
            bgScript.isMoving = false;
        }
        bgm.clip = menuBg.bgm;
        bgm.Play();
        isReplaceClip = true;
    }
}
