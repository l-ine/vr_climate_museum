using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;

public class CheckInventory : MonoBehaviour
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
                                            "SnappableArgument2t", "SnappableArgument2f",
                                            "SnappableArgument3t", "SnappableArgument3f",
                                            "SnappableArgument4t", "SnappableArgument4f"};
    }

    // Update is called once per frame
    void Update()
    {
        // //for (int i = 0; i < snapLocations.Length; i++)
        // //{
        // argumentChosenTag = snapLocation.GetChosenArgument(snapInteractorTags);
        // //}
        // Debug.Log("argumentChosenTag: " + argumentChosenTag);


        // if (argumentChosenTag.Contains("f"))
        // {
        //     if (argumentChosenTag.Contains("1"))
        //     {
        //         snapArguments[0].MoveToInventory();
        //     }
        //     if (argumentChosenTag.Contains("2"))
        //     {
        //         snapArguments[1].MoveToInventory();
        //     }
        //     if (argumentChosenTag.Contains("3"))
        //     {
        //         snapArguments[2].MoveToInventory();
        //     }
        //     if (argumentChosenTag.Contains("4"))
        //     {
        //         snapArguments[3].MoveToInventory();
        //     }

        // }


    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "SnapArgument")
        {
            Debug.Log("SnapTrigger: ontriggerenter() called with object name: " + other.gameObject.name);
            //for (int i = 0; i < snapLocations.Length; i++)
        //{
            argumentChosenTag = other.gameObject.name; //snapLocation.GetChosenArgument(snapInteractorTags); //or via trigger:
            //}
            Debug.Log("checkinventory, ontriggerenter(): argumentChosenTag: " + argumentChosenTag);

            StartCoroutine(WaitAndMove(argumentChosenTag));
            
        }
        
    }

    IEnumerator WaitAndMove(string argumentChosenTag)
    {
        yield return new WaitForSeconds(2.0f);

        if (argumentChosenTag.Contains("f"))
            {
                if (argumentChosenTag.Contains("1"))
                {
                    snapArguments[0].MoveToInventory();
                    snapArguments[0].ColourRed();
                }
                if (argumentChosenTag.Contains("2"))
                {
                    snapArguments[1].MoveToInventory();
                    snapArguments[1].ColourRed();
                }
                if (argumentChosenTag.Contains("3"))
                {
                    snapArguments[2].MoveToInventory();
                    snapArguments[2].ColourRed();
                }
                if (argumentChosenTag.Contains("4"))
                {
                    snapArguments[3].MoveToInventory();
                    snapArguments[3].ColourRed();
                }

            }
    }

}
