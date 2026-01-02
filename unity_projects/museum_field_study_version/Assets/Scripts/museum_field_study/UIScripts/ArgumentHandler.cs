using UnityEngine;
using System.Collections;

public class ArgumentHandler : MonoBehaviour
{
    private int textIndex;
    public UpdateArgumentCanvas updateArgumentCanvas;
    public GameObject[] panels;
    public CheckArgument[] snapLocations;
    public MoveArgumentToInventory[] snapArguments;
    public GameObject[] argumentObjects;
    public bool correctArgumentDropped = false;
    public ChangeConversationTexts changeConvTexts;
    private string argumentChosenTag;
    private string[] snapInteractorTags;
    //public bool falseArgDetected = false;

    void Start()
    {
        snapInteractorTags = new string[] { "SnappableArgument1", "SnappableArgument2", "SnappableArgument3", "SnappableArgument4" };
    }
    public void Handle(int textIndex)
    {
        switch (textIndex)
        {
            case 2:
                updateArgumentCanvas.ActivateCanvas(panels[0]);
                Debug.Log("ArgumentHandler: Activated argument canvas for text index 2");
                break;
            
            case 3:
                Debug.Log("ArgumentHandler: Handling argument check for text index 3");
                
                this.argumentChosenTag = snapLocations[0].GetChosenArgument(this.snapInteractorTags);
                Debug.Log("ArgumentHandler: Found snapped argument: " + this.argumentChosenTag);
                
                if (this.argumentChosenTag == "SnappableArgument1")
                {
                    Debug.Log("ArgumentHandler: correct argument dropped for text index 2");
                    correctArgumentDropped = true;
                    changeConvTexts.textIndex = 4;
                    changeConvTexts.falseArgDetected = false;
                    break;
                }
                
                    
                
                else 
                {
                    changeConvTexts.falseArgDetected = true;
                    Debug.Log("False arg");
                    changeConvTexts.textIndex = 3;
                    if (this.argumentChosenTag == "SnappableArgument2")
                    {
                        snapArguments[1].MoveToInventory();
                        
                        snapArguments[1].ColourRed();
                    }
                    else if (this.argumentChosenTag == "SnappableArgument3")
                    {
                        snapArguments[2].MoveToInventory();
                        snapArguments[2].ColourRed();
                    }
                    else if (this.argumentChosenTag == "SnappableArgument4")
                    {
                        snapArguments[3].MoveToInventory();
                        snapArguments[3].ColourRed();
                    }
                }
                
                
                break;

            case 5:
                Debug.Log("ArgumentHandler, index 5: deactivate panel and argument object");
                updateArgumentCanvas.DeactivateArgument(argumentObjects[0]);
                updateArgumentCanvas.DeactivateCanvas(panels[0]);
                for (int i = 0; i < snapArguments.Length; i++)
                {
                    snapArguments[i].ColourOriginal();
                }
                break;



            case 6:
                updateArgumentCanvas.ActivateCanvas(panels[1]);
                Debug.Log("ArgumentHandler: Activated argument canvas for text index 6");
                break;
            case 7:
                Debug.Log("ArgumentHandler: Handling argument check for text index 7");
                
                argumentChosenTag = snapLocations[1].GetChosenArgument(snapInteractorTags);
                Debug.Log("ArgumentHandler: Found snapped argument: " + argumentChosenTag);
                
                if (argumentChosenTag == "SnappableArgument2")
                {
                    Debug.Log("ArgumentHandler: correct argument dropped for text index 7");
                    correctArgumentDropped = true;
                    changeConvTexts.textIndex = 8;
                    changeConvTexts.falseArgDetected = false;
                }
                
                else
                {
                    Debug.Log("Move to inventory called for all other arguments");
                    changeConvTexts.falseArgDetected = true;
                    changeConvTexts.textIndex = 7;
                    if (argumentChosenTag == "SnappableArgument1")
                    {
                        snapArguments[0].MoveToInventory();
                        snapArguments[0].ColourRed();
                    }
                    else if (argumentChosenTag == "SnappableArgument3")
                    {
                        snapArguments[2].MoveToInventory();
                        snapArguments[2].ColourRed();
                    }
                    else if (argumentChosenTag == "SnappableArgument4")
                    {
                        snapArguments[3].MoveToInventory();
                        snapArguments[3].ColourRed();
                    }
                }
                
                
                //changeConvTexts.textIndex--;
                
                break;

            case 9:
                Debug.Log("ArgumentHandler, index 8: deactivate panel and argument object");
                updateArgumentCanvas.DeactivateArgument(argumentObjects[1]);
                updateArgumentCanvas.DeactivateCanvas(panels[1]);
                for (int i = 0; i < snapArguments.Length; i++)
                {
                    snapArguments[i].ColourOriginal();
                }
                break;



            case 10:
                updateArgumentCanvas.ActivateCanvas(panels[2]);
                Debug.Log("ArgumentHandler: Activated argument canvas for text index 10");
                break;
            case 11:
                Debug.Log("ArgumentHandler: Handling argument check for text index 11");
                
                argumentChosenTag = snapLocations[2].GetChosenArgument(snapInteractorTags);
                Debug.Log("ArgumentHandler: Found snapped argument: " + argumentChosenTag);
                
                if (argumentChosenTag == "SnappableArgument4")
                {
                    Debug.Log("ArgumentHandler: correct argument dropped for text index 11");
                    correctArgumentDropped = true;
                    changeConvTexts.textIndex = 12;
                }
                
                else
                {
                    changeConvTexts.falseArgDetected = true;
                    Debug.Log("Move to inventory called for all other arguments");
                    changeConvTexts.textIndex = 11;
                    if (argumentChosenTag == "SnappableArgument1")
                    {
                        snapArguments[0].MoveToInventory();
                        snapArguments[0].ColourRed();
                    }
                    else if (argumentChosenTag == "SnappableArgument2")
                    {
                        snapArguments[1].MoveToInventory();
                        snapArguments[1].ColourRed();
                    }
                    else if (argumentChosenTag == "SnappableArgument3")
                    {
                        snapArguments[2].MoveToInventory();
                        snapArguments[2].ColourRed();
                    }

                }
                
                
                
                
                break;

            case 13:
                Debug.Log("ArgumentHandler, index 5: deactivate panel and argument object");
                updateArgumentCanvas.DeactivateArgument(argumentObjects[3]);
                updateArgumentCanvas.DeactivateCanvas(panels[2]);
                for (int i = 0; i < snapArguments.Length; i++)
                {
                    snapArguments[i].ColourOriginal();
                }
                break;



            case 15:
                updateArgumentCanvas.ActivateCanvas(panels[3]);
                Debug.Log("ArgumentHandler: Activated argument canvas for text index 15");
                break;
            case 16:
                Debug.Log("ArgumentHandler: Handling argument check for text index 3");
                
                argumentChosenTag = snapLocations[3].GetChosenArgument(snapInteractorTags);
                Debug.Log("ArgumentHandler: Found snapped argument: " + argumentChosenTag);
                
                if (argumentChosenTag == "SnappableArgument3")
                {
                    Debug.Log("ArgumentHandler: correct argument dropped for text index 16");
                    correctArgumentDropped = true;
                    changeConvTexts.textIndex = 17;
                }

                else
                {
                    changeConvTexts.falseArgDetected = true;
                    Debug.Log("Move to inventory called for all other arguments");
                    changeConvTexts.textIndex = 16;
                    if (argumentChosenTag == "SnappableArgument1")
                    {
                        snapArguments[0].MoveToInventory();
                        snapArguments[0].ColourRed();
                    }
                    else if (argumentChosenTag == "SnappableArgument2")
                    {
                        snapArguments[1].MoveToInventory();
                        snapArguments[1].ColourRed();
                    }
                    else if (argumentChosenTag == "SnappableArgument4")
                    {
                        snapArguments[3].MoveToInventory();
                        snapArguments[3].ColourRed();
                    }
                }
                
                
                // changeConvTexts.textIndex--;
                
                break;

            case 18:
                Debug.Log("ArgumentHandler, index 5: deactivate panel and argument object");
                updateArgumentCanvas.DeactivateArgument(argumentObjects[2]);
                updateArgumentCanvas.DeactivateCanvas(panels[3]);
                for (int i = 0; i < snapArguments.Length; i++)
                {
                    snapArguments[i].ColourOriginal();
                }
                break;


            default:
                Debug.Log("ArgumentHandler: No argument handling for text index " + textIndex);
                break;
        }
        
    }
}
