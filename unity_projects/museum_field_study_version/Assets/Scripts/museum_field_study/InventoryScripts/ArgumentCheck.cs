using UnityEngine;
using UnityEngine.UI;

public class ArgumentCheck : MonoBehaviour
{
    public Button[] buttons;
    public Color originalColor;
    public ChangeConversationTexts changeConvTextsMayor;
    public ChangeConversationTexts changeConvTextsCitizen;
    public ChangeConversationTexts changeConvTexts;

    public enum InventoryPosition
    {
        Level2,
        Level3
    }

    


    public InventoryPosition inventoryPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalColor = buttons[0].GetComponent<UnityEngine.UI.Image>().color;
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[i].onClick.AddListener(() => OnChangeButtonPressed(index));
        }

        if (changeConvTextsCitizen != null && changeConvTextsCitizen.enabled)
        {
            changeConvTexts = changeConvTextsCitizen;
        }
        else if (changeConvTextsMayor != null && changeConvTextsMayor.enabled)
        {
            changeConvTexts = changeConvTextsMayor;
        }
    }


    public void OnChangeButtonPressed(int i)
    {
        //changeConvTexts.isArgClicked = true;
        if (this.inventoryPosition == InventoryPosition.Level2)
        {
            CheckArgumentsLevel2(i);
        }
        else if (this.inventoryPosition == InventoryPosition.Level3)
        {
            CheckArgumentsLevel3(i);
        }
        

    }

    public void CheckArgumentsLevel2(int i)
    {
        if (buttons[i].tag == "TrueArg")
        {
            CorrectArgSet(buttons[i]);
        }
        else
        {
            IncorrectArgSet(buttons[i]);
        }
        
    }

    public void CheckArgumentsLevel3(int i)
    {
        Debug.Log("Checking arguments level 3, button index: " + i + ", text index: " + changeConvTexts.textIndex);
        if (i == 0 && changeConvTexts.textIndex == 3)
        {
            CorrectArgSet(buttons[i]);
            changeConvTexts.falseArgDetected = false;
            Debug.Log("first arg pressed");
        }
        else if (i == 1 && changeConvTexts.textIndex == 6)
        {
            CorrectArgSet(buttons[i]);
            changeConvTexts.falseArgDetected = false;
            Debug.Log("second arg pressed");

        }
        else if (i == 2 && changeConvTexts.textIndex == 13)
        {
            CorrectArgSet(buttons[i]);
            changeConvTexts.falseArgDetected = false;
            Debug.Log("third arg pressed");

        }
        else if (i == 3 && changeConvTexts.textIndex == 9)
        {
            CorrectArgSet(buttons[i]);
            changeConvTexts.falseArgDetected = false;
            Debug.Log("fourth arg pressed");

        }
        else
        {
            IncorrectArgSet(buttons[i]);
            changeConvTexts.falseArgDetected = true;
            Debug.Log("falseargdetected set to true in argcheck");
        }
        changeConvTexts.isArgClicked = false;
    }

    public void CorrectArgSet(Button button)
    {
        // button becomes green
        button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
    }
    public void IncorrectArgSet(Button button)
    {
        //buttons becomes red
        button.GetComponent<UnityEngine.UI.Image>().color = Color.red;
    }
}
