using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

   public  bool Player1Turn = true;
   public  bool  Player2Turn = false;


    public Text P1ScoreUI;
    public Text P2ScoreUI;

    public int P1Score;
    public int P2Score;

    public GameObject P1TurnTime;
    public GameObject P2TurnTime;
	// Use this for initialization
	void Start () {
       P1ScoreUI=  P1ScoreUI.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        P1ScoreUI.text = "Score: " + P1Score;
        P2ScoreUI.text = "Score: " + P2Score;
	}
   public  void ChangePlayer()
    {
        if(Player1Turn == true&& Player2Turn ==false)
        {
            Player1Turn = false;
            Player2Turn = true;
            Debug.Log("P2 turn");
        }
        else if (Player2Turn == true && Player1Turn ==false)
        {
            Player1Turn = true;
            Player2Turn = false;
            
            Debug.Log("P1 turn");
        }
    }
}
