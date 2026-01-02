using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;
using System.Collections;

public class ChangeConversationTexts : MonoBehaviour
{

    public TextMeshProUGUI[] textsToChange;
    public TextAsset[] speechTexts;
    public TextAsset[] answerTexts;
    public int textIndex = 0;
    public Button answerButton;
    private bool isButtonPressed = false;
    public ShowOverlay showOverlay;
    public GameObject inventory;
    public LogData logData;
    public bool falseArgDetected = false;
    public bool isArgClicked = false;
    public TeleportPlayer teleport;
    public ArgumentCheck argumentCheck;
    private int lastRequiredIndexHandled = -1;

    public enum CANVAS_LOCATION
    {
        INTRO,
        LEVEL1,
        LEVEL3_DEBATE,
        LEVEL3_OUTRO
    }
    
    public CANVAS_LOCATION canvasLocation;

    // variables for canvas location outside
    public GameObject guideText;

    public ArgumentHandler argumentHandler;
    public GameObject outro;
    public FadeOut fadeOut;


    void Start()
    {
        if (answerButton != null)
        {
            answerButton.onClick.AddListener(OnButtonPressed);
        }
    }

    void Update()
    {
        if (this.canvasLocation ==CANVAS_LOCATION.LEVEL3_DEBATE)
        {
            CheckSelectedArgument();
        }
        if (this.isButtonPressed)
        {
            
            CheckSpecialEvents();
            if (!falseArgDetected)
            {
                ChangeTexts();
                this.textIndex++;
            }
                
            Debug.Log("Update() case 1: new text index for next change is set: " + this.textIndex);
            this.isButtonPressed = false;
        }
    }

    private void OnButtonPressed()
    {
        this.isButtonPressed = true;
    }


    private void ChangeTexts()
    {
        if (this.textIndex >= speechTexts.Length)
        {
            Debug.Log("ChangeTexts(): No more texts to change or index out of bounds.");
            return;
        }
        textsToChange[0].text = speechTexts[this.textIndex].text; // for debugging: this.textIndex.ToString() + 
        textsToChange[1].text = answerTexts[this.textIndex].text;
        Debug.Log("ChangeTexts(): Text changed to text no.: " + this.textIndex);
        
    }

    private void HandleLastTextReached()
    {
        Debug.Log("handleLastTextReached(): Last text reached, handling accordingly.");
        
        this.gameObject.SetActive(false);
        answerButton.gameObject.SetActive(false);
        showOverlay.ActivateOverlayCanvas(guideText);
    

    }

    void CheckSpecialEvents()
    {
        if (this.canvasLocation == CANVAS_LOCATION.LEVEL1)
        {
            if (this.textIndex == (answerTexts.Length))
            {
                teleport.StartTeleport();

            }
            
        }
        

        if (this.canvasLocation == CANVAS_LOCATION.LEVEL3_DEBATE)
        {
            //argumentHandler.Handle(this.textIndex);
            if (this.textIndex == 2)
            {
                inventory.gameObject.SetActive(true);
            }

            if (this.textIndex == 4)
            {
                argumentCheck.buttons[0].gameObject.SetActive(false);

            }
            if (this.textIndex == 7)
            {
                argumentCheck.buttons[1].gameObject.SetActive(false);
            }
            if (this.textIndex == 10)
            {
                argumentCheck.buttons[3].gameObject.SetActive(false);
            }
            if (this.textIndex == 14)
            {
                argumentCheck.buttons[2].gameObject.SetActive(false);
            }

            if (textIndex != 3 && textIndex != 6 && textIndex != 9 && textIndex != 13)
            {
                for (int i = 0; i < argumentCheck.buttons.Length; i++)
                {
                    // reset button colors to default
                    argumentCheck.buttons[i].GetComponent<UnityEngine.UI.Image>().color = argumentCheck.originalColor; // Color.white;
                }
            }

            if (this.textIndex == (answerTexts.Length))
            {
                outro.gameObject.SetActive(true);
                teleport.StartTeleport();

            }
        }

        if (this.canvasLocation == CANVAS_LOCATION.LEVEL3_OUTRO)
        {
            if (this.textIndex == (answerTexts.Length))
            {
                showOverlay.ActivateOverlayCanvas(guideText);
                logData.AddNewEntry("outro ended");
                StartCoroutine("WaitAndFadeOut");
                
            }

        }

        if (this.textIndex == (answerTexts.Length))
        {
            HandleLastTextReached();
        }
    }
    public IEnumerator WaitAndFadeOut()
    {
        yield return new WaitForSeconds(5.0f);
        fadeOut.fadeOut();
        Debug.Log("Quit application called.");
        logData.AddNewEntry("application quit");
        Application.Quit();
        
    }

    public void CheckSelectedArgument()
    {
        int[] requiredIndices = { 3, 6, 9, 13 };
        bool isRequiredIndex = Array.Exists(requiredIndices, idx => idx == this.textIndex);

        if (isRequiredIndex)
        {
            // first time we enter this required index: lock progression until ArgumentCheck sets falseArgDetected = false
            if (lastRequiredIndexHandled != this.textIndex)
            {
                Debug.Log("first time entering index 3");
                lastRequiredIndexHandled = this.textIndex;
                falseArgDetected = true; // block by default until correct argument chosen
                if (answerButton != null)
                    answerButton.interactable = false;
                if (inventory != null)
                    inventory.SetActive(true);

                Debug.Log($"Argument required at textIndex {this.textIndex}. Awaiting correct argument click.");
            }
            else
            {
                Debug.Log("not first time to enter index 3, falseargdetected = " + falseArgDetected);

                // we're still on the same required index; if ArgumentCheck cleared the flag, re-enable the answer button
                if (!falseArgDetected)
                {
                    if (answerButton != null)
                        answerButton.interactable = true;

                }
            }
        }
        else
        {
            // not a required index: ensure normal behavior (reset lock)
            falseArgDetected = false;
            if (answerButton != null)
                answerButton.interactable = true;
        }
    }

}
