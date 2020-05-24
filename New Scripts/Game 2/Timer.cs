using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    //total time taken to achieve the selected goal
    private float finalTime;
    //text with the result
    private TextMeshPro timer;
    public static string time;
    void Update()
    {
        timer = gameObject.GetComponent<TextMeshPro>();
        finalTime = SpritesEnable.endTime - SecondGameMenu.startTime;
        string min = Mathf.Floor(finalTime / 60).ToString("00");
        string sec = Mathf.Floor(finalTime % 60).ToString("00");
        time = min + ":" + sec;
        timer.text = time;
    }
}
  