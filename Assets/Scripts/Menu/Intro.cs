using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public AudioSource bgm;
    public TMP_Text mainText;
    public TMP_Text infoText;
    public RawImage loadIcon;
    public TMP_Text moveToTarget;
    public RawImage Overlay;
    private bool isWaiting = true;
    private Vector3 oldScale = Vector3.one;
    void Start()
    {
        StartCoroutine(introPlay());
    }

    IEnumerator introPlay()
    {
        infoText.text = "Set audio clip";
        yield return new WaitUntil(() => MenuManager.getInstance.isReplaceClip);
        infoText.text = "Loading music";
        yield return new WaitUntil(() => bgm.clip.loadState == AudioDataLoadState.Loaded);
        infoText.text = "Loaded";
        infoText.DOColor(Color.black * 0, 0.5f).SetEase(Ease.InOutSine);
        loadIcon.DOColor(Color.black * 0, 0.5f).SetEase(Ease.InOutSine);
        bgm.DOFade(1f, 0.5f);
        isWaiting = false;
        yield return new WaitForSeconds(1.2f);
        mainText.DOColor(Color.white, 2.5f).SetEase(Ease.InOutSine);
        yield return new WaitForSeconds(5);
        mainText.DOColor(Color.black * 0, 1.2f).SetEase(Ease.InOutSine).OnKill(()=>moveToTarget.DOColor(Color.white,1.5f));
        Overlay.DOColor(Color.black * 0, 1.2f).SetEase(Ease.InOutSine).OnKill(()=>GameObject.Destroy(Overlay.gameObject));
    }
    void Update()
    {
        
        if (!isWaiting)
        {
            mainText.rectTransform.localScale = Vector3.Lerp(oldScale, oldScale * 1.5f, AudioWAVSync.loudness(bgm.timeSamples, bgm.clip) * 0.5f);
            moveToTarget.rectTransform.localScale = Vector3.Lerp(Vector3.one*1.4f, Vector3.one * 1.4f * 1.5f, AudioWAVSync.loudness(bgm.timeSamples, bgm.clip) * 0.5f);
        }
    }
}
