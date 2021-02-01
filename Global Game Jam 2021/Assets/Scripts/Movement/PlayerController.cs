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
    private int dataLeft;
    public Text scoreText;
    private bool isActing = false;
    [Range(0f, 1f)] public float actionTime;
    public AIManager ai;
    public EndGame endGame;
    public AudioSource moveAudio;
    public AudioSource corruptAudio;
    public AudioSource dataAudio;
    public AudioSource dieAudio;

    // Start is called before the first frame update
    void Start()
    {
        dataLeft = ai.dataCount;
        scoreText.text = "Data Left: " + dataLeft;
        vision.UpdateVision(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            MouseClick();
        }
    }

    private void MouseClick() {
        if (isActing)
            return;
        
        // Debug.Log("Attempting to Move");
        Vector2 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // if the move is valid, complete the turn
        if (movement.Move(mousePosition))
        {
            moveAudio.Play();
            StartCoroutine(SetActing());
            turnManager.NextTurn();
            vision.UpdateVision(mousePosition);
        }
    }

    private IEnumerator SetActing()
    {
        isActing = true;
        for (float i = 0f; i < actionTime; i += Time.deltaTime)
            yield return null;
        isActing = false;
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            Die();
        } else if (col.tag == "Data")
        {
            dataAudio.Play();
            col.gameObject.SetActive(false);
            dataLeft--;
            scoreText.text = "Score: " + dataLeft;
        } else if (col.tag == "Corruption")
        {
            corruptAudio.Play();
            col.gameObject.SetActive(false);
            ai.corrupt();
        }
        if(dataLeft == 0)
            endGame.ShowEndScreen(ai.dataCount - dataLeft, ai.dataCount, TurnManager.turnCounter);
    }

    private void Die()
    {
        dieAudio.Play();
        this.gameObject.SetActive(false);
        endGame.ShowEndScreen(ai.dataCount - dataLeft, ai.dataCount, TurnManager.turnCounter);
    }
}
