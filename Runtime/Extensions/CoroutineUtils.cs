using UnityEngine;
using System;
using System.Collections;

public static class CoroutineUtils
{
    public static Coroutine DelaySeconds(this MonoBehaviour mono, Action action, float delay, bool ignoreTimeScale = false)
    {
        return mono.StartCoroutine(DelaySeconds(action, delay, ignoreTimeScale));
    }

    private static IEnumerator DelaySeconds(Action action, float delay, bool ignoreTimeScale)
    {
        if (ignoreTimeScale)
        {
            yield return new WaitForSecondsRealtime(delay);
        }
        else
        {
            yield return new WaitForSeconds(delay);
        }
        action();
    }
}