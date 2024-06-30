using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BPMSync : MonoBehaviour
{
    private static float bpm;
    public AudioSource BGMAudio;
    public UnityEvent[] e;
    public static void changeBPM(float targetBPM)
    {
        bpm = targetBPM;
    }
    void Start()
    {
        StartCoroutine(bpmStart());
    }

    IEnumerator bpmStart()
    {
        while (true)
        {
            yield return new WaitUntil(() => MenuManager.getInstance.menuBg.BPM != 0);
            yield return new WaitUntil(() => MenuManager.getInstance.isReplaceClip);
            yield return new WaitUntil(() => BGMAudio.clip.loadState == AudioDataLoadState.Loaded);
            yield return new WaitForSeconds(60 / MenuManager.getInstance.menuBg.BPM);
            Debug.Log(60 / MenuManager.getInstance.menuBg.BPM);
            foreach (UnityEvent @event in e)
                @event.Invoke();
            yield return null;
        }
    }
    void Update()
    {
        
    }
}
