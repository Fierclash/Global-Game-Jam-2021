using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public DynamicBar timerBar;
    public float time = 3f;
    private IEnumerator timerCoroutine;
    public UnityEvent Tock;
    private bool IsPaused { get; set; }

    void Awake()
    {
        if (Tock == null)
            Tock = new UnityEvent();
        timerCoroutine = StartTimer();
    }

    void Start()
    {
        Tick();
    }

    #region Time Functions
    public void Tick()
    {
        // Do not Pause
        if (IsPaused)
            return;

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

        Tock.Invoke();
    }
    #endregion
}
