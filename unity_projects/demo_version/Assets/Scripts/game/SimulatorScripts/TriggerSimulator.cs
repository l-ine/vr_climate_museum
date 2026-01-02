using UnityEngine;

public class TriggerSimulator : MonoBehaviour
{
    public LoadSimulator loadSimulator;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            loadSimulator.loadUrl(loadSimulator.url);
        }
    }
}
