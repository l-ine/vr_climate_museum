using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeTutorialTexts : MonoBehaviour
{
    public Button tutorialButton;
    public TMP_InputField id;
    public TMP_InputField condition;
    public TMP_Text tutorialTextField;
    public TextAsset[] tutorialTexts;
    public Button testButton;
    public GameObject grabObject;
    public Button startGameButton;
    public GameObject inventory;
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
            SaveInputs();
            id.gameObject.SetActive(false);
            condition.gameObject.SetActive(false);

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
            Debug.Log("counter 4");
            tutorialTextField.text = tutorialTexts[3].text;
            tutorialButton.gameObject.SetActive(true);
            inventory.SetActive(true);  
        }

        if (textCounter == 5)
        {
            Debug.Log("counter 5");
            tutorialTextField.text = tutorialTexts[4].text;
            tutorialButton.gameObject.SetActive(true);
        }

        if (textCounter == 6)
        {
            Debug.Log("counter 6");
            tutorialTextField.text = tutorialTexts[5].text;
            tutorialButton.gameObject.SetActive(false);
            startGameButton.gameObject.SetActive(true);

        }

    }
    void SaveInputs()
    {
        // PlayerPrefs.SetString("PlayerID", id.text);
        // PlayerPrefs.SetString("Condition", condition.text);
        // Debug.Log("Saved PlayerID: " + id.text);
        // Debug.Log("Saved Condition: " + condition.text);
        GameManager.participant_id = id.text;
        GameManager.condition = condition.text;
    }
}
