using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenuManager : MonoBehaviour
{         
    public void NewGame()
    {
        StateManager.Instance.playerName = GameObject.Find("Name Input").GetComponent<TMP_InputField>().text;
        DataManager.Instance.SaveData();
        SceneManager.LoadScene("GamePlay");        
    }
    public void EnterMenu()
    {
        DataManager.Instance.LoadData();
        SceneManager.LoadScene("Menu");        
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
