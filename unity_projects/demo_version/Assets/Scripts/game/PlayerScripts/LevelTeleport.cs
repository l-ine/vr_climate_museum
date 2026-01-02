using UnityEngine;

public class LevelTeleport : MonoBehaviour
{

    // a teleportation state (true if teleportation to target happened, false if teleportation back to original position happened)
    public bool teleported = false;

    public Transform target; // target position for teleportation
    public GameObject player;
    public OVRScreenFade playerFade; // reference to the OVRScreenFade script for screen fading


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // scene fades out
            FadeOut();
            // performs teleportation to target and scene's fading-in with small temporal delay 
            Invoke("GoToDestination", 1.0f);
            Invoke("FadeIn", 1.0f);
            teleported = false;
        }

    }

    /*
     * some auxiliary methods
    */


    // method for scene's fade-out, uses Fader's Animator anim
    void FadeOut()
    {
        playerFade.SetUIFade(1.0f); // set UI fade to 1.0
    }

    // method for scene's fade-in, uses Fader's Animator anim
    void FadeIn()
    {
        playerFade.SetUIFade(0.0f); // set UI fade to 0.0
    }

    // method for changing the player's position to the target position (full-version simulator) and facing player and its camera towards panel
    void GoToDestination()
    {
        player.transform.position = target.transform.position;
        player.transform.rotation = target.transform.rotation;
        teleported = true;
    }

}


