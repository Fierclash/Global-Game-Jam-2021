using System.Collections;
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
        List<Vector3> positions = GeneratePositions(unitCount);
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
    private List<Vector3> GeneratePositions(int count)
    {
        List<Vector3> positions = new List<Vector3>();

        // Generate positions
        for(int i=0; i<count; i++)
            positions.Add(Vector3.zero);

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
