﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
/*
 *  TurnManager Class
 *      Manages the turn based system
 *      Updates after the player makes a legal move
 */
public class TurnManager : MonoBehaviour
{
    public static int turnCounter;
    public AIManager AIUnits;
    public Tilemap map;
    public Timer timer;
    public Text turnText;

    void Start()
    {
        turnCounter = 0;
        turnText.text = "Turn: " + turnCounter;
    }

    // Progresses to the next turn and triggers the next
    // action of all AI units
    public void NextTurn()
    {
        // Triggers next AI moves
        foreach(GameObject unit in AIUnits.units)
        {
            // Debug.Log("Triggering AI");
            Movement unitMovement = unit.GetComponentInChildren<Movement>();

            // Move to a random adjacent position
            Vector2 randDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            // Vector2 randDirection = Vector2.right;
            Vector2 nextPosition = (Vector2)unit.transform.position + randDirection;
            unitMovement.Move(nextPosition);
        }
        turnCounter++;
        turnText.text = "Turn: " + turnCounter;
        timer.Tick();
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
