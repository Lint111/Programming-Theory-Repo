using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string[] playerNames = new string[10];    
    public int[] highScores = new int[10];
    public void Awake()
    {
        Singleton();
        LoadData();
    }
    [System.Serializable]
    class Data
    {
        public string[] playerNames = new string[10];
        public int[] highScores = new int[10];  
    }
    public void AddData(int score, string name)
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Data data = JsonUtility.FromJson<Data>(json);            

            int tmpInt1 = 0;
            int tmpInt2 = 0;
            string tmpString1 = "";
            string tmpString2 = "";
            for (int i = data.playerNames.Length - 1; i > 0; i--)
            {
                if (score > highScores[i])
                {
                    tmpInt1 = highScores[i];
                    tmpString1 = playerNames[i];
                    highScores[i] = score;
                    playerNames[i] = name;

                    for (int j = i - 1; j > 0; j--)
                    {
                        tmpInt2 = highScores[j];
                        tmpString2 = playerNames[j];
                        highScores[j] = tmpInt1;
                        playerNames[j] = tmpString1;
                        tmpInt1 = tmpInt2;
                        tmpString1 = tmpString2;
                    }
                }
                return;
            }
        }
    }

    public void SaveData()
    {
        Data data = new Data();
        data.playerNames = CopyToArray<string>(data.playerNames, playerNames);
        data.highScores = CopyToArray<int>(data.highScores, highScores);

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Data data = JsonUtility.FromJson<Data>(json);

            playerNames = CopyToArray<string>(playerNames, data.playerNames);
            highScores = CopyToArray<int>(highScores, data.highScores);            
        }
    }
    public void ResetData()
    {        
        Data data = new Data();     
                
        data.playerNames = CopyToArray<string>(data.playerNames, "");
        data.highScores = CopyToArray<int>(data.highScores, 0);
        playerNames = CopyToArray<string>(playerNames, "");
        highScores = CopyToArray<int>(highScores, 0);
        

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    private void Singleton()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private T[] CopyToArray<T>(T[] reciving, T[] providing)
    {
        if (reciving.Length != providing.Length) return null;
        for(int i=0;i<reciving.Length;i++)
        {
            reciving[i] = providing[i];
        }
        return reciving;
    }
    private T[] CopyToArray<T>(T[] reciving, T providing)
    {        
        for (int i = 0; i < reciving.Length; i++)
        {
            reciving[i] = providing;
        }
        return reciving;
    }
}
