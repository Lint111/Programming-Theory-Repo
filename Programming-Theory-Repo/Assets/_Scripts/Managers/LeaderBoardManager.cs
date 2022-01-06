using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderBoardManager : MonoBehaviour
{    
    [SerializeField] private List<GameObject> Boards;    
    
    public void UpdateLeaderBoard()
    {
        DataManager DM = DataManager.Instance;
        for (int i=0; i < Boards.Count;i++)
        {            
            TMP_Text text1 = Boards[i].GetComponentsInChildren<TMP_Text>()[0];            
            TMP_Text text2 = Boards[i].GetComponentsInChildren<TMP_Text>()[1];            
            text1.text = DM.playerNames[i];
            text2.text = DM.highScores[i].ToString();            
        }
    }
}
