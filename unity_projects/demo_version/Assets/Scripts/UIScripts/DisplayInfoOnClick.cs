using UnityEngine;
using UnityEngine.UI;
using System.Collections; 
using TMPro;

public class DisplayInfoOnClick : MonoBehaviour
{
    public GameObject[] infoPanels;
    //public GameObject[] infoTexts;
    public Button[] buttons; // Array of buttons to trigger the info texts
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private bool[] isExpanded; // Array to track the expanded state of each info text

    void Start()
    {
        isExpanded = new bool[buttons.Length]; 

        // add listener to all buttons in the button list
        for (int i = 0; i < buttons.Length; i++)
        {
            int buttonIndex = i;
            buttons[buttonIndex].onClick.AddListener(() => OnOverlayButtonPressed(buttonIndex));
        }
        
    }

    private void OnOverlayButtonPressed(int buttonIndex)
    {
        // Hide all info texts and buttons but the selected one
        //buttons[buttonIndex].GetComponentInChildren<Text>().text = "-"; // TODO: set "-" if text is displayed, see llama idea with boolean
        
        for (int i = 0; i < buttons.Length; i++)
        {
            
            if (i != buttonIndex)
            {
                isExpanded[i] = false;
                buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = "<";
                infoPanels[i].SetActive(false); 
            }
            
            else
            {
                isExpanded[i] =!isExpanded[i];

                if (isExpanded[i])
                {
                    infoPanels[i].SetActive(true);
                    buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = ">";
                }
                else
                {
                    infoPanels[i].SetActive(false);
                    buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = "<";
                }
            }
            

        }

    }
}
