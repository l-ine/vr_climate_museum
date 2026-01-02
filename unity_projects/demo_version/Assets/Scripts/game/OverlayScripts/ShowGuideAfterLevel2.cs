using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShowGuideAfterLevel2 : MonoBehaviour
{
    public ChangeCanvasTexts changeCanvasTexts;
    public ShowOverlay showOverlay;
    public GameObject guideText; // Reference to the guide text asset
 

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (changeCanvasTexts.level2Completed)
            {
                showOverlay.ActivateOverlayCanvas(guideText);
            }
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
