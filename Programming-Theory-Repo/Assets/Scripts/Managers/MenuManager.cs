using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenuManager : MonoBehaviour
{     
    
    public void NewGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void EnterMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    
}
