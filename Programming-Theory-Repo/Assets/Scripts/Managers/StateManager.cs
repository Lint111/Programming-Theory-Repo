using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class StateManager : MonoBehaviour
{
    public static StateManager Instance;
    public string playerName = "";
    public int score=0;
       
    //singleton pattern
    public void Awake()
    {
        Singleton();
    }

    //Ending the game function.
    public void EndGame()
    {
        Debug.Log("Game had ended!");
    }

    //Singleton Pattern.
    private void Singleton()
    {
        if(Instance!!=null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
}
