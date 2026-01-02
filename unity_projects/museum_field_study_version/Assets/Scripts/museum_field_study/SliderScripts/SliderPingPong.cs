using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using TMPro;


public class SliderPingPong : MonoBehaviour
{
    public Slider slider;
    float pos = 0;
    public bool isButtonPressed = false;
    public Button playButton;
    public string pressedButton;
    private Coroutine loopCoroutine;
    public LoadSimulator browser;
    public TMP_Text slidertext;
    //public LogSliderChanges logChanges; // Reference to the LogSliderChanges script


    public enum SLIDER_LOCATION
    {
        OUTRO,
        INTRO
    }

    public SLIDER_LOCATION sliderLocation;

    public void Start()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);
    }
    
    public void OnPlayButtonClicked()
    {
        Debug.Log($"OnPlayButtonClicked invoked. before toggle: {isButtonPressed} Time:{Time.time}");

        isButtonPressed = !isButtonPressed; // Toggle the buttonPressed state
        Debug.Log("Button Pressed: " + isButtonPressed);
        if (isButtonPressed)
        {
            if (this.sliderLocation == SLIDER_LOCATION.INTRO)
            {
                loopCoroutine = StartCoroutine(PingPongIntro());
                pressedButton = "play";
                Debug.Log("coroutine Intro PingPong started");
                //logChanges.SaveTimeLineButton();
            }
            if (this.sliderLocation == SLIDER_LOCATION.OUTRO)
            {
                loopCoroutine = StartCoroutine(PingPongOutro());
                pressedButton = "play";
                Debug.Log("coroutine outro PingPong started");

                //logChanges.SaveTimeLineButton();
            }
        }
        //else
        //{
        //    if (loopCoroutine != null)
        //    {
        //        StopCoroutine(loopCoroutine);
        //        Debug.Log("coroutine PingPong stopped");

        //        loopCoroutine = null;
        //        pressedButton = "pause";
        //        //logChanges.SaveTimeLineButton();
        //    }
        //}
        Debug.Log($"OnPlayButtonClicked finished. after toggle: {isButtonPressed} Time:{Time.time}");

    }


    public IEnumerator PingPongIntro()
    {

        int iteration = 0;
        while (iteration < 3) // stop if at 2100-scenario for 3rd time
        {
            // loop through 2020 - 2100 and start over again
            pos = (pos + 1) % (slider.maxValue + 1);

            // if you like to ping pong back and forth, you can use this line instead:
            //slider.value = Mathf.PingPong(pos, slider.maxValue);

            slider.value = pos;
            Debug.Log("Slider Value: " + slider.value);

            yield return new WaitForSeconds(1.5f);
            Debug.Log("Waited 1 second");

            if (slider.value == slider.maxValue)
            {
                iteration++;
            }

        }
    }

    public IEnumerator PingPongOutro()
    {
        var url = "https://en-roads.climateinteractive.org/scenario.html?v=25.11.0&lang=de";
        browser.loadUrl(url);
        slidertext.text = "ohne Klimaplan";

        int iteration = 0;
        while (iteration < 2) // stop if at 2100-scenario for 3rd time
        {
            // loop through 2020 - 2100 and start over again
            Debug.Log("iteration: " + iteration + "with url: " + url);
            pos = (pos + 1) % (slider.maxValue + 1);

            // if you like to ping pong back and forth, you can use this line instead:
            //slider.value = Mathf.PingPong(pos, slider.maxValue);

            slider.value = pos;

            yield return new WaitForSeconds(2.0f);
            Debug.Log("Waited 1 second");

            if (slider.value == slider.maxValue)
            {
                iteration++;
                // load url with climate plan
                url = "https://en-roads.climateinteractive.org/scenario.html?v=25.11.0&p16=-0.05&p39=250&p47=5&lang=de";
                browser.loadUrl(url);
                slidertext.text = "mit Klimaplan";
                // change slidertext color
                slidertext.color = Color.green;

                //Debug.log("iteration: " + iteration + "with url: https://en-roads.climateinteractive.org/scenario.html?v=25.11.0&lang=de");
            }

        }
    }
        
          
}

