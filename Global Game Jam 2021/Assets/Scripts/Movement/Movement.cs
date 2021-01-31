using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
/*
 *  Movement Class
 *      Allows movement between tile positions
 * 
 *  Public Members:
 *      void MoveToTile(Vector3);
 * 
 */
public class Movement : MonoBehaviour
{
    [Range(0f, 1f)] public float movementSpeed;
    public Transform hostBody;

    private bool isMoving = false;
    private Vector3 destination;

    public Tilemap map;

    [SerializeField] private float lowerLimit = 0.1f;
    [SerializeField] private float upperLimit = 1.5f;

    // Validates moves
    public void Move(Vector2 nextPosition)
    {
        Vector3Int gridPosition = map.WorldToCell(nextPosition);
        if (map.HasTile(gridPosition)) {
            destination = map.GetCellCenterWorld(gridPosition);
        }

        // Move if position is in range
        float distance = Vector3.Distance(transform.position, destination);
        if (distance > lowerLimit && distance < upperLimit)
        {
            // Debug.Log("Moving to" + destination);
            MoveAction(destination);
        }
    }

    // Moves to another tile
    private void MoveAction(Vector3 position)
    {
        // Do not move if currently moving
        if (isMoving)
            return;

        //hostBody.position = position;

        StartCoroutine(MoveToTile(position));
    }
    
    // Coroutine for tweening
    private IEnumerator MoveToTile(Vector3 position)
    {
        isMoving = true;
        while(Vector3.Distance(hostBody.position, position) > 0.05f)
        {
            hostBody.position = Vector3.Lerp(hostBody.position, position, movementSpeed);
            yield return null;
        }
        hostBody.position = position;
        isMoving = false;
    }

}
