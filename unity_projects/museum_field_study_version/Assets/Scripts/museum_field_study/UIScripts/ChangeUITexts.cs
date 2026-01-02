using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;

public class ChangeUITexts : MonoBehaviour
{

    public TextMeshProUGUI[] textsToChange;
    public TextAsset[] instructionTexts;
    public int textIndex = 0;
    public Button changeButton;
    public TextMeshProUGUI buttonText;
    private bool isButtonPressed = false;
    public bool level2Completed = false;
    public ShowOverlay showOverlay;
    public GameObject guideText;
    public TeleportPlayer teleport;
    public GameObject simulator;
    public LoadSimulator browser;


    public enum CANVAS_LOCATION
    {
        OUTSIDE,
        INTRO,
        LEVEL1,
        LEVEL2,
        LEVEL3
    }
    public CANVAS_LOCATION canvasLocation;


    // variables for canvas location outside
    public GameObject climatePlanCanvas;
    public GameObject guidePolly;
    public GameObject timeSliderIntro;

    // variables for canvas location level 2
    public GameObject inventoryArea;

    void Start()
    {
        if (changeButton != null)
        {
            changeButton.onClick.AddListener(OnChangeButtonPressed);
        }
    }

    void Update()
    {
        //Debug.Log("Update(): isButtonPressed = " + this.isButtonPressed);
        if (this.isButtonPressed)
        {
            ChangeTexts();
            CheckSpecialEvents();
            this.textIndex++;
            Debug.Log("Update(): new text index for next change is set: " + this.textIndex);
            this.isButtonPressed = false;
        }
    }

    private void OnChangeButtonPressed()
    {
        this.isButtonPressed = true;
    }


    private void ChangeTexts()
    {
        if (this.textIndex >= instructionTexts.Length)
        {
            Debug.Log("ChangeTexts(): No more texts to change or index out of bounds.");
            return;
        }
        textsToChange[0].text = instructionTexts[this.textIndex].text; // for debugging: this.textIndex.ToString() + 
        Debug.Log("ChangeTexts(): Text changed to text no.: " + this.textIndex);

    }

    void CheckSpecialEvents()
    {
        if (this.canvasLocation == CANVAS_LOCATION.OUTSIDE)
        {
            if (this.textIndex == 2)
            {
                climatePlanCanvas.gameObject.SetActive(true);
            }
            if (this.textIndex == 3)
            {
                timeSliderIntro.gameObject.SetActive(true);
            }

            if (this.textIndex == (instructionTexts.Length - 1))
            {
                // change text on button
                //changeButton.gameObject.SetActive(false);
                buttonText = changeButton.GetComponentInChildren<TextMeshProUGUI>();
                buttonText.text = "Teleport";
                //guidePolly.gameObject.SetActive(true);


            }
            if (this.textIndex == instructionTexts.Length)
            {
                // teleport
                
                teleport.StartTeleport();
                Debug.Log("teleport started");
            }
        }
        if (this.canvasLocation == CANVAS_LOCATION.LEVEL2)
        {
            if (this.textIndex == 1)
            {
                simulator.gameObject.SetActive(true);
            }
            if (this.textIndex == 2)
            {
                buttonText = changeButton.GetComponentInChildren<TextMeshProUGUI>();
                buttonText.text = "Erhöhe Energieeffizienz";
            }
            if (this.textIndex == 3)
            {
                browser.loadUrl("https://en-roads.climateinteractive.org/scenario.html?v=25.11.0&p47=5&lang=de");
                buttonText = changeButton.GetComponentInChildren<TextMeshProUGUI>();
                buttonText.text = "Fördere erneuerbare Energien";
            }
            if (this.textIndex == 4)
            {
                browser.loadUrl("https://en-roads.climateinteractive.org/scenario.html?v=25.11.0&p16=-0.05&p47=5&lang=de");
                buttonText = changeButton.GetComponentInChildren<TextMeshProUGUI>();
                buttonText.text = "Weiter";
                inventoryArea.gameObject.SetActive(true);
            }
            if (this.textIndex == 6)
            {
                buttonText = changeButton.GetComponentInChildren<TextMeshProUGUI>();
                buttonText.text = "Erhöhe den CO2-Preis";
            }
            if (this.textIndex == 7)
            {
                browser.loadUrl("https://en-roads.climateinteractive.org/scenario.html?v=25.11.0&p16=-0.05&p39=250&p47=5&lang=de");
                buttonText = changeButton.GetComponentInChildren<TextMeshProUGUI>();
                buttonText.text = "Weiter";
            }
            if (this.textIndex == (instructionTexts.Length - 1))
            {
                //changeButton.gameObject.SetActive(false);
                //showOverlay.ActivateOverlayCanvas(guideText);
                buttonText = changeButton.GetComponentInChildren<TextMeshProUGUI>();
                buttonText.text = "Teleport";
                level2Completed = true;

                
            }
            if (this.textIndex == instructionTexts.Length)
            {
                // teleport

                teleport.StartTeleport();
                Debug.Log("teleport started");
            }

        }
    }

   

}
