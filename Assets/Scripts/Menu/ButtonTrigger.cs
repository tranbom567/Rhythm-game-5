using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTrigger : MonoBehaviour
{
    [SerializeField]
    private Image buttonImg;
    [SerializeField]
    private AudioSource UISFX;
    [SerializeField]
    private TMP_Text text;
    [SerializeField]
    private bool isHover;
    void Start()
    {
        buttonImg=GetComponent<Image>();
        text = transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
    }

    public void onButtonHovered()
    {
        UISFX.clip = Resources.Load<AudioClip>("MenuSFX/HoverSound");
        UISFX.Play();
        buttonImg.DOColor(Color.white, 0);
        text.DOColor(Color.black, 0);
        buttonImg.DOColor(new Color(0.5f, 0.5f, 0.5f, (float)152/255), 0.5f).SetEase(Ease.InOutSine);
        text.DOColor(Color.cyan, 0.5f).SetEase(Ease.InOutSine);
        GetComponent<RectTransform>().DOSizeDelta(Vector2.right * 600+Vector2.up* GetComponent<RectTransform>().sizeDelta.y, 0.2f).SetEase(Ease.InOutFlash);
       
    }
    public void onButtonExit()
    {
       
        text.DOColor(Color.white, 0.5f).SetEase(Ease.InOutSine);
        GetComponent<RectTransform>().DOSizeDelta(Vector2.right * 500 + Vector2.up * GetComponent<RectTransform>().sizeDelta.y, 0.5f).SetEase(Ease.InOutCubic);
        
    }
    void Update()
    {
       
    }
}
