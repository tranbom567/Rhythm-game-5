using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class InitUtils : MonoBehaviour
{
    public static GameObject initPlayer(GameObject player,string playableName)
    {
        GameObject playerInit = GameObject.Instantiate(player);
        playerInit.GetComponent<MoveDuringGameTime>().pd = Resources.Load<PlayableDirector>($"Levels/{playableName}");
        playerInit.GetComponent<MoveDuringGameTime>().TimeLine = GameObject.FindWithTag("Timeline");
        playerInit.GetComponent<MoveDuringGameTime>().timeLineAnimator = GameObject.FindWithTag("Timeline").GetComponent<Animator>();
        return playerInit;
    }
}
