using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    public Movement movement;
    public TurnManager turnManager;


    // Start is called before the first frame update
    void Start()
    {
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

        // if the move is valid, complete the turn
        if (movement.Move(mousePosition))
        {
            turnManager.NextTurn();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Die();
    }

    private void Die()
    {
        this.gameObject.SetActive(false);
    }
}
