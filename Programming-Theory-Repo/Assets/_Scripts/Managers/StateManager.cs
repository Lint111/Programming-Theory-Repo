using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class StateManager : MonoBehaviour
{
    public static StateManager Instance;
    public string playerName = "";
    
       
    //singleton pattern
    public void Awake()
    {
        Singleton();        
    }
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
            DataManager.Instance.LoadData();
    }

    //Ending the game function.
    public void EndGame(int score)
    {
        Debug.Log("Game had ended!");
        DataManager.Instance.AddData(score, playerName);
        DataManager.Instance.SaveData();
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
