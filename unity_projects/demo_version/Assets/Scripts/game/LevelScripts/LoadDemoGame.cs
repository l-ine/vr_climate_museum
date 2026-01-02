using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadDemoGame : MonoBehaviour
{
    public string sceneToLoad;
    public Button startButton;
    public InitializeLog initializeLog;

    void Start()
    {
        startButton.onClick.AddListener(LoadGameOnButtonClick);
    }
    public void LoadGameOnButtonClick()
    {
        initializeLog.initializeLog(GameManager.participant_id, GameManager.condition);

        int randomNum = Random.Range(1, 4);
        if (randomNum == 1)
        {
            sceneToLoad = "Demo_VRClimateMuseum";
        }
        else if (randomNum == 2)
        {
            sceneToLoad = "Demo_VRClimateMuseum";
        }
        else if (randomNum == 3)
        {
            sceneToLoad = "Demo_VRClimateMuseum";
        }
        
        Debug.Log("Loading scene: " + sceneToLoad);
        SceneManager.LoadScene(sceneToLoad);
    }
}