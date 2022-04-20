using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameData : MonoBehaviour
{
    public static GameData Instance;
    public string PlayerName;
    public int HighScore;


    public void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadGame();
    }

    [System.Serializable]
    class SaveData
    {
        public string pName;
        public int pHighScore;
    }

    public void SaveGame()
    {
        SaveData data = new SaveData();
        data.pName = PlayerName;
        data.pHighScore = HighScore;


        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }
    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerName = data.pName;
            HighScore = data.pHighScore;


        }
    }
}
