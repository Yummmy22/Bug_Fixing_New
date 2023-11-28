using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class CountdownText : MonoBehaviour
{

    public delegate void CountdownFinished();
    public static event CountdownFinished OnCountdownFinished;


    Text countdown;

    void OnEnable()
    {
        countdown = GetComponent<Text>();
        countdown.text = "3";
        StartCoroutine("Countdown");
    }

    IEnumerator Countdown()
    {
        int count = 3;
        float originalTimeScale = Time.timeScale;
        Time.timeScale = 0;
        for (int i = 0; i < count; i++)
        {
            countdown.text = (count - i).ToString();
            yield return new WaitForSecondsRealtime(1);
        }
        Time.timeScale = 1f;

        if (OnCountdownFinished != null)
        {
            OnCountdownFinished();
        }

        countdown.text = "";
        gameObject.SetActive(false);
    }

}