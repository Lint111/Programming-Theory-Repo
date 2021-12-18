using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;   

public class HighScoreManager : MonoBehaviour
{
    public TMP_Text highScoreText;
    private int highScore = 0;
    
    //may be used to add or remove points.
    public void AddScore(int points)
    {
        highScore += points;
        highScoreText.text = $"points: {highScore}";
    }
    public int GetScore()
    {
        return highScore;
    }
}
