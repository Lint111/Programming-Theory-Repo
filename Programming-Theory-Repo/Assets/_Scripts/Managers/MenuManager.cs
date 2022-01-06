using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenuManager : MonoBehaviour
{
    GameObject Menu;
    GameObject LeaderBoards;
    TMP_InputField InputField;

    private void Awake()
    {
        Menu = GameObject.Find("Main Menu");
        LeaderBoards = GameObject.Find("LeaderBoard");
        LeaderBoards.SetActive(false);
        InputField = GameObject.Find("Name Input").GetComponent<TMP_InputField>();
    }
    public void NewGame()
    {
        string nameInput = InputField.text;
        StateManager.Instance.playerName = nameInput;
        DataManager.Instance.SaveData();
        SceneManager.LoadScene("GamePlay");        
    }
    public void EnterMenu()
    {
        if (SceneManager.GetActiveScene().name != "Menu")
        {
            DataManager.Instance.LoadData();
            SceneManager.LoadScene("Menu");
        }
        else
        {            
            Menu.SetActive(true);
            LeaderBoards.SetActive(false);
        }
    }
    public void EnterLeaderBoard()
    {        
        Menu.SetActive(false);
        LeaderBoards.SetActive(true);
    }
    public void Quit()
    {
        DataManager.Instance.SaveData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    
}
