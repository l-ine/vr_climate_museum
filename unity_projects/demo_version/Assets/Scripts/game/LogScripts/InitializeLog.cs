using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.DateTime;
using UnityEngine.Events;

public class InitializeLog : MonoBehaviour
{

    private Dictionary<string, string> sliderValues = new Dictionary<string, string>();
    //private Dictionary<string, string> currentSliders = new Dictionary<string, string>();

    

    public void Start()
    {
        //Debug.Log("PERSISTANT PATH:" + Application.persistentDataPath);
        GameManager.folderPath = Application.persistentDataPath + "/ExperimentalData"; //"C:/Users/Install/Desktop/ExperimentalData";  
    }

    public void initializeLog(string id, string condition)
    {
        GameManager.participant_id = id;
        GameManager.condition = condition;

        // ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        id = "00";              // !!! this line is only for debug purposes !!!
        condition = "test";   // !!! this line is only for debug purposes !!!
        // ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        GameManager.filePath = GameManager.folderPath + "/exp_data_" + id + ".csv";
        if (!File.Exists(GameManager.filePath))
        {
            using (StreamWriter writer = new StreamWriter(GameManager.filePath, true))
            {
                writer.WriteLine($"participant_id,condition,date,time,phase,task,slider_id,slider_value,slider_reset,button,year,temp,task_response,task_correct,response_note,slider_id_used_in_task,slider_value_in_task,notes");
                string currTime = Now.ToString("hh:mm:ss");
                string currDate = Now.ToString("dd/MM/yyyy");
                writer.WriteLine($"{id},{condition},{currDate},{currTime},,,,,,,,,,,,,,{"game started"}");
            }
            Debug.Log("Log file created: " + GameManager.filePath);
        }
        // Check if the file already exists and load existing slider values
        else
        {
            string[] lines = File.ReadAllLines(GameManager.filePath);
            if (lines.Length > 1)
            {
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split(',');
                    if (parts.Length == 13) // currently we store 13 variables, needs to be adjusted with more
                    {
                        string slider_id = parts[4];
                        string slider_value = parts[5];
                        sliderValues[slider_id] = slider_value;
                    }
                }
            }
        }
    }
}