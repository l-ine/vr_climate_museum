using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public GameObject player;
    public OVRScreenFade playerFade; // reference to the OVRScreenFade script for screen fading

    // method for scene's fade-out, uses Fader's Animator anim
    public void fadeOut()
    {
        playerFade.SetUIFade(1.0f); // set UI fade to 1.0
    }
}
