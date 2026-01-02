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
    //public string[] snapInteractorTags;
    public bool correctArgumentChosen = false;
    public GameObject argumentChosen;
    public string argumentChosenTag;

    void Start()
    {
        
    }

    public string GetChosenArgument(string[] snapInteractorTags)
    {
        for (int i = 0; i < snapInteractorTags.Length; i++)
        {
            Debug.Log("CheckArgument: Checking for argument with tag: " + snapInteractorTags[i]);
            argumentChosen = FindObjectInChildWithName(snapLocation, snapInteractorTags[i]);
            if (argumentChosen != null)
            {
                return snapInteractorTags[i];
                Debug.Log("CheckArgument: findChosenArgument found argument with tag: " + snapInteractorTags[i]);
                break;
            }
            Debug.Log("CheckArgument: Checking for argument with tag: " + snapInteractorTags[i] + "NOT FOUND");
        }
        return "";
    }

    public bool IsArgumentCorrect(string correctSnapInteractorTag)
    {
        return true;
        // argumentChosenTag = GetChosenArgument(snapInteractorTags);
        
        // if (argumentChosenTag == correctSnapInteractorTag)
        // {
        //     correctArgumentChosen = true;
        // }
        // else
        // {
        //     correctArgumentChosen = false;
        // }
        // return correctArgumentChosen;
    }

    
    

    public GameObject FindObjectInChildWithName (GameObject parent, string name)
    {
        Transform t = parent.transform;

        for (int i = 0; i < t.childCount; i++) 
        {
            if(t.GetChild(i).gameObject.name == name)
            {
                return t.GetChild(i).gameObject;
            }
                
        }
            
        return null;
    }

    // not working with tags unfortunately, this is why we used names above
    public static GameObject FindGameObjectInChildWithTag (GameObject parent, string tag)
	{
		Transform t = parent.transform;

		for (int i = 0; i < t.childCount; i++) 
		{
			if(t.GetChild(i).gameObject.tag == tag)
			{
				return t.GetChild(i).gameObject;
			}
				
		}
			
		return null;
	}
        
        // argumentChosen = FindGameObjectInChildWithTag(this.snapLocation, correctSnapInteractorTag);
        // return argumentChosen;
        
        // if (snapLocation == null) return null;

        // // try to find by child name first
        // var child = snapLocation.transform.Find(snapInteractorName);
        // if (child != null) return child.gameObject;

        // // fallback: try to find a SnapInteractor component in children and return its gameObject
        // var snapComp = snapLocation.GetComponentInChildren<SnapInteractor>();
        // if (snapComp != null) return snapComp.gameObject;

        // return null;

        // Debug.Log("CheckArgument: IsArgumentCorrect called with snapInteractorName: " + snapInteractorName);
        // // check if correct argument (via tag) is snapped to snaplocation 1
        // //var correctSnapInteractor = snapLocation.FindComponentInChildWithTag<SnapInteractor>(snapInteractorTag);

        // var correctSnapInteractor = snapLocation.transform.Find(snapInteractorName);
        // if (correctSnapInteractor == null)
        // {
        //     Debug.LogError("CheckArgument: correct SnapInteractor NOT found in snapLocation, correctArgumentDropped = false;");
        //     //ConversationManager.Instance.SetBool("correctArgumentDropped", false);
        //     correctArgumentDropped = false;
        //     return false;
        // }
        // else
        // {
        //     Debug.LogError("CheckArgument: correct SnapInteractor found in snapLocation, correctArgumentDropped = true;");
        //     //ConversationManager.Instance.SetBool("correctArgumentDropped", true);
        //     correctArgumentDropped = true;
        //     return true;
        // }
    
    
}