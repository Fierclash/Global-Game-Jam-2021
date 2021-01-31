using System.Collections;
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
    public Tile fogTile;
    public Tilemap fogOfWar;

    // Updates the Fog of War Tilemap based on player position
    public void UpdateVision(Vector3 position)
    {
        Vector3Int currentTile = fogOfWar.WorldToCell(position);

        // Set Fog Tiles
        List<Vector3Int> currentTileset = DetermineAdjacentTiles(vision + 1, currentTile.x / 2);
        foreach (Vector3Int point in currentTileset)
        {
            fogOfWar.SetTile(currentTile + point, fogTile);
        }

        // Reveal Adjacent Tiles
        currentTileset = DetermineAdjacentTiles(vision, currentTile.x / 2);
        foreach (Vector3Int point in currentTileset)
        {
            fogOfWar.SetTile(currentTile + point, null);
        }
    }

    public List<Vector3Int> DetermineAdjacentTiles(int range, int positionParity)
    {
        List<Vector3Int> adjacentTiles = new List<Vector3Int>();

        // Middle Row
        for (int i = range; i <= range; i++)
            adjacentTiles.Add(new Vector3Int(i, 0, 0));

        // Upper and Lower Halves
        // Since Middle row is already set, i < range does not need to include it
        int leftBound = -range;
        int rightBound = range;
        for (int i = 0; i < range; i++)
        {
            // Even Parity
            if (i % 2 + positionParity == 0)
                leftBound++;
            else
                rightBound--;

            for(int j = leftBound; j <= rightBound; j++)
            {
                adjacentTiles.Add(new Vector3Int(j, i, 0));
                adjacentTiles.Add(new Vector3Int(j, -i, 0));
            }
        }

        return adjacentTiles;
    }
}
