using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.DateTime;
using System.Globalization;

public class LogSliderChanges : MonoBehaviour
{
   
    // // public string participant_id;
    // // public string condition;
    // public InitializeLogFile initializeLogFile;
    // // public static string folderPath;
    // // public static string filePath;
    // //public MenuManager menuManager;

    // private Dictionary<string, string> sliderValues = new Dictionary<string, string>();
    // private Dictionary<string, string> currentSliders = new Dictionary<string, string>();

    // public EnvironmentUpdate environmentUpdate;
    // public SliderPositions sliderPositions;
    // public SliderTimeline sliderTimeline;
    // public SliderPingPong sliderPingPong;
    // public TextChanger changePhases;
    // //public MenuManager menuManager;
    

    // public void Start()
    // {
    //     //Debug.Log("PERSISTANT PATH:" + Application.persistentDataPath);
    // }

    // // method to save clicks on the sliders in the simulator, i.e. slider_id (e.g. coal = 1, oil = ...) and slider_value (value to which slider was set)
    // // is called in EnvironmentUpdate() when also getting the slider values for the environmental updates
    // public void SaveSliderValues(string url)
    // {
    //     UnityEngine.Debug.Log("save slider values");
    //     int questionMarkIndex = url.IndexOf('?');

    //     if (questionMarkIndex >= 0)
    //     {
    //         string queryString = url.Substring(questionMarkIndex + 1);
    //         string[] parameters = queryString.Split('&');

    //         using (StreamWriter writer = new StreamWriter(GameManager.filePath, true))
    //         {
    //             // Check if the file is empty and write the headline
    //             if (new FileInfo(GameManager.filePath).Length == 0)
    //             {
    //                 writer.WriteLine($"participant_id,condition,date,time,phase,task,slider_id,slider_value,slider_reset,button,year,temp,task_response,task_correct,response_note,slider_id_used_in_task,slider_value_in_task,notes");
    //             }

    //             foreach (string parameter in parameters)
    //             {
    //                 string[] parts = parameter.Split('=');

    //                 if (parts.Length == 2)
    //                 {
    //                     string slider_id = parts[0];

    //                     if (slider_id.Contains("p"))
    //                     {
    //                         slider_id = slider_id.Replace("p", "");
    //                     }
    //                     if (slider_id.Contains("v") || slider_id.Contains("lang"))
    //                     {
    //                         continue;
    //                     }

    //                     string slider_value = parts[1];

    //                     string currTime = Now.ToString("hh:mm:ss");
    //                     string currDate = Now.ToString("dd/MM/yyyy");
    //                     //bool slider_reset = false;
                        
                        
    //                     // Check if the slider value has never occurred before or has changed
    //                     if (!sliderValues.ContainsKey(slider_id) || sliderValues[slider_id] != slider_value)
    //                     {
    //                         writer.WriteLine($"{GameManager.participant_id},{GameManager.condition},{currDate},{currTime},{changePhases.phaseIndex},{changePhases.taskIndex},{slider_id},{slider_value},,{sliderPingPong.pressedButton},{environmentUpdate.yearSelector},{environmentUpdate.tempProg.ToString("0.0", CultureInfo.InvariantCulture) + "°C"},,,,,,{"slider changed on website"}");
    //                         sliderValues[slider_id] = slider_value;
    //                     }

    //                     // // save the slider id and value always (in additional columns), even if it has not changed, to check if/how the slider was used in a specific task
    //                     // writer.WriteLine($"{GameManager.participant_id},{GameManager.condition},{currDate},{currTime},{changePhases.phaseIndex},{changePhases.taskIndex},,,{slider_reset},{sliderPositions.pressedButton},{environmentUpdate.yearSelector},{environmentUpdate.tempProg.ToString("0.0", CultureInfo.InvariantCulture) + "°C"},,,{slider_id},{slider_value},{"participant logged in the sliders"}");
    //                     // sliderValues[slider_id] = slider_value;
    //                 }
    //             }
    //         }
    //     }
    // }

