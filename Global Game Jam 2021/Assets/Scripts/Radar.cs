using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class Radar : MonoBehaviour
{
    [Header("Components")]
    public Image dataRadar;
    public Image corruptionRadar;

    [Header("Sprites")]
    public List<Sprite> radarSprites;

    [Header("Values")]
    public int dataRadarState = 0;              // Smaller Values indicate Further Signal
    public int corruptionRadarState = 0; 
    public AIManager aiManager;
    public GameObject player;
    public Tilemap map;
    public float maxRange;

    void Awake()
    {
        dataRadarState = 0;
        corruptionRadarState = 0;
    }

    void Update()
    {
        // update data radar
        float dist = getClosestData();
        int state = getRadarState(dist);
        UpdateDataRadar(state);

        // update corruption radar
        dist = getClosestCorruption();
        state = getRadarState(dist);
        UpdateCorruptionRadar(state);
    }

    public float getClosestData()
    {
        // get min distance of player to data
        Vector3 playerPos = player.transform.position;
        float minDistance = Mathf.Infinity;
        foreach (GameObject g in aiManager.dataUnits)
        {
            if (g.activeSelf == true)
            {
                float distance = Vector3.Distance(playerPos, g.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                }
            }
        }
        return minDistance;
    }

    public float getClosestCorruption()
    {
        // get min distance of player to data
        Vector3 playerPos = player.transform.position;
        float minDistance = Mathf.Infinity;
        foreach (GameObject g in aiManager.corruptionNodes)
        {
            if (g.activeSelf == true)
            {
                float distance = Vector3.Distance(playerPos, g.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                }
            }
        }
        return minDistance;
    }

    public int getRadarState(float minDistance)
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

    public void UpdateCorruptionRadar(int state)
    {
        // Debug.Log(state);
        corruptionRadarState = state % radarSprites.Count;
        corruptionRadar.sprite = radarSprites[corruptionRadarState];
    }
}
