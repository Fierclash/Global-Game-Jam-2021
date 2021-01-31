using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class Radar : MonoBehaviour
{
    [Header("Components")]
    public Image dataRadar;
    public Image glitchRadar;

    [Header("Sprites")]
    public List<Sprite> radarSprites;

    [Header("Values")]
    public int dataRadarState = 0;              // Smaller Values indicate Further Signal
    public AIManager aiManager;
    public GameObject player;
    public Tilemap map;
    public float maxRange;

    void Awake()
    {
        dataRadarState = 0;
    }

    void Update()
    {
        float dist = getClosestData();
        int state = getDataState(dist);
        UpdateDataRadar(state);
    }

    public float getClosestData()
    {
        // get min distance of player to data
        Vector3 playerPos = player.transform.position;
        float minDistance = Mathf.Infinity;
        foreach (GameObject g in aiManager.dataUnits)
        {
            float distance = Vector3.Distance(playerPos, g.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
            }
        }
        return minDistance;
    }

    public int getDataState(float minDistance)
    {
        // convert distance into the ranges
        if (minDistance < maxRange / 3)
        {
            return 3;
        } else if (minDistance < maxRange*2/3)
        {
            return 2;
        } else if (minDistance < maxRange)
        {
            return 1;
        } else
        {
            return 0;
        }
    }

    public void UpdateDataRadar(int state)
    {
        // Debug.Log(state);
        dataRadarState = state % radarSprites.Count;
        dataRadar.sprite = radarSprites[dataRadarState];
    }
}
