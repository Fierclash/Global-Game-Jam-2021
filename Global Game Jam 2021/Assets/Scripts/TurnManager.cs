using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
/*
 *  TurnManager Class
 *      Manages the turn based system
 *      Updates after the player makes a legal move
 */
public class TurnManager : MonoBehaviour
{
    public int turnCounter;
    [Range(0f, 2f)] public float scaleFactor;
    public AIManager AIUnits;
    public Tilemap map;

    // Progresses to the next turn and triggers the next
    // action of all AI units
    public void NextTurn()
    {
        // Triggers next AI moves
        foreach(GameObject unit in AIUnits.units)
        {
            Debug.Log("Triggering AI");
            Movement unitMovement = unit.GetComponentInChildren<Movement>();

            // Move to a random adjacent position
            Vector2 nextPosition = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            Vector3Int gridPosition = map.WorldToCell(nextPosition.normalized * scaleFactor);
            if (map.HasTile(gridPosition))
            {
                Debug.Log("Moving AI");
                unitMovement.Move(map.GetCellCenterWorld(gridPosition));
            }
        }
        turnCounter++;
    }

    #region Initialization and Reset
    public void Init()
    {
        AIUnits.GenerateUnits();
    }

    public void Reset()
    {
        turnCounter = 1;
        AIUnits.Reset();
    }
    #endregion 
}
