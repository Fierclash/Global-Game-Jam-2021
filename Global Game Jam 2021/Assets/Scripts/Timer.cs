using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public DynamicBar timerBar;
    public float time = 3f;
    private IEnumerator timerCoroutine;

    #region Time Functions
    public void Tick()
    {
        StopCoroutine(timerCoroutine);
        timerCoroutine = StartTimer();
        StartCoroutine(timerCoroutine);
    }

    private IEnumerator StartTimer()
    {
        for (float i = 0f; i <= time; i += Time.deltaTime)
        {
            timerBar.UpdateSize(i / time);
            yield return null;
        }
    }
    #endregion
}
