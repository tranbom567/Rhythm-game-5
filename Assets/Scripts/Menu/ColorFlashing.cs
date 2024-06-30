using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ColorFlashing : MonoBehaviour
{
    private RawImage rImage;
    public Color idleColor;
    public Color flashColor;
    void Start()
    {
        rImage=GetComponent<RawImage>();
    }

    IEnumerator startFlash()
    {
        rImage.DOColor(flashColor,0).SetEase(Ease.Flash);
        rImage.DOColor(idleColor, (60 / MenuManager.getInstance.menuBg.BPM)/3).SetEase(Ease.Flash);
        yield return null;
    }
    public void flashes()
    {
        StartCoroutine(startFlash());
    }
    void Update()
    {
        
    }
}
