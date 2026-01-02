using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class ManageKeyboard : MonoBehaviour
{
	private TMP_InputField field;
    
    private TouchScreenKeyboard overlayKeyboard;
    public static string inputText = "";

	private void Awake()
    {
        field = GetComponent<TMP_InputField>();

        field.onSelect.AddListener(s => ShowKeyboardDelay());
    }

	private async void ShowKeyboardDelay()
	{
		await Task.Delay(20);

        Debug.Log("showkeyboarddelay()");

        if (!TouchScreenKeyboard.visible)
        {
            Debug.Log("showkeyboarddelay(): opening keyboard");
            field.ActivateInputField();
            overlayKeyboard = TouchScreenKeyboard.Open(field.text, TouchScreenKeyboardType.Default);
            //TouchScreenKeyboard.Open(field.text, TouchScreenKeyboardType.ASCIICapable);
            if (overlayKeyboard != null)
            {
                inputText = field.text;
                Debug.Log("showkeyboarddelay(): " + field.text);
            }
                
        }
	}
}