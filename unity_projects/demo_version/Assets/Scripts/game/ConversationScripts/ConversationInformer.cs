using UnityEngine;
using DialogueEditor;

public class ConversationInformer : MonoBehaviour
{
    public bool conversationRunning = false;
    public int CountStartedConversations = 0;
    public int CountEndedConversations = 0;

    //public bool[] EndedConversations; // Array to track ended conversations, adjust size as needed
    private void OnEnable()
    {
        ConversationManager.OnConversationStarted += ConversationStart;
        ConversationManager.OnConversationEnded += ConversationEnd;
    }

    private void OnDisable()
    {
        ConversationManager.OnConversationStarted -= ConversationStart;
        ConversationManager.OnConversationEnded -= ConversationEnd;
    }

    private void ConversationStart()
    {
        Debug.Log("A conversation has began.");
        this.conversationRunning = true;
        CountStartedConversations += 1;
    }

    private void ConversationEnd()
    {
        Debug.Log("A conversation has ended.");
        this.conversationRunning = false;
        CountEndedConversations += 1;
        //EndedConversations[CountEndedConversations - 1] = true;
    }
}
