using UnityEngine;
using DialogueEditor;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Meta.XR;
using Oculus.Interaction.Input;
using UnityEngine;
using UnityEngine.Serialization;
using Oculus.Interaction;

public class CheckArgument : MonoBehaviour
{
    public GameObject snapLocation;
    public string snapInteractorName;
    public GameObject startLocation;
    public void IsArgumentCorrect(string snapInteractorName)
    {
        Debug.Log("CheckArgument: IsArgumentCorrect called with snapInteractorName: " + snapInteractorName);
        // check if correct argument (via tag) is snapped to snaplocation 1
        //var correctSnapInteractor = snapLocation.FindComponentInChildWithTag<SnapInteractor>(snapInteractorTag);

        var correctSnapInteractor = snapLocation.transform.Find(snapInteractorName);
        if (correctSnapInteractor == null)
        {
            Debug.LogError("CheckArgument: correct SnapInteractor NOT found in snapLocation");
            ConversationManager.Instance.SetBool("correctArgumentDropped", false);
            return;
        }
        else
        {
            Debug.LogError("CheckArgument: correct SnapInteractor found in snapLocation");
            ConversationManager.Instance.SetBool("correctArgumentDropped", true);
        }
    }    
    
    
}