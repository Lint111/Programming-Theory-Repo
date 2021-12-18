using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    [SerializeField]
    private int gameLengthInSeconds=60;

    private int currentTimeLeft;

    [SerializeField]
    private TMP_Text timer;
    
    private void Awake()
    {
        currentTimeLeft = gameLengthInSeconds;
        StartCoroutine(time());
    }

    //may be used to add or lose time while the game run.
    private void AddTime(int timeGain)
    {
        currentTimeLeft += timeGain;
        UpdateTimer();
    }

    //runs every second.
    IEnumerator time()
    {
        while (currentTimeLeft > 0)
        {
            yield return new WaitForSeconds(1f);
            currentTimeLeft--;
            UpdateTimer();
        }
        StateManager.Instance.EndGame();
    }

    //update timer UI text.
    private void UpdateTimer()
    {
        timer.text = $"{currentTimeLeft}";
    }
}
