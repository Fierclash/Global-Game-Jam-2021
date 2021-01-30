using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    public Tilemap map;
    public int movementSpeed;
    public Transform hostBody;
    public Movement movement;

    [SerializeField] private float lowerLimit = 0.1f;
    [SerializeField] private float upperLimit = 2f;
    private Vector3 destination;


    // Start is called before the first frame update
    void Start()
    {
        destination = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            MouseClick();
        }
    }

    private void MouseClick() {
        // Debug.Log("Attempting to Move");
        Vector2 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // clicking on cell
        Vector3Int gridPosition = map.WorldToCell(mousePosition);
        if (map.HasTile(gridPosition)) {
            destination = map.GetCellCenterWorld(gridPosition);
        }

        // Move if position is in range
        float distance = Vector3.Distance(transform.position, destination);
        if (distance > lowerLimit && distance < upperLimit)
        {
            // Debug.Log("Moving to" + destination);
            movement.Move(destination);
        }
    }
}
