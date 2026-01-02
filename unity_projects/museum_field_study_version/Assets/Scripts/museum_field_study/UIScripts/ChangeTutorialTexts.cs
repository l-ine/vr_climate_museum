using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeTutorialTexts : MonoBehaviour
{
    public AvatarLoader avatarLoader;
    public string[] npcGender = { "female", "male" };
    public string[] conditions = { "mayor", "citizen" };

    public Button tutorialButton;
    //public TMP_InputField id;
    public TMP_Dropdown id1;
    public TMP_Dropdown id2;
    public TMP_Dropdown id3;
    public TMP_Dropdown condition;
    public TMP_Dropdown gender;
    public TMP_Text tutorialTextField;
    public TextAsset[] tutorialTexts;
    public Button testButton;
    public GameObject grabObject;
    public Button startGameButton;
    // public GameObject inventory;
    public int textCounter = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tutorialButton.onClick.AddListener(() =>
        {
            Debug.Log("Tutorial Button Clicked");
            // Add your logic here to change tutorial texts
            OnTutorialButtonClicked();
        });
    }
    void OnTutorialButtonClicked()
    {
        textCounter++;
        ChangeTexts();
    }

    void ChangeTexts()
    {
        if (textCounter == 1)
        {
            Debug.Log("counter 1");
            
            SaveInputsInGameManager();
            avatarLoader.SetAvatars();

            id1.gameObject.SetActive(false);
            id2.gameObject.SetActive(false);
            id3.gameObject.SetActive(false);
            condition.gameObject.SetActive(false);
            gender.gameObject.SetActive(false);

            tutorialButton.gameObject.SetActive(true);
            tutorialButton.GetComponentInChildren<TMP_Text>().text = "Weiter";
            tutorialTextField.gameObject.SetActive(true);
            tutorialTextField.text = tutorialTexts[0].text;
            testButton.gameObject.SetActive(true);
        }

        if (textCounter == 2)
        {
            Debug.Log("counter 2");
            testButton.gameObject.SetActive(false);
            tutorialTextField.text = tutorialTexts[1].text;
            tutorialButton.gameObject.SetActive(true);
            grabObject.SetActive(true);
        }

        if (textCounter == 3)
        {
            Debug.Log("counter 3");
            tutorialTextField.text = tutorialTexts[2].text;
            tutorialButton.gameObject.SetActive(true);
        }

        if (textCounter == 4)
        {
            // Debug.Log("counter 4");
            // tutorialTextField.text = tutorialTexts[3].text;
            // tutorialButton.gameObject.SetActive(true);
            //inventory.SetActive(true);  
            Debug.Log("counter 4");
            tutorialTextField.text = tutorialTexts[3].text;
            tutorialButton.gameObject.SetActive(true);
        }

        if (textCounter == 5)
        {
            // Debug.Log("counter 5");
            // tutorialTextField.text = tutorialTexts[4].text;
            // tutorialButton.gameObject.SetActive(true);
            Debug.Log("counter 5");
            tutorialTextField.text = tutorialTexts[4].text;
            tutorialButton.gameObject.SetActive(false);
            startGameButton.gameObject.SetActive(true);
        }

        // if (textCounter == 6)
        // {
        //     Debug.Log("counter 6");
        //     tutorialTextField.text = tutorialTexts[5].text;
        //     tutorialButton.gameObject.SetActive(false);
        //     startGameButton.gameObject.SetActive(true);

        // }

    }
    void SaveInputsInGameManager()
    {   
        Debug.Log("Changetuttexts, ids: " + id1.value.ToString() + id2.value.ToString() + id3.value.ToString());
        //if (id.text == null || id.text == "")
        //{
        //    GameManager.participant_id = "notnumbered";
        //}
        //else
        //{
            //var participant_id = id1.value.ToString() + id2.value + id3.value;
        GameManager.participant_id = id1.value.ToString() + id2.value.ToString() + id3.value.ToString();
        //}

        Debug.Log("Selected gender: " + gender.value);
        if (gender.value == 0)
        {
            GameManager.gender = "female"; // map control to citizen condition
        }
        else if (gender.value == 1)
        {
            GameManager.gender = "male"; // map control to citizen condition
        }
        else
        {
            GameManager.gender = null; // use selected condition directly
        }
        //GameManager.gender = gender.options[gender.value].text;

        Debug.Log("Selected condition: " + condition.value);
        if (condition.value == 0)
        {
            GameManager.condition = null;
        }
        else if (condition.value == 1)
        {
            GameManager.condition = "citizen"; // map control to citizen condition
        }
        else if (condition.value == 2)
        {
            GameManager.condition = "mayor"; // map control to citizen condition
        }
        else
        {
            Debug.Log("condition not 0, 1, 2");
        }


        string randomString = npcGender[Random.Range(0, npcGender.Length)];
        GameManager.npc_gender = randomString;

        // choose random mayor/citizen condition for female/male participants separately

        if (GameManager.condition == null)
        {
            string randomCondition = conditions[Random.Range(0, conditions.Length)];
            GameManager.condition = randomCondition; // use predefined condition if already set
        }



        GameManager.folderPath = Application.persistentDataPath + "/ExperimentalData"; //"C:/Users/Install/Desktop/ExperimentalData";
        GameManager.filePath = GameManager.folderPath + $"/savefile_{GameManager.participant_id}.json";

        // GameManager.currentLevel = 0;
        // GameManager.currentUrl = "";
        
        
        Debug.Log("GameManager Participant ID, cond, gender, npc_gender: " + GameManager.participant_id + " " + GameManager.condition + " " + GameManager.gender + " " + GameManager.npc_gender);
    }
}
