using UnityEngine;
using Vuplex.WebView;

public class TriggerSimulator : MonoBehaviour
{
    public LoadSimulator loadSimulator;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //loadSimulator.loadUrl(loadSimulator.url);
            if (loadSimulator.isInitialized)
        {
            if (!loadSimulator.busy)
            {
                if (loadSimulator.webViewPrefab.WebView.Url != loadSimulator.url)
                {
                    loadSimulator.busy = true;
                    loadSimulator.url = loadSimulator.webViewPrefab.WebView.Url;
                    //loadSimulator.webViewPrefab.WebView.LoadUrl(loadSimulator.url);
                    Debug.Log("LoadSimulator Update: URL changed to " + loadSimulator.url);
                    loadSimulator.Invoke("adjustWebsiteLayout", 5.0f);
                    loadSimulator.busy = false;
                }
            }
            
            
        }
        }
    }
}
