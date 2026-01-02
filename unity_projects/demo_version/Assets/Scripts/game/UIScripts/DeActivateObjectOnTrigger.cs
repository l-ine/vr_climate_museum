using UnityEngine;

public class DeActivateCanvasOnTrigger : MonoBehaviour
{
    public GameObject myGameObject;
    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.myGameObject.SetActive(true);
        }
        
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.myGameObject.SetActive(false);
        }
    }
}
