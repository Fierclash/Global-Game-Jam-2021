using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    public Tilemap map;
    public int movementSpeed;
    public Transform hostBody;
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
        if (Vector3.Distance(transform.position, destination) > 0.1f) {
            MoveToTile(destination);
            Debug.Log("moving");
        }
    }

    public void MoveToTile(Vector3 position)
    {
        hostBody.position = Vector3.Lerp(hostBody.position, position, movementSpeed);
    }

    private void MouseClick() {
        Vector2 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // clicking on cell
        Vector3Int gridPosition = map.WorldToCell(mousePosition);
        if (map.HasTile(gridPosition)) {
            destination = mousePosition;
        }
    }
}
