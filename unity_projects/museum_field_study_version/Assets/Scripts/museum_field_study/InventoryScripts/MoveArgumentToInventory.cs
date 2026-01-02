using UnityEngine;

public class MoveArgumentToInventory : MonoBehaviour
{
    public Transform target;
    public float move_speed;
    public GameObject[] snapLocations;
    public Material redMaterial;
    public Material originalMaterial;
    public GameObject argumentShape;
    private MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = argumentShape.GetComponent<MeshRenderer>();
        originalMaterial = meshRenderer.material;
    }

    public void MoveToInventory()
    {
        Debug.Log("MoveArgumentToInventory: MoveToInventory called for argument: " + this.gameObject.name);
        // if (LevelHandler.currentLevel == 3)
        // { 
        Debug.Log("MoveArgumentToInventory: Deactivating snap locations");
            for (int i = 0; i < snapLocations.Length; i++)
            {
                snapLocations[i].SetActive(false);
            }
        // }
        
        Debug.Log("MoveArgumentToInventory: Moving argument to inventory position");
        //Debug.Log("MoveArgumentToInventory: Current pos is " + transform.position + "| Target position is " + target.position + "| Target rot is " + target.rotation);
        this.transform.position = Vector3.MoveTowards(transform.position, target.position, move_speed * Time.deltaTime);
        this.transform.rotation = target.rotation;
        //Debug.Log("MoveArgumentToInventory: MoveToInventory called, Current rot is " + transform.rotation + "| Target rot is " + target.rotation);


        // color it red
        //this.GetComponent<Renderer>().material.color = Color.red;

        
        //Debug.Log("MoveArgumentToInventory: DONE Changing material from" + meshRenderer.material.name + " to red" + redMaterial.name);

        
        // if (LevelHandler.currentLevel == 3)
        // { 
        Debug.Log("MoveArgumentToInventory: Activating snap locations");
            for (int i = 0; i < snapLocations.Length; i++)
            {
                snapLocations[i].SetActive(true);
            }
        // }
    }

    public void ColourRed()
    {
        Debug.Log("MoveArgumentToInventory: ColourRed called for argument: " + this.gameObject.name);
        meshRenderer.material = redMaterial;
    }

    public void ColourOriginal()
    {
        Debug.Log("MoveArgumentToInventory: ColourOriginal called for argument: " + this.gameObject.name);
        meshRenderer.material = originalMaterial;
    }
}
