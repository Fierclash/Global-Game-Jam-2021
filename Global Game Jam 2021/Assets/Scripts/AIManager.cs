﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
/*
 *  AI Manager
 *      Stores all AI units within the field
 */
public class AIManager : MonoBehaviour
{
    public int unitCount;
    [SerializeField] private GameObject virusUnit;
    public List<GameObject> units;
    public Tilemap map;

    void Awake()
    {
        units = new List<GameObject>();
    }

    void Start()
    {
        GenerateUnits();
    }

    #region Unit Generation
    // Generates a group of units and places them on a random
    // position on the field
    public void GenerateUnits()
    {
        List<Vector3> positions = GeneratePositions();
        for(int i=0; i<unitCount; i++)
        {
            // Create and Place a Unit
            GameObject lastCreated = Instantiate(virusUnit, positions[i], Quaternion.identity);
            units.Add(lastCreated);
        }
        InitUnits();
    }

    // Generates a list of positions on the grid
    // Each position must be unique from one another
    private List<Vector3> GeneratePositions()
    {
        List<Vector3> positions = new List<Vector3>();

        // get all valid positions
        foreach (Vector3Int gridPosition in map.cellBounds.allPositionsWithin)
        {
            if (map.HasTile(gridPosition))
            {
                Vector3 position = map.GetCellCenterWorld(gridPosition);
                positions.Add(position);
            }
        }

        // shuffle positions list
        int length = positions.Count;
        for(int i = 0; i < length; i++)
        {
            int j = Random.Range(0, length-1);
            Vector3 temp = positions[i];
            positions[i] = positions[j];
            positions[j] = temp;
        }

        return positions;
    }
    #endregion

    #region Unit Management
    // Initializes all the units
    public void InitUnits()
    {
        foreach(GameObject unit in units)
        {
            Movement unitMovement = unit.GetComponentInChildren<Movement>();
            unitMovement.map = map;
        }
    }

    // Resets all the units
    public void Reset()
    {
        foreach(GameObject unit in units)
        {
            
        }
    }
    #endregion
}
