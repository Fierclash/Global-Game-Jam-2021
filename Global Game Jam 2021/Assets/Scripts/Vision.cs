﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
/*
 *  Vision Class
 *      Determines the view range of the player
 *      Reveals nearby tiles
 *      Hides distant tiles
 *      
 *  Note:
 *      Must be on a child transform of the host transform
 */
public class Vision : MonoBehaviour
{
    public int vision = 1;
    public Tilemap fogOfWar;

    // Updates the Fog of War Tilemap based on player position
    public void UpdateVision()
    {
        Vector3Int currentTile = fogOfWar.WorldToCell(transform.position);

        for(int x=-vision; x <= vision; x++)
        {
            for (int y = -vision; y <= vision; y++)
            {
                fogOfWar.SetTile(currentTile + new Vector3Int(x, y, 0), null);
            }
        }
    }
}