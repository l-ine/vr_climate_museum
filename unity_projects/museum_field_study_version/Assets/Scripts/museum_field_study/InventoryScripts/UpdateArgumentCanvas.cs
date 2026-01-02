using UnityEngine;
using DialogueEditor;
using System.Collections.Generic;

public class UpdateArgumentCanvas : MonoBehaviour
{
    public GameObject argumentPanel;
    public GameObject snappableArgument;

    // void Update()
    // {
    //     if (ConversationManager.Instance.GetBool("argumentReadyToAppear"))
    //     {
    //         argumentCanvas.SetActive(true);
    //     }
    //     if (ConversationManager.Instance.GetBool("argumentReadyToDisappear"))
    //     {
    //         snapLocation.SetCanvasActive(false);
    //         Destroy(snappableArgument);
    //     }

    // }

    public void ActivateCanvas(GameObject argumentPanel)
    {
        Debug.Log("activated canvas");
        argumentPanel.SetActive(true);
    }

    public void DeactivateCanvas(GameObject argumentPanel)
    {
        Debug.Log("deactivated canvas");
        argumentPanel.SetActive(false);
        
    }
    public void DeactivateArgument(GameObject snappableArgument)
    {
        Debug.Log("deactivated argument");
        snappableArgument.SetActive(false);
    }
    
    // public void DestroySnappableArgument(GameObject snappableArgument)
    // {
    //     if (snappableArgument != null)
    //     {
    //         Debug.Log("destroxed snappable argument");
    //         Destroy(snappableArgument);
    //     }
    // }
}
