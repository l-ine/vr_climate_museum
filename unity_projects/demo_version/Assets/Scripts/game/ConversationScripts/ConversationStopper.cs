using UnityEngine;
using DialogueEditor;

public class ConversationStopper : MonoBehaviour
{
    [SerializeField] public NPCConversation Conversation;
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("ConversationStopper: Player exited the trigger area, stopping conversation.");
            // Assuming ConversationManager has a method to stop conversations
            ConversationManager.Instance.EndConversation();
        }
    }
}