    // public void SaveSliderValuesForTask(string url)
    // {
    //     UnityEngine.Debug.Log("save slider values");
    //     int questionMarkIndex = url.IndexOf('?');

    //     if (questionMarkIndex >= 0)
    //     {
    //         string queryString = url.Substring(questionMarkIndex + 1);
    //         string[] parameters = queryString.Split('&');

    //         using (StreamWriter writer = new StreamWriter(GameManager.filePath, true))
    //         {
    //             // Check if the file is empty and write the headline
    //             if (new FileInfo(GameManager.filePath).Length == 0)
    //             {
    //                 writer.WriteLine($"participant_id,condition,date,time,phase,task,slider_id,slider_value,slider_reset,button,year,temp,task_response,task_correct,response_note,slider_id_used_in_task,slider_value_in_task,notes");
    //             }

    //             foreach (string parameter in parameters)
    //             {
    //                 string[] parts = parameter.Split('=');

    //                 if (parts.Length == 2)
    //                 {
    //                     string slider_id = parts[0];

    //                     if (slider_id.Contains("p"))
    //                     {
    //                         slider_id = slider_id.Replace("p", "");
    //                     }
    //                     if (slider_id.Contains("v") || slider_id.Contains("lang"))
    //                     {
    //                         continue;
    //                     }

    //                     string slider_value = parts[1];

    //                     string currTime = Now.ToString("hh:mm:ss");
    //                     string currDate = Now.ToString("dd/MM/yyyy");
    //                     //bool slider_reset = false;
                        
                        
    //                     // // Check if the slider value has never occurred before or has changed
    //                     // if (!sliderValues.ContainsKey(slider_id) || sliderValues[slider_id] != slider_value)
    //                     // {
    //                     //     writer.WriteLine($"{GameManager.participant_id},{GameManager.condition},{currDate},{currTime},{changePhases.phaseIndex},{changePhases.taskIndex},{slider_id},{slider_value},{slider_reset},{sliderPositions.pressedButton},{environmentUpdate.yearSelector},{environmentUpdate.tempProg.ToString("0.0", CultureInfo.InvariantCulture) + "°C"},,,,,,{"slider changed on website"}");
    //                     //     sliderValues[slider_id] = slider_value;
    //                     // }

    //                     // save the slider id and value always (in additional columns), even if it has not changed, to check if/how the slider was used in a specific task
    //                     writer.WriteLine($"{GameManager.participant_id},{GameManager.condition},{currDate},{currTime},{changePhases.phaseIndex},{changePhases.taskIndex},,,,{sliderPingPong.pressedButton},{environmentUpdate.yearSelector},{environmentUpdate.tempProg.ToString("0.0", CultureInfo.InvariantCulture) + "°C"},,,,{slider_id},{slider_value},{"participant logged in this slider"}");
    //                     sliderValues[slider_id] = slider_value;
    //                 }
    //             }
    //         }
    //     }
    // }
    
    // public Dictionary<string, string> getCurrentSliders(string url)
    // {
    //     int questionMarkIndex = url.IndexOf('?');

    //     if (questionMarkIndex >= 0)
    //     {
    //         string queryString = url.Substring(questionMarkIndex + 1);
    //         string[] parameters = queryString.Split('&');
    //         currentSliders.Clear(); // Clear the dictionary before counting used sliders

    //         foreach (string parameter in parameters)
    //         {
    //             string[] parts = parameter.Split('=');

    //             if (parts.Length == 2)
    //             {
    //                 string slider_id = parts[0];

    //                 if (slider_id.Contains("p"))
    //                 {
    //                     slider_id = slider_id.Replace("p", "");
    //                 }
    //                 if (slider_id.Contains("v") || slider_id.Contains("lang"))
    //                 {
    //                     continue;
    //                 }

    //                 string slider_value = parts[1];

                    
    //                 currentSliders[slider_id] = slider_value;
    //             }
    //         }
            
