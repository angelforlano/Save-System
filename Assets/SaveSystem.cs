using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    const string fileName = "/gameData.data";
    public GameData gameData = new GameData();

    void Awake()
    {
        Load();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            gameData.gold += 85;
        }

        // Save.
        if (Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }

        // Load.
        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }

        // New Game.
        if (Input.GetKeyDown(KeyCode.R))
        {
            NewGame();
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + fileName, FileMode.Create);
        
        bf.Serialize(stream, gameData);
        stream.Close();

        Debug.Log("Saved!");
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + fileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + fileName, FileMode.Open);
            
            gameData = bf.Deserialize(stream) as GameData;
            stream.Close();

            Debug.Log("Loaded!");
        } else {
            Save();
        }
    }

    public void NewGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + fileName, FileMode.Create);
        
        gameData = new GameData();

        bf.Serialize(stream, gameData);
        stream.Close();

        Debug.Log("New Game Created!");
    }
}
