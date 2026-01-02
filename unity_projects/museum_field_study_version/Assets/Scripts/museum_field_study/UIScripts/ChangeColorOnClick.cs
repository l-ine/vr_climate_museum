using UnityEngine;
using UnityEngine.UI;

public class ChangeColorOnClick : MonoBehaviour
{
    public Button testButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        testButton.onClick.AddListener(() =>
        {
            Debug.Log("Test Button Clicked");
            // Add your logic here to change color
            testButton.GetComponent<Image>().color = Color.green;
        });
    }

}
