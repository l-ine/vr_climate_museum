using UnityEngine;
using DialogueEditor;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ConversationStartOnClick : MonoBehaviour
{

    [SerializeField] public List<NPCConversation> Conversations;

    //[SerializeField] private ConversationManager conversationManager;
    public GameObject conversationManagerPrefab; // Prefab for the ConversationManager
    public Transform parent;
    public GameObject conversationManagerObject;
    public SliderPingPong sliderPingPong; // Reference to SimInfo scriptable object
    public RectTransform dialoguePanelTransform; // Assign in inspector or find in scene
    public RectTransform optionsPanelTransform; // Assign in inspector or find in scene
    public Button startButton; // Reference to the start button
    public GameObject buttonPanel;
    public bool isButtonPressed = false;

    public enum CONVERSATION_PLACE
    {
        OUTSIDE,
        INTRO,
        LEVEL1,
        LEVEL2,
        LEVEL3
    }
    public ConversationStartOnClick.CONVERSATION_PLACE Place;

    public ConversationInformer conversationInformer; // Reference to the ConversationInformer script

    void Start()
    {
        startButton.onClick.AddListener(OnButtonClick);
    }
    void Update()
    {
        // // if player is loaded at game start, start the first conversatio outside
        // if (SceneManager.loadedSceneCount >= 1 && this.Place == CONVERSATION_PLACE.OUTSIDE)
        // {
        //     if (conversationManagerObject == null)
        //     {
        //         conversationManagerObject = Instantiate(conversationManagerPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        //         conversationManagerObject.transform.SetParent(parent, false);
        //         ConversationManager manager = conversationManagerObject.GetComponent<ConversationManager>();
        //         manager.ScrollSpeed = 0.01f;
        //         Debug.Log("ConversationManager Object instantiated as child of its parent conversation in the scene hierarchy.");
        //     }

        //     // only start a conversation if it or other conv is not already running
        //     if (!conversationInformer.conversationRunning)
        //     {

        //         if (!sliderPingPong.isButtonPressed && conversationInformer.CountEndedConversations == 0)
        //         {
        //             Debug.Log("update(): Starting conversation 1.");
        //             ConversationManager.Instance.StartConversation(Conversations[0]);
        //         }
        //         else if (sliderPingPong.isButtonPressed && conversationInformer.CountEndedConversations == 1)
        //         {
        //             Debug.Log("update(): Starting conversation 2.");
        //             ConversationManager.Instance.StartConversation(Conversations[1]);
        //         }
        //     }
        // }
    }

    // private void OnTriggerStay(Collider other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         isOnTrigger = true;
    //     }
    // }

    //  private void OnTriggerExit(Collider other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         isOnTrigger = false;
    //     }
    // }

    private void OnButtonClick()
    {
        isButtonPressed = true;
        Debug.Log("Button clicked! isButtonPressed set to true.");
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if (isButtonPressed)
            {
                buttonPanel.SetActive(false);
                isButtonPressed = false; // reset button press for next time

                // if prefab is not initialized, instantiate it
                // if (conversationManagerObject == null)
                // {
                conversationManagerObject = Instantiate(conversationManagerPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                conversationManagerObject.transform.SetParent(parent, false);
                ConversationManager manager = conversationManagerObject.GetComponent<ConversationManager>();
                manager.ScrollSpeed = 0.01f;
                // ConversationManager manager = conversationManagerObject.GetComponent<ConversationManager>();
                // manager.DialoguePanel = dialoguePanelTransform;
                // manager.OptionsPanel = optionsPanelTransform;
                Debug.Log("ConversationManager Object instantiated as child of its parent conversation in the scene hierarchy.");
                // }

                if (!this.conversationInformer.conversationRunning)
                {

                    switch (this.Place)
                    {
                        // case CONVERSATION_PLACE.OUTSIDE:
                        //     Debug.Log("Conversation Starter enum: outside.");
                        //     if (!sliderPingPong.isButtonPressed)
                        //     {
                        //         Debug.Log("Starting conversation 1.");
                        //         ConversationManager.Instance.StartConversation(Conversations[0]);
                        //     }
                        //     else
                        //     {
                        //         Debug.Log("Starting conversation 2.");
                        //         ConversationManager.Instance.StartConversation(Conversations[1]);
                        //     }
                        //     break;
                        case CONVERSATION_PLACE.INTRO:
                            Debug.Log("Conversation Start on click: enum: intro. Starting conversation.");
                            ConversationManager.Instance.StartConversation(Conversations[0]);
                            break;

                        case CONVERSATION_PLACE.LEVEL1:
                            Debug.Log("CConversation Start on click: enum: level1. Starting conversation.");
                            ConversationManager.Instance.StartConversation(Conversations[0]);

                            break;

                        case CONVERSATION_PLACE.LEVEL2:
                            Debug.Log("Conversation Start on click: enum: level2. Starting conversation.");
                            ConversationManager.Instance.StartConversation(Conversations[0]);
                            break;

                        case CONVERSATION_PLACE.LEVEL3:
                            //if (conversationInformer.CountEndedConversations == 1)

                            Debug.Log("Conversation Start on click: enum: level3. Starting conversation.");
                            ConversationManager.Instance.StartConversation(Conversations[0]);
                            break;
                    }
                }
            }
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //ConversationManager.Instance.EndConversation();
            //conversationManagerObject.SetActive(false); // hide conv manager when player leaves trigger
            Destroy(conversationManagerObject); // destroy conv manager to avoid multiple instances
            conversationManagerObject = null; // reset reference
            Debug.Log("conversationManagerObject destroyed on trigger exit.");
            
            buttonPanel.SetActive(true);
            isButtonPressed = false; // reset button press for next time

        }
    }
    
}
