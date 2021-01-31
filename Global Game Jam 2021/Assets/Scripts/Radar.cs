using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Radar : MonoBehaviour
{
    [Header("Components")]
    public Image dataRadar;
    public Image glitchRadar;

    [Header("Sprites")]
    public List<Sprite> radarSprites;

    [Header("Values")]
    public int dataRadarState = 0;              // Smaller Values indicate Further Signal

    void Awake()
    {
        dataRadarState = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            UpdateDataRadar(dataRadarState+1);
    }

    public void UpdateDataRadar(int state)
    {
        Debug.Log(state);
        dataRadarState = state % radarSprites.Count;
        dataRadar.sprite = radarSprites[dataRadarState];
    }
}
