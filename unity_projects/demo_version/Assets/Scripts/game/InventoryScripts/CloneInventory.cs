using UnityEngine;

public class CloneInventory : MonoBehaviour
{
    public ChangeCanvasTexts changeCanvasTexts; // Reference to the ChangeCanvastexts script
    public LevelTeleport levelTeleport; // Reference to the LevelTeleport script
    public GameObject inventory; // Prefab or GameObject representing the clone inventory

    public Transform clonePosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool cloned = false; // Flag to check if the inventory has been cloned
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!cloned && changeCanvasTexts.level2Completed)
        {
            if (levelTeleport.teleported)
            {
                // Perform actions related to the clone inventory after teleportation
                Debug.Log("Clone inventory updated after teleportation.");
                Instantiate(inventory, clonePosition.transform.position, clonePosition.transform.rotation);
                cloned = true;
            }
        }
        
    }
}
