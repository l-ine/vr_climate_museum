using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ShowOverlay : MonoBehaviour
{
    public GameObject guideCanvas; // Reference to the guide canvas
    public GameObject Anchor; // Reference to the anchor object

   void Start()
    {
        guideCanvas.SetActive(false);
    }
    public void ActivateOverlayCanvas(GameObject guideText)
    {
        Debug.Log("Overlay canvas activated.");
        guideCanvas.transform.position = Anchor.transform.position;
        guideCanvas.transform.eulerAngles = new Vector3(Anchor.transform.eulerAngles.x + 15, Anchor.transform.eulerAngles.y, 0);
        guideCanvas.SetActive(true);
        guideText.SetActive(true);
    }
    public void DeactivateOverlayCanvas(GameObject guideText)
    {
        Debug.Log("Overlay canvas deactivated.");
        guideCanvas.SetActive(false);
        guideText.SetActive(false);
    }
}
