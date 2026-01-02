using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadDemoGame : MonoBehaviour
{
    public LogData logData;
    public string sceneToLoad;
    public Button startButton;
    //public InitializeLog initializeLog;

    public string[] npcGender = { "female", "male" };
    public string[] condition = { "mayor", "citizen" };

    void Start()
    {
        startButton.onClick.AddListener(LoadGameOnButtonClick);
    }
    public void LoadGameOnButtonClick()
    {
        // choose random gender for NPC
        //string randomString = npcGender[Random.Range(0, npcGender.Length)];
        //GameManager.npc_gender = randomString;

        //// choose random mayor/citizen condition for female/male participants separately

        //if (GameManager.condition == null)
        //{
        //    string randomCondition = condition[Random.Range(0, condition.Length)];
        //    GameManager.condition = randomCondition; // use predefined condition if already set
        //}

        // load selected scene
        SceneManager.LoadScene(sceneToLoad); // "Munich_VRClimateMuseum"
        Debug.Log("Scene loaded with following GameManager info: " + GameManager.condition + " " + GameManager.gender  + " " + GameManager.npc_gender);

        // save initial game start data
        //initializeLog.initializeLog(GameManager.participant_id, GameManager.condition, GameManager.gender, GameManager.npc_gender);
        
        logData.AddNewEntry("game started");
        
    }
}