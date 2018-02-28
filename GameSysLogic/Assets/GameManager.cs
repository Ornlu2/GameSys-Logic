using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

   public  bool Player1Turn = true;
   public  bool  Player2Turn = false;

    public bool P1PlacedPiece = false;
    public bool P2PlacedPiece = false;

    public SpriteRenderer Background;

    public Text P1ScoreUI;

    public Text P2ScoreUI;

    public int P1Score;
    public int P2Score;

    public Text P1TurnTime;
    public Text P2TurnTime;

    public float turntimeP1;
    public float turntimeP2;

    public Text GameOver;
    private bool GameIsOver;

    // Use this for initialization
    void Start () {
       P1ScoreUI=  P1ScoreUI.GetComponent<Text>();
        GameOver = GameOver.gameObject.GetComponent<Text>();
       // PlTime = turntimeP1;
       // P2Time = turntimeP2;

    }

    // Update is called once per frame
    void Update () {
        P1ScoreUI.text = "Score: " + P1Score;
        P2ScoreUI.text = "Score: " + P2Score;
        P1TurnTime.text = "Time: " +Mathf.RoundToInt(turntimeP1); 
        P2TurnTime.text = "Time: " +Mathf.RoundToInt( turntimeP2);
        if(GameIsOver ==false)
        {
            if (Player1Turn == true && P1PlacedPiece == false)
            {
                turntimeP1 -= Time.deltaTime;
            }
            if (Player2Turn == true && P2PlacedPiece == false)
            {
                turntimeP2 -= Time.deltaTime;
            }
        }
        
        if (P1PlacedPiece == true && Input.GetMouseButtonUp(2))
        {
            ChangePlayer();
            P1PlacedPiece = false;
        }
        if (P2PlacedPiece == true && Input.GetMouseButtonUp(2))
        {
            ChangePlayer();
            P2PlacedPiece = false;
        }
        if(turntimeP1 <= 0 || turntimeP2 <=0)
        {
            GameOver.gameObject.GetComponent<Text>().enabled = true;
            GameIsOver = true;

        }

    }
    public void ChangePlayer()
    {
        if(Player1Turn == true&& Player2Turn ==false && P1PlacedPiece ==true)
        {
            Player1Turn = false;
            Player2Turn = true;
            Debug.Log("P2 turn");
            Background.color = new Color(255, 0, 0);


        }
        else if (Player2Turn == true && Player1Turn ==false && P2PlacedPiece ==true)
        {
            Player1Turn = true;
            Player2Turn = false;
            
            Debug.Log("P1 turn");
            Background.color = new Color(0, 0, 255);


        }
    }
}
