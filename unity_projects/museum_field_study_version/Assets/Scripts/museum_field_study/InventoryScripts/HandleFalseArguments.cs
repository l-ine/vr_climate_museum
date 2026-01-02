using UnityEngine;

public class HandleFalseArguments : MonoBehaviour
{
    public GameObject[] snapLocations;
    public GameObject falseArgument;
    public GameObject inventoryPosition;
    public void MoveFalseArgumentToStartPosition()
    {
        // for each snap location, find the first child (assumed to be the false argument)
        for (int i = 0; i < snapLocations.Length; i++)
        {
            Debug.Log("CheckArgument: MoveFalseArgumentToStartPosition called");
            //GameObject falseArgument = snapLocations[i].transform.GetChild(0).gameObject;
            if (falseArgument != null)
            {
                // Move the false argument to its start position
                falseArgument.transform.position = inventoryPosition.transform.position;
                falseArgument.transform.rotation = inventoryPosition.transform.rotation;
                Debug.Log("CheckArgument: False argument moved to start position");
            }
            else
            {
                Debug.Log("CheckArgument: False argument is null, cannot move to start position");
            }
        }

    }
}
