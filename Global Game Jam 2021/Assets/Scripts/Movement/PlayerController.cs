using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Movement movement;
    public Vision vision;
    public TurnManager turnManager;
    private int points = 0;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + points;
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
            vision.UpdateVision(mousePosition);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            Die();
        } else if (col.tag == "Data")
        {
            points++;
            scoreText.text = "Score: " + points;
            col.gameObject.SetActive(false);
        }
    }

    private void Die()
    {
        this.gameObject.SetActive(false);
    }
}
