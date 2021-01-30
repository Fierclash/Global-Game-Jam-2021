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

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Moving");
            MoveToTile(transform.position + Vector3.left);
        }
    }

    public void MoveToTile(Vector3 position)
    {
        hostBody.position = Vector3.Lerp(hostBody.position, position, movementTime);
    }
}
