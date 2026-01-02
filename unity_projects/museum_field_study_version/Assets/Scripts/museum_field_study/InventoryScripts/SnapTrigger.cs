using UnityEngine;

public class SnapTrigger : MonoBehaviour
{
    public CheckArgument snapLocation;
    public MoveArgumentToInventory[] snapArguments; 
    private string argumentChosenTag;
    private string[] snapInteractorTags;

    //public string[] correctArguments;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        snapInteractorTags = new string[] { "SnappableArgument1t", "SnappableArgument1f",
                                            "SnappableArgument2t", "SnappableArgument3f",
                                            "SnappableArgument3t", "SnappableArgument3f",
                                            "SnappableArgument4t", "SnappableArgument4f"};
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SnapArgument")
        {
            //for (int i = 0; i < snapLocations.Length; i++)
        //{
            argumentChosenTag = snapLocation.GetChosenArgument(snapInteractorTags);
            //}
            Debug.Log("argumentChosenTag: " + argumentChosenTag);


            if (argumentChosenTag.Contains("f"))
            {
                if (argumentChosenTag.Contains("1"))
                {
                    snapArguments[0].MoveToInventory();
                }
                if (argumentChosenTag.Contains("2"))
                {
                    snapArguments[1].MoveToInventory();
                }
                if (argumentChosenTag.Contains("3"))
                {
                    snapArguments[2].MoveToInventory();
                }
                if (argumentChosenTag.Contains("4"))
                {
                    snapArguments[3].MoveToInventory();
                }

            }
        }
        Debug.Log("SnapTrigger: OnTriggerEnter called with object: " + other.gameObject.name);
    }
}
