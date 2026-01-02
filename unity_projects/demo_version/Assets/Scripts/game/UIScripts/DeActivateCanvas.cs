using UnityEngine;

public class DeActivateObjectOnTrigger : MonoBehaviour
{
    public GameObject myGameObject;
    public void OnTriggerStay(Collider other)
    {
        myGameObject.SetActive(true);
    }
    public void OnTriggerExit(Collider other)
    {
        myGameObject.SetActive(false);
    }
}
