using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;


public class SliderPingPong : MonoBehaviour
{
    public Slider slider;
    float pos = 0;
    public bool isButtonPressed = false;
    public Button playButton;
    public string pressedButton;
    private Coroutine loopCoroutine;
    //public LogSliderChanges logChanges; // Reference to the LogSliderChanges script

    public void Start()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);
    }
    public void OnPlayButtonClicked()
    {
        isButtonPressed = !isButtonPressed; // Toggle the buttonPressed state

        if (isButtonPressed)
        {
            loopCoroutine = StartCoroutine(PingPong());
            pressedButton = "play";
            //logChanges.SaveTimeLineButton();
            
        }
        else
        {
            if (loopCoroutine != null)
            {
                StopCoroutine(loopCoroutine);
                loopCoroutine = null;
                pressedButton = "pause";
                //logChanges.SaveTimeLineButton();
            }
        }
        
    }

    public IEnumerator PingPong()
    {
        int iteration = 0;
        while (iteration < 3) // stop if at 2100-scenario for 3rd time
        {
            // loop through 2020 - 2100 and start over again
            pos = (pos + 1) % (slider.maxValue + 1);

            // if you like to ping pong back and forth, you can use this line instead:
            //slider.value = Mathf.PingPong(pos, slider.maxValue);

            slider.value = pos;

            yield return new WaitForSeconds(1.5f);
            Debug.Log("Waited 1 second");

            if (slider.value == slider.maxValue)
            {
                iteration++;
            }
            
        }
    }
}

