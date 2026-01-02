using UnityEngine;
using DialogueEditor;

public class constart_test : MonoBehaviour
{
    public NPCConversation conversation;
    private ConversationManager conversationManagerInstance;
    public GameObject conversationManagerPrefab; // Prefab for the ConversationManager
    public RectTransform myDialoguePanelTransform; // Assign in inspector or find in scene
    public RectTransform myOptionsPanelTransform; // Assign in inspector or find in scene

    public void Start()
    {
        //myDialoguePanelTransform = GameObject.Find("DialoguePanel").GetComponent<RectTransform>();
        //conversationManagerInstance = ConversationManager.Instance;
        // Instantiate the prefab
        GameObject managerObj = Instantiate(conversationManagerPrefab);

        // Get the ConversationManager component
        ConversationManager manager = managerObj.GetComponent<ConversationManager>();

        // Assign UI references (these should be set in your script or found in the scene)
        manager.DialoguePanel = myDialoguePanelTransform;
        manager.OptionsPanel = myOptionsPanelTransform;
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Debug.Log("constart_test: starting conversation.");
            GameObject managerObj = Instantiate(conversationManagerPrefab);
            ConversationManager manager = managerObj.GetComponent<ConversationManager>();
            manager.DialoguePanel = myDialoguePanelTransform;
            manager.OptionsPanel = myOptionsPanelTransform;
            ConversationManager.Instance.StartConversation(conversation);

        }
    }
}
