using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public List<Transform> checkpoints = new List<Transform>();

    private int checkpoint;

    void Start()
    {
        var gameData = SaveSystem.Instance.GetGameData();
        checkpoint = gameData.checkpoint;

        Instantiate(playerPrefab, checkpoints[checkpoint-1].position, Quaternion.identity);
    }
}