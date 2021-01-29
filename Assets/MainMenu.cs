using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int levelID;

    void Start()
    {
        var gameData = SaveSystem.Instance.GetGameData();

        levelID = gameData.level;
    }

    public void ContinueBtn()
    {
        SceneManager.LoadScene("level_"+levelID);
    }
}
