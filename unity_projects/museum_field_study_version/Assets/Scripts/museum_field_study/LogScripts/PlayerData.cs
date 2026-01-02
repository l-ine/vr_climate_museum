using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


[System.Serializable]
public class PlayerData
{
    public string currDate;
    public string currTime;
    public string participant_id;
    public string condition;
    public string gender;
    public string npc_gender;
    public int currentLevel;
    public Vector3 playerPosition;
    public Vector3 playerRotation;
    public string currentUrl;

    public string notes;
}

[System.Serializable]
public class PlayerDataList
{
    public List<PlayerData> data;
}