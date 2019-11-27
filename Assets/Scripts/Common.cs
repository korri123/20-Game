using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Common
{
    public static IEnumerator DelayedAction(UnityAction action, float seconds)
    {
        yield return null; // optional
        yield return new WaitForSeconds(seconds); // Wait for the next frame
        action.Invoke(); // execute a delegate
    }
}