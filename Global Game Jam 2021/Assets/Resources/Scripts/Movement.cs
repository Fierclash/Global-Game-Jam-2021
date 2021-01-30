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
    public float movementTime;
    public Transform hostBody;

    private bool isMoving = false;
    private Vector3 destination;

    void Update()
    {
        if (isMoving)
            return;

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Moving to Left");
            destination = transform.position + Vector3.left;
            MoveToTile(destination);
            StartCoroutine(MoveToTile(destination));
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Moving to Right");
            destination = transform.position + Vector3.right;
            StartCoroutine(MoveToTile(destination));
        }
    }
    
    private IEnumerator MoveToTile(Vector3 position)
    {
        isMoving = true;
        while(Vector3.Distance(hostBody.position, position) > 0.05f)
        {
            hostBody.position = Vector3.Lerp(hostBody.position, position, Time.deltaTime);
            yield return null;
        }
        isMoving = false;
    }

}
