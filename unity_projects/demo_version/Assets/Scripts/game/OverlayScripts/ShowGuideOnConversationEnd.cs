using UnityEngine;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DialogueEditor;

public class ShowGuideOnConversationEnd : MonoBehaviour
{
    public ShowOverlay showOverlay; // Reference to the ShowOverlay script
    public GameObject guideText; // Reference to the guide text asset

    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            showOverlay.DeactivateOverlayCanvas(guideText);
        }
    }
}
