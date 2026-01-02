using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DialogueEditor;


public class ShowGuideCanvas : MonoBehaviour
{
    public ShowOverlay showOverlay;
    public GameObject guideText;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            showOverlay.ActivateOverlayCanvas(guideText);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            showOverlay.DeactivateOverlayCanvas(guideText);
        }
    }

}