    //     }
    //     return currentSliders;
    // }
    // public int CountUsedSliders(string url)
    // {
    //     Debug.Log("Number of used sliders: " + currentSliders.Count);
    //     return getCurrentSliders(url).Count;
    // }



    // // method to save clicks on the time slider under the simulator, i.e. play/pause button and simulated year at that moment
    // // is called in SliderPositions() when starting/stopping the moving time slider
    // public void SaveTimeLineYear(string year)
    // {
    //     //UnityEngine.Debug.Log("save button values");
    //     using (StreamWriter writer = new StreamWriter(GameManager.filePath, true))
    //         {
    //             // Check if the file is empty and write the headline
    //             if (new FileInfo(GameManager.filePath).Length == 0)
    //             {
    //                 writer.WriteLine($"participant_id,condition,date,time,phase,task,slider_id,slider_value,slider_reset,button,year,temp,task_response,task_correct,notes");
    //             }
    //             string currTime = Now.ToString("hh:mm:ss");
    //             string currDate = Now.ToString("dd/MM/yyyy");
    //             writer.WriteLine($"{GameManager.participant_id},{GameManager.condition},{currDate},{currTime},{changePhases.phaseIndex},{changePhases.taskIndex},,,,,{year},{environmentUpdate.tempProg.ToString("0.0", CultureInfo.InvariantCulture) + "°C"},,,,,,{"timeline slider changed"}");
    //         }
    // }

    // public void SaveTimeLineButton()
    // {
    //     //UnityEngine.Debug.Log("save button values");
    //     using (StreamWriter writer = new StreamWriter(GameManager.filePath, true))
    //         {
    //             // Check if the file is empty and write the headline
    //             if (new FileInfo(GameManager.filePath).Length == 0)
    //             {
    //                 writer.WriteLine($"participant_id,condition,date,time,phase,task,slider_id,slider_value,slider_reset,button,year,temp,task_response,task_correct,notes");
    //             }
    //             string currTime = Now.ToString("hh:mm:ss");
    //             string currDate = Now.ToString("dd/MM/yyyy");
    //             writer.WriteLine($"{GameManager.participant_id},{GameManager.condition},{currDate},{currTime},{changePhases.phaseIndex},{changePhases.taskIndex},,,,{sliderPingPong.pressedButton},{environmentUpdate.yearSelector},{environmentUpdate.tempProg.ToString("0.0", CultureInfo.InvariantCulture) + "°C"},,,,,,{"timeline play/pause button pressed"}");
    //         }
    // }
    


    // // method to save the current phase and task in the phase (e.g. phase "exercise", task 1)
    // public void SavePhaseStart()
    // {
    //     //UnityEngine.Debug.Log("save phase start");
    //     using (StreamWriter writer = new StreamWriter(GameManager.filePath, true))
    //         {
    //             // Check if the file is empty and write the headline
    //             if (new FileInfo(GameManager.filePath).Length == 0)
    //             {
    //                 writer.WriteLine($"participant_id,condition,date,time,phase,task,slider_id,slider_value,slider_reset,button,year,temp,task_response,task_correct,notes");
    //             }
    //             string currTime = Now.ToString("hh:mm:ss");
    //             string currDate = Now.ToString("dd/MM/yyyy");
    //             bool slider_reset = true;
    //             writer.WriteLine($"{GameManager.participant_id},{GameManager.condition},{currDate},{currTime},{changePhases.phaseIndex},{changePhases.taskIndex},,,{slider_reset},,{environmentUpdate.yearSelector},{environmentUpdate.tempProg.ToString("0.0", CultureInfo.InvariantCulture) + "°C"},,,,,,{"phase started"}");
    //         }
    // }

    // public void SavePhaseEnd()
    // {
    //     //UnityEngine.Debug.Log("save phase end");
    //     using (StreamWriter writer = new StreamWriter(GameManager.filePath, true))
    //         {
    //             // Check if the file is empty and write the headline
    //             if (new FileInfo(GameManager.filePath).Length == 0)
    //             {
    //                 writer.WriteLine($"participant_id,condition,date,time,phase,task,slider_id,slider_value,slider_reset,button,year,temp,task_response,task_correct,notes");
    //             }
    //             string currTime = Now.ToString("hh:mm:ss");
    //             string currDate = Now.ToString("dd/MM/yyyy");
    //             writer.WriteLine($"{GameManager.participant_id},{GameManager.condition},{currDate},{currTime},{changePhases.phaseIndex},{changePhases.taskIndex},,,,,{environmentUpdate.yearSelector},{environmentUpdate.tempProg.ToString("0.0", CultureInfo.InvariantCulture) + "°C"},,,,,,{"phase ended"}");
    //         }
    // }

    
    // public void SaveTaskStart()
    // {
    //     //UnityEngine.Debug.Log("save phase end");
    //     using (StreamWriter writer = new StreamWriter(GameManager.filePath, true))
    //         {
    //             // Check if the file is empty and write the headline
    //             if (new FileInfo(GameManager.filePath).Length == 0)
    //             {
    //                 writer.WriteLine($"participant_id,condition,date,time,phase,task,slider_id,slider_value,slider_reset,button,year,temp,task_response,task_correct,notes");
    //             }
    //             string currTime = Now.ToString("hh:mm:ss");
    //             string currDate = Now.ToString("dd/MM/yyyy");
    //             bool slider_reset = true;
    //             writer.WriteLine($"{GameManager.participant_id},{GameManager.condition},{currDate},{currTime},{changePhases.phaseIndex},{changePhases.taskIndex},,,{slider_reset},{sliderPingPong.pressedButton},{environmentUpdate.yearSelector},{environmentUpdate.tempProg.ToString("0.0", CultureInfo.InvariantCulture) + "°C"},,,,,,{"task started"}");
    //         }
    // }

    // public void SaveTaskEnd()
    // {
    //     //UnityEngine.Debug.Log("save phase end");
    //     using (StreamWriter writer = new StreamWriter(GameManager.filePath, true))
    //         {
    //             // Check if the file is empty and write the headline
    //             if (new FileInfo(GameManager.filePath).Length == 0)
    //             {
    //                 writer.WriteLine($"participant_id,condition,date,time,phase,task,slider_id,slider_value,slider_reset,button,year,temp,task_response,task_correct,notes");
    //             }
    //             string currTime = Now.ToString("hh:mm:ss");
    //             string currDate = Now.ToString("dd/MM/yyyy");
    //             writer.WriteLine($"{GameManager.participant_id},{GameManager.condition},{currDate},{currTime},{changePhases.phaseIndex},{changePhases.taskIndex},,,,{sliderPingPong.pressedButton},{environmentUpdate.yearSelector},{environmentUpdate.tempProg.ToString("0.0", CultureInfo.InvariantCulture) + "°C"},,,,,,{"task ended"}");
    //         }
    // }

    // public void SaveResponse()
    // {
    //     //UnityEngine.Debug.Log("save phase end");
    //     using (StreamWriter writer = new StreamWriter(GameManager.filePath, true))
    //         {
    //             // Check if the file is empty and write the headline
    //             if (new FileInfo(GameManager.filePath).Length == 0)
    //             {
    //                 writer.WriteLine($"participant_id,condition,date,time,phase,task,slider_id,slider_value,slider_reset,button,year,temp,task_response,task_correct,notes");
    //             }
    //             string currTime = Now.ToString("hh:mm:ss");
    //             string currDate = Now.ToString("dd/MM/yyyy");
    //             writer.WriteLine($"{GameManager.participant_id},{GameManager.condition},{currDate},{currTime},{changePhases.phaseIndex},{changePhases.taskIndex},,,,{sliderPingPong.pressedButton},{environmentUpdate.yearSelector},{environmentUpdate.tempProg.ToString("0.0", CultureInfo.InvariantCulture) + "°C"},{changePhases.response},{changePhases.response_correct},{changePhases.response_note},,,{"response given"}");
    //         }
    // }
}