using UnityEngine;

public class DestroyArgument : MonoBehaviour
{
    public void DestroySnappedArgument()
    {
        // //Destroy(this.transform.GetChild(0).gameObject);
        // this.gameObject.SetActive(false);
        // //this.gameObject.SetActive(false);
        // Debug.Log("DestroyArgument: DestroySnappedArgument called, argument destroyed");
    }
    public void ActivateArgument()
    {
        this.gameObject.SetActive(true);
        Debug.Log("DestroyArgument: ActivateArgument called, argument activated");
    }
}
