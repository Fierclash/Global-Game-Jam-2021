using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    [Range(0f, 1f)]public float movementSpeed;
    public Transform hostBody;

    private bool isMoving = false;
    private Vector3 destination;

    // Moves to another tile
    public void Move(Vector3 position)
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
