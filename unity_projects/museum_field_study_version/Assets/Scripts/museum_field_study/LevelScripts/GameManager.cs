using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static string participant_id;
    public static string condition;
    public static string gender = "female";
    public static string folderPath;
    public static string filePath;
    public static string npc_gender = "female"; // default, will be set randomly in each game start
    public static int currentLevel = 0;
    public static string currentUrl = "";
}
