using UnityEngine;
using DialogueEditor;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ConversationStartOnTrigger : MonoBehaviour
{

    [SerializeField] public List<NPCConversation> Conversations;

    //[SerializeField] private ConversationManager conversationManager;
    public GameObject conversationManagerPrefab; // Prefab for the ConversationManager
    public Transform parent;
    private GameObject conversationManagerObject;
    public SliderPingPong sliderPingPong; // Reference to SimInfo scriptable object
    public RectTransform dialoguePanelTransform; // Assign in inspector or find in scene
    public RectTransform optionsPanelTransform; // Assign in inspector or find in scene
    public bool conv_outro_started = false;

    public enum CONVERSATION_PLACE
    {
        OUTSIDE,
        INTRO,
        LEVEL1,
        LEVEL2,
        LEVEL3
    }
    public ConversationStartOnTrigger.CONVERSATION_PLACE Place;

    public ConversationInformer conversationInformer; // Reference to the ConversationInformer script
    public bool isOnTrigger = false; // Track if player is within the trigger area


    void Update()
    {
        // if player is loaded at game start, start the first conversatio outside
        if (SceneManager.loadedSceneCount >= 1 && this.Place == CONVERSATION_PLACE.OUTSIDE && isOnTrigger)
        {
            if (conversationManagerObject == null)
            {
                conversationManagerObject = Instantiate(conversationManagerPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                conversationManagerObject.transform.SetParent(parent, false);
                ConversationManager manager = conversationManagerObject.GetComponent<ConversationManager>();
                manager.ScrollSpeed = 0.01f;
                Debug.Log("ConversationManager Object instantiated as child of its parent conversation in the scene hierarchy.");
            }

            // only start a conversation if it or other conv is not already running
            if (!conversationInformer.conversationRunning)
            {

                if (!sliderPingPong.isButtonPressed && conversationInformer.CountEndedConversations == 0)
                {
                    Debug.Log("update(): Starting conversation 1.");
                    ConversationManager.Instance.StartConversation(Conversations[0]);
                }
                else if (sliderPingPong.isButtonPressed && conversationInformer.CountEndedConversations == 1)
                {
                    Debug.Log("update(): Starting conversation 2.");
                    ConversationManager.Instance.StartConversation(Conversations[1]);
                }
            }
        }

        if (this.Place == CONVERSATION_PLACE.LEVEL3 && isOnTrigger)
        {
            if (conversationManagerObject == null)
            {
                conversationManagerObject = Instantiate(conversationManagerPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                conversationManagerObject.transform.SetParent(parent, false);
                ConversationManager manager = conversationManagerObject.GetComponent<ConversationManager>();
                manager.ScrollSpeed = 0.01f;
                Debug.Log("ConversationManager Object instantiated as child of its parent conversation in the scene hierarchy.");
            }

            // only start a conversation if it or other conv is not already running
            if (!conversationInformer.conversationRunning && !conv_outro_started)
            {
                Debug.Log("Starting conversation at level 3.");
                ConversationManager.Instance.StartConversation(Conversations[0]);
                conv_outro_started = true;
            }
        }

        if (!isOnTrigger && conversationManagerObject != null)
        {
            //conversationManagerObject.SetActive(false); // hide conv manager when player leaves trigger
            Destroy(conversationManagerObject); // destroy conv manager to avoid multiple instances
            conversationManagerObject = null; // reset reference
            Debug.Log("conversationManagerObject set inactive on trigger exit.");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOnTrigger = true;
        }
    }

     private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOnTrigger = false;
        }
    }



    // private void OnTriggerStay(Collider other)
    // {



    //     if (other.CompareTag("Player"))
    //     {
    //         // if prefab is not initialized, instantiate it
    //         if (conversationManagerObject == null)
    //         {
    //             conversationManagerObject = Instantiate(conversationManagerPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
    //             conversationManagerObject.transform.SetParent(parent, false);
    //             ConversationManager manager = conversationManagerObject.GetComponent<ConversationManager>();
    //             manager.ScrollSpeed = 0.01f;
    //             // ConversationManager manager = conversationManagerObject.GetComponent<ConversationManager>();
    //             // manager.DialoguePanel = dialoguePanelTransform;
    //             // manager.OptionsPanel = optionsPanelTransform;
    //             Debug.Log("convstartontrigger: ConversationManager Object instantiated as child of its parent conversation in the scene hierarchy.");
    //         }

    //         if (!this.conversationInformer.conversationRunning)
    //         {
    //             Debug.Log("convstartontrigger: !convrunning");
    //             switch (this.Place)
    //             {
    //                 case CONVERSATION_PLACE.OUTSIDE:
    //                     //     Debug.Log("Conversation Starter enum: outside.");
    //                     //     if (!sliderPingPong.isButtonPressed)
    //                     //     {
    //                     //         Debug.Log("Starting conversation 1.");
    //                     //         ConversationManager.Instance.StartConversation(Conversations[0]);
    //                     //     }
    //                     //     else
    //                     //     {
    //                     //         Debug.Log("Starting conversation 2.");
    //                     //         ConversationManager.Instance.StartConversation(Conversations[1]);
    //                     //     }
    //                     //     break;

    //                     // if player is loaded at game start, start the first conversatio outside
    //                     if (SceneManager.loadedSceneCount >= 1 && this.Place == CONVERSATION_PLACE.OUTSIDE)
    //                     {
    //                         if (conversationManagerObject == null)
    //                         {
    //                             conversationManagerObject = Instantiate(conversationManagerPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
    //                             conversationManagerObject.transform.SetParent(parent, false);
    //                             ConversationManager manager = conversationManagerObject.GetComponent<ConversationManager>();
    //                             manager.ScrollSpeed = 0.01f;
    //                             Debug.Log("ConversationManager Object instantiated as child of its parent conversation in the scene hierarchy.");
    //                         }

    //                         // only start a conversation if it or other conv is not already running
    //                         if (!conversationInformer.conversationRunning)
    //                         {

    //                             if (!sliderPingPong.isButtonPressed && conversationInformer.CountEndedConversations == 0)
    //                             {
    //                                 Debug.Log("update(): Starting conversation 1.");
    //                                 ConversationManager.Instance.StartConversation(Conversations[0]);
    //                             }
    //                             else if (sliderPingPong.isButtonPressed && conversationInformer.CountEndedConversations == 1)
    //                             {
    //                                 Debug.Log("update(): Starting conversation 2.");
    //                                 ConversationManager.Instance.StartConversation(Conversations[1]);
    //                             }
    //                         }
    //                     }
    //                     break;

    //                 case CONVERSATION_PLACE.INTRO:
    //                     Debug.Log("Conversation Starter enum: intro.");
    //                     ConversationManager.Instance.StartConversation(Conversations[0]);
    //                     break;

    //                 case CONVERSATION_PLACE.LEVEL1:
    //                     Debug.Log("Conversation Starter enum: level1, starting conv");
    //                     ConversationManager.Instance.StartConversation(Conversations[0]);

    //                     break;

    //                 case CONVERSATION_PLACE.LEVEL2:
    //                     Debug.Log("Conversation Starter enum: level2.");
    //                     ConversationManager.Instance.StartConversation(Conversations[0]);
    //                     break;

    //                 case CONVERSATION_PLACE.LEVEL3:
    //                     //if (conversationInformer.CountEndedConversations == 1)

    //                     Debug.Log("Conversation 1 starting at level3.");
    //                     ConversationManager.Instance.StartConversation(Conversations[0]);
    //                     break;
    //             }
    //         }

    //     }
    // }
    
    //  void OnTriggerExit(Collider other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         //ConversationManager.Instance.EndConversation();
    //         conversationManagerObject.SetActive(false); // hide conv manager when player leaves trigger
    //         Destroy(conversationManagerObject); // destroy conv manager to avoid multiple instances
    //         conversationManagerObject = null; // reset reference
    //         Debug.Log("conversationManagerObject set inactive on trigger exit.");
            
            

    //     }
    // }
    
}
