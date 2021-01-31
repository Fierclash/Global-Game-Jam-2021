using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicBar : MonoBehaviour
{
    public Slider bar;
    public Gradient gradient;
    public Image fill;
    private const float MAX_VALUE = 1f;
    private IEnumerator timerCoroutine;

    void Awake()
    {
        bar.maxValue = MAX_VALUE;
        UpdateSize(MAX_VALUE);
    }

    public void UpdateSize(float percent)
    {
        bar.value = percent;
        fill.color = gradient.Evaluate(bar.normalizedValue);  
    }
}
