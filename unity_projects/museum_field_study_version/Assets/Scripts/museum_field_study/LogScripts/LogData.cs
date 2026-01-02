using UnityEngine;
using System.IO;
using System.Linq;
using static System.DateTime;
using System.Collections.Generic;

public class LogData : MonoBehaviour
{
    public GameObject player;

    public void AddNewEntry(string notes)
    {
        // Create a new entry
        PlayerData newEntry = new PlayerData
        {
            currDate = Now.ToString("dd.MM.yyyy"),
            currTime = Now.ToString("HH:mm:ss:fff"),
            participant_id = GameManager.participant_id, // Set as needed
            condition = GameManager.condition,  // Set as needed
            gender = GameManager.gender,           // Set as needed
            npc_gender = GameManager.npc_gender,    // Set as needed
            currentLevel = GameManager.currentLevel,              // Set as needed
            currentUrl = GameManager.currentUrl,        // Set as needed
            notes = notes, // Set as needed
            playerPosition = player.transform.position, // Set as needed
            playerRotation = player.transform.rotation.eulerAngles // Set as needed
        };

        PlayerDataList dataList = new PlayerDataList();
        dataList.data = new List<PlayerData>();

        // Load existing data if file exists
        if (File.Exists(GameManager.filePath))
        {
            string json = File.ReadAllText(GameManager.filePath);
            dataList = JsonUtility.FromJson<PlayerDataList>(json);
        }

        // Append new entry
        dataList.data.Add(newEntry);

        // Save back to file
        string jsonToSave = JsonUtility.ToJson(dataList, true);
        File.WriteAllText(GameManager.filePath, jsonToSave);

        Debug.Log("New entry added to: " + GameManager.filePath);
    }
}