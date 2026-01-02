using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;


[System.Serializable]
public class ButtonArray
{
    public Button[] buttons;
}

[System.Serializable]
public class TextAssetArray
{
    public TextAsset[] textAssets;
}

public class ChangeCanvasTexts : MonoBehaviour
{

    // instruction texts change
    public TextMeshProUGUI[] textsToChange;
    public TextAsset[] instructionTexts;
    //public string[] instructionTextStrings;
    public int textIndex = 0;
    public Button changeButton;
    private bool isButtonPressed = false;


    // answer texts change
    public TextAssetArray[] answerTexts; // Text assets for answer options
    //public string[] answerTextStrings;
    private bool correct = false;
    public GameObject feedbackPanel;
    [SerializeField] public ButtonArray[] buttonArrays;
    public bool[][] answerButtonPressed = new bool[][] {
        new bool[] { false, false },
        new bool[] { false, false, false },
        new bool[] { false, false } };
    public bool isAnswerButtonPressed = false; // Flag to check if an answer button was pressed
    public bool[][] correctAnswers = new bool[][] {
        new bool[] { true, false },
        new bool[] { false, false, true },
        new bool[] { true, false }};

    int questionIndex = 0; // Index to track which question is being answered
    int answerIndex = 0; // Index to track which answer is being checked


    // formulated statements to grab and drag into the inventory
    public TextAsset[] statementsTexts; // Array of TextAssetArrays for formulated statements
    public GameObject[] grabbableStatement;
    public bool level2Completed = false;

    //public MoveArgumentToInventory[] moveArgToInventory;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (changeButton != null)
        {
            changeButton.onClick.AddListener(OnChangeButtonPressed);
        }

        // instructionTextStrings = new string[instructionTexts.Length];

        // // fill instruction textassets into list of strings
        // for (int i = 0; i < instructionTexts.Length; i++)
        // {
        //     if (instructionTexts[i] != null)
        //     {
        //         instructionTextStrings[i] = instructionTexts[i].text;
        //     }
        //     else
        //     {
        //         instructionTextStrings[i] = string.Empty; // Handle null TextAssets
        //     }
        // }

        //answerTextStrings = new string[answerTexts.Length];

        // // fill instruction textassets into list of strings
        // for (int i = 0; i < answerTexts.Length; i++)
        // {
        //     if (answerTexts[i] != null)
        //     {
        //         answerTextStrings[i] = answerTexts[i].text;
        //     }
        //     else
        //     {
        //         answerTextStrings[i] = string.Empty; // Handle null TextAssets
        //     }
        // }

        // fill button texts from text assets
        for (int i = 0; i < buttonArrays.Length; i++)
        {
            if (buttonArrays[i].buttons != null)
            {
                for (int j = 0; j < buttonArrays[i].buttons.Length; j++)
                {
                    int questionIdx = i;
                    int answerIdx = j;
                    Button button = buttonArrays[i].buttons[j];
                    button.gameObject.SetActive(false);
                    button.GetComponentInChildren<TextMeshProUGUI>().text = answerTexts[i].textAssets[j].text;
                    button.onClick.AddListener(() => OnAnswerButtonPressed(questionIdx, answerIdx));
                }
            }
        }

        for (int i = 0; i < grabbableStatement.Length; i++)
        {
            if (grabbableStatement[i] != null)
            {
                grabbableStatement[i].SetActive(false);
                grabbableStatement[i].GetComponentInChildren<TextMeshPro>().text = statementsTexts[i].text;
            }
        }



    }
    private void OnChangeButtonPressed()
    {
        this.isButtonPressed = true; // Set the flag to true when the button is pressed
        Debug.Log("OnChangeButtonPressed(): Button pressed, changing text at index: " + this.textIndex);
    }

    private void OnAnswerButtonPressed(int questionIdx, int answerIdx)
    {
        Debug.Log("OnAnswerButtonPressed(): this.answerButtonPressed[questionIndex][answerIndex] for question i" + questionIdx + ", answer j" + answerIdx);
        this.isAnswerButtonPressed = true;
        this.answerButtonPressed[questionIdx][answerIdx] = true;
    }




    private void ChangeTexts()
    {
        if (this.textIndex >= instructionTexts.Length)
        {
            Debug.Log("ChangeTexts(): No more texts to change or index out of bounds.");
            return; // Exit if there are no more texts to change
        }
        textsToChange[0].text = instructionTexts[this.textIndex].text; // currently changing only the text of the first TextMeshProUGUI component (more TMPs will follow)
        Debug.Log("ChangeTexts(): Text changed to text no.: " + this.textIndex);

    }

    private void ShowAnswerOptions()
    {
        switch (this.textIndex)
        {
            case 0:
                // Show options for text index 0
                break;
            case 1:
                // Show options for text index 1
                break;
            case 2:
                // Show options for text index 2
                break;
            case 3:
                // Show options for text index 2
                ActivateButtons(this.questionIndex, 2); // Activate buttons for question 1 with 2 answers
                break;
            case 4:
                // Show options for text index 2
                DeactivateButtons(this.questionIndex, 2);
                grabbableStatement[0].SetActive(true);
                break;
            case 5:
                // Show options for text index 2
                //grabbableStatement[0].SetActive(false);
                // evtl hardcoden, statements in inventar setzen, falls spieler es nicht schafft per draganddrop
                grabbableStatement[0].GetComponent<MoveArgumentToInventory>().MoveToInventory();
                ActivateButtons(this.questionIndex, 3); // Activate buttons for question 2 with 3 answers
                break;
            case 6:
                DeactivateButtons(this.questionIndex, 3);
                grabbableStatement[1].SetActive(true);
                break;
            case 7:
                //grabbableStatement[1].SetActive(false);
                // evtl hardcoden, statements in inventar setzen, falls spieler es nicht schafft per draganddrop
                grabbableStatement[1].GetComponent<MoveArgumentToInventory>().MoveToInventory();
                break;
            case 8:
                // Show options for text index 2
                ActivateButtons(this.questionIndex, 2); // Activate buttons for question 3 with 4 answers
                break;
            case 9:
                DeactivateButtons(this.questionIndex, 2);
                grabbableStatement[2].SetActive(true);
                break;
            case 10:
                grabbableStatement[2].GetComponent<MoveArgumentToInventory>().MoveToInventory();
                changeButton.gameObject.SetActive(false);
                //grabbableStatement[2].SetActive(false);
                // evtl hardcoden, statements in inventar setzen, falls spieler es nicht schafft per draganddrop
                break;
            default:
                Debug.LogWarning("ShowAnswerOptions(): No options defined for this text index.");
                break;
        }
    }
    void ActivateButtons(int questionIndex, int answerIndex)
    {
        for (int i = 0; i < buttonArrays[questionIndex].buttons.Length; i++)
        {
            buttonArrays[questionIndex].buttons[i].gameObject.SetActive(true);
            //toggleArrays[questionIndex].toggles[i].gameObject.SetActive(true); // Activate the toggles for the current question
            //buttons[questionIndex][answerIndex].gameObject.SetActive(true); // Hide all buttons initially
        }
        changeButton.gameObject.SetActive(false); // Hide the change button when answer options are shown

    }

    void DeactivateButtons(int questionIndex, int answerIndex)
    {
        for (int i = 0; i < buttonArrays[questionIndex].buttons.Length; i++)
        {
            buttonArrays[questionIndex].buttons[i].gameObject.SetActive(false);
            //toggleArrays[questionIndex].toggles[i].gameObject.SetActive(false); // Deactivate the toggles for the current question
            //buttons[questionIndex][answerIndex].gameObject.SetActive(true); // Hide all buttons initially
        }
        changeButton.gameObject.SetActive(true); // Show the change button when answer options are hidden

        
    }

    void CheckAnswer(int questionIndex)
    {
        // for each button in the current question, check if it was pressed
        // and if the answer is correct or not
        for (int i = 0; i < buttonArrays[questionIndex].buttons.Length; i++)
        //for (int i = 0; i < toggleArrays[questionIndex].toggles.Length; i++)
        {
            Debug.Log("CheckAnswer(): answerButtonPressed for question " + questionIndex + ", answer " + i + ": " + answerButtonPressed[questionIndex][i]);
            if (answerButtonPressed[questionIndex][i] == true)
            {
                //if (toggleOnScript.ToggleValueChanged(toggleArrays[questionIndex].toggles[i]))
                if (correctAnswers[questionIndex][i])
                {
                    Debug.Log("CheckAnswer(): Correct answer selected for question " + questionIndex + ", answer " + answerIndex);
                    this.correct = true;

                }
                else if (!correctAnswers[questionIndex][i])
                {
                    Debug.Log("CheckAnswer(): Incorrect answer selected for question " + questionIndex + ", answer " + answerIndex);
                    feedbackPanel.SetActive(true);
                    this.correct = false;
                }
            }
        }


    }

    // TODO: prettify update !!!
    void Update()
    {
        // Check if continue button was pressed and change the texts accordingly
        if (this.isButtonPressed)
        {

            ChangeTexts();
            ShowAnswerOptions(); // Show options based on the current text index
            this.textIndex++; // Increment the index for the next text change
            Debug.Log("Update() case 1: new text index for next change is set: " + this.textIndex);
            this.isButtonPressed = false; // Reset the flag after changing texts
            this.correct = false; // Reset the correct flag for the next question
            feedbackPanel.SetActive(false); // Hide feedback panel after processing the answer
        }


        if (this.isAnswerButtonPressed)
        {
            CheckAnswer(this.questionIndex);
            Debug.Log("Update() case 2: Checking answer for question " + this.questionIndex + " with text index " + this.textIndex);

            if (this.correct)
            {
                Debug.Log("Update() case 2: Correct answer selected");
                ChangeTexts();
                ShowAnswerOptions(); // Show options based on the current text index
                this.textIndex++; // Increment the index for the next text change
                Debug.Log("Update() case 2: new text index for next change is set: " + this.textIndex);
                this.isButtonPressed = false; // Reset the flag after changing texts
                this.isAnswerButtonPressed = false;
                for (int i = 0; i < answerButtonPressed[this.questionIndex].Length; i++)
                {
                    answerButtonPressed[this.questionIndex][i] = false; // Reset the answer button pressed state
                }
                this.correct = false; // Reset the correct flag for the next question
                feedbackPanel.SetActive(false); // Hide feedback panel after processing the answer
                this.questionIndex += 1; // Update the question index
            }

            else if (!this.correct)
            {
                this.isAnswerButtonPressed = false;
                Debug.Log("Update() case 2: Incorrect answer selected");
                for (int i = 0; i < answerButtonPressed[this.questionIndex].Length; i++)
                {
                    answerButtonPressed[this.questionIndex][i] = false; // Reset the answer button pressed state
                }
            }
        }

        if (this.textIndex == instructionTexts.Length)
        {
            level2Completed = true; // Set level2Completed to true when all texts are processed
        }

    }



}
