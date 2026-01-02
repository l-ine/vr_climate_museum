using UnityEngine;

public class MoveArgumentToInventory : MonoBehaviour
{
    public Transform target;
    public float move_speed;
    public GameObject[] snapLocations;

    public void MoveToInventory()
    {
        // if (LevelHandler.currentLevel == 3)
        // { 
            for (int i = 0; i < snapLocations.Length; i++)
            {
                snapLocations[i].SetActive(false);
            }
        // }
        
        Debug.Log("MoveArgumentToInventory: Current pos is " + transform.position + "| Target position is " + target.position);
        this.transform.position = Vector3.MoveTowards(transform.position, target.position, move_speed * Time.deltaTime);
        Debug.Log("MoveArgumentToInventory: MoveToInventory called, Current pos is " + transform.position + "| Target position is " + target.position);
        this.transform.rotation = target.rotation;

        // if (LevelHandler.currentLevel == 3)
        // { 
            for (int i = 0; i < snapLocations.Length; i++)
            {
                snapLocations[i].SetActive(true);
            }
        // }
    }
}
