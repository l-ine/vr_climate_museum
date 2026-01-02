using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowOverlayCanvas : MonoBehaviour
{
    public GameObject overlayCanvas;
    public GameObject Anchor;
    bool UIActive;
    public ConversationInformer conversationInformer;
    public TextAsset[] guideTexts;
    public TextMeshProUGUI guideTextDisplay;
    //public int guideTextIndex = 0;

    public SliderPingPong sliderPingPong;

    public Button disappearButton;
    public bool isButtonPressed = false;

    private void Start()
    {
        //overlayCanvas.SetActive(false);
        UIActive = false;
        disappearButton.onClick.AddListener(OnDisappearButtonPressed);


    }



    public void OnDisappearButtonPressed()
    {
        Debug.Log("OnDisappearButtonPressed(): Disappear button pressed.");
        isButtonPressed = true; // Set the button state to true
        overlayCanvas.SetActive(false); // Hide the overlay canvas
    }

    private void Update()
    {
        if (GuideRequired() > -1)
        {
            //UIActive = !UIActive;

            overlayCanvas.SetActive(true);
            //}
            //if (UIActive)
            //{
            Debug.Log("Update(): Overlay canvas is active. Adjusting text, position and rotation.");
            AdjustTextDisplay(GuideRequired());
            overlayCanvas.transform.position = Anchor.transform.position;
            overlayCanvas.transform.eulerAngles = new Vector3(Anchor.transform.eulerAngles.x + 15, Anchor.transform.eulerAngles.y, 0);
        }

        // if (isButtonPressed)
        // {
        //     Debug.Log("Update(): Disappear button pressed. Hiding overlay canvas.");
        //     overlayCanvas.SetActive(false);
        //     isButtonPressed = false; // Reset the button state
        // }
    }
    private int GuideRequired()
    {
        Debug.Log("GuideRequired(): Checking if guide is required.");
        if (sliderPingPong.isButtonPressed)
        {
            return 0;
        }
        else
        {
            return -1;
        }
    }

    private void AdjustTextDisplay(int guideTextIndex)
    {
        Debug.Log("AdjustTextDisplay(): Adjusting text display for guide texts with index: " + guideTextIndex);
        if (guideTexts.Length > 0)
        {
            if (guideTextIndex < guideTexts.Length)
            {
                guideTextDisplay.text = guideTexts[guideTextIndex].text;
            }
            else
            {
                guideTextDisplay.text = "No more guides available.";
            }
        }
        else
        {
            guideTextDisplay.text = "No guides available.";
        }
        //guideTextIndex++;
    }
}
