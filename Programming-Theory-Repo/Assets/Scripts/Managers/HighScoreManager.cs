using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;   

public class HighScoreManager : MonoBehaviour
{
    public TMP_Text highScoreText;
    private int highScore = 0;
    private string playerName="";
   
    //may be used to add or remove points.
    public void AddScore(int points)
    {
        playerName = StateManager.Instance.playerName;
        highScore += points;
        highScoreText.text = $"{playerName} points: {highScore}";
    }
    public int GetScore()
    {
        return highScore;
    }
}
