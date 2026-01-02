using UnityEngine;
using System.Collections;

// utility functions to invoke a method WITH parameters after x seconds
public static class InvokeUtilities
{
    public static void Invoke(this MonoBehaviour mb, System.Action f, float delay)
    {
        mb.StartCoroutine(InvokeRoutine(f, delay));
    }
    public static IEnumerator InvokeRoutine(System.Action f, float delay)
    {
        yield return new WaitForSeconds(delay);
        f();
    }
}