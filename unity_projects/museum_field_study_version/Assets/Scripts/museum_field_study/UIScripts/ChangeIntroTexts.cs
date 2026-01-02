using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;



public class ChangeIntroTexts : MonoBehaviour
{

    // instruction texts change
    public TextMeshProUGUI[] textsToChange;
    public TextAsset[] instructionTexts;
    //public string[] instructionTextStrings;
    public int textIndex = 0;
    public Button changeButton;
    public GameObject climatePlanCanvas;
    public GameObject guide;
    private bool isButtonPressed = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (changeButton != null)
        {
            changeButton.onClick.AddListener(OnChangeButtonPressed);
        }

     


    }
    private void OnChangeButtonPressed()
    {
        this.isButtonPressed = true; // Set the flag to true when the button is pressed
        Debug.Log("OnChangeButtonPressed(): Button pressed, changing text at index: " + this.textIndex);
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

    void CheckSpecialEvents()
    {

        if (this.textIndex == 2)
        {
            climatePlanCanvas.gameObject.SetActive(true);
        }
        
            // if final text, deactivate continue button
        if (this.textIndex == (instructionTexts.Length-1))
        {
            changeButton.gameObject.SetActive(false);
            guide.gameObject.SetActive(true);
        }
    }

    void Update()
    {
        // Check if continue button was pressed and change the texts accordingly
        if (this.isButtonPressed)
        {

            ChangeTexts();
            CheckSpecialEvents();
            this.textIndex++; // Increment the index for the next text change
            Debug.Log("Update() case 1: new text index for next change is set: " + this.textIndex);
            this.isButtonPressed = false; // Reset the flag after changing texts




        }


   

    }



}
