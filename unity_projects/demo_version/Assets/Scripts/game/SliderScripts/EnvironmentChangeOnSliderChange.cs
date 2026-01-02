using UnityEngine;

public class EnvironmentChangeOnSliderChange : MonoBehaviour
{
    public UnityEngine.UI.Slider timeSlider;
    public UpdateEnvironment environmentUpdate;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeSlider.onValueChanged.AddListener(delegate { OnSliderValueChange(); });
    }
    
    public void OnSliderValueChange()
    {
        // Grab the numeric value of the slider - cast to int as the value should be a whole number
        int numericSliderValue = (int)timeSlider.value;
        Debug.Log("SLIDER VALUE: " + timeSlider.value);
        //Debug.Log("SLIDER VALUE INT: " + (int)timeSlider.value);

        // Update the slider value to the nearest step
        timeSlider.value = Mathf.Round(timeSlider.value);
        //Debug.Log("ROUNDED SLIDER VALUE: " + timeSlider.value);

        // Debugging - do whatever you want with this value
        //Debug.Log("slider value (int): ", numericSliderValue);

        SetEnvironmentUpdateYearSelector(numericSliderValue);
        
    }

    private void SetEnvironmentUpdateYearSelector(int value)
    {
        if (environmentUpdate != null)
        {
            //Debug.Log("SliderTimeline: Setting yearSelector to: " + value);
            // Set the yearSelector variable in EnvironmentUpdate script
            environmentUpdate.yearSelector = value;
        }
    }

}
