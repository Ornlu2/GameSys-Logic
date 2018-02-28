using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : MonoBehaviour {

    private GameManager GM;

    public bool P1Captured;
    public bool P2Captured;
    private SpriteRenderer TrianglePiece;

    private Color OriginalColor;

    // Use this for initialization
    void Start() {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();


        TrianglePiece = gameObject.GetComponent<SpriteRenderer>();

        OriginalColor = TrianglePiece.color;

    }
    private void OnMouseOver()
    {
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                // Debug.Log("Target Position: " + hit.collider.gameObject.transform.position);
            }
            if (GM.Player1Turn == true)
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 255);

                if (Input.GetMouseButtonUp(1))
                {
                    if (P1Captured == true)
                    {
                        return;
                    }
                    if (P2Captured == false)
                    {
                        P1Captured = true;
                        P2Captured = false;
                        OriginalColor = new Color(0, 0, 255);

                        Player1Captured();

                    }
                    else if (P2Captured == true)
                    {
                        P1Captured = false;
                        P2Captured = true;
                        OriginalColor = new Color(0, 0, 255);
                        Player1CapturedP2();
                    }
                     
                   
                }
            }
            if (GM.Player2Turn == true)
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);

                if (Input.GetMouseButtonUp(1))
                {
                    if (P2Captured == true)
                    {
                        return;
                    }
                    if (P1Captured == false)
                    {
                        P1Captured = false;
                        P2Captured = true;
                        OriginalColor = new Color(255, 0, 0);

                        Player2Captured();
                    }
                    else if (P1Captured == true)
                    {
                        P2Captured = true;
                        P1Captured = false;
                        OriginalColor = new Color(255, 0, 0);
                        Player2CapturedP1();

                    }
                    
                   
                }
            }
        }
    }
    private void OnMouseExit()
    {
        gameObject.GetComponent<SpriteRenderer>().color = OriginalColor;
    }
    void Player1Captured()
    {
        Debug.Log("Blue Captured");
        GM.P1Score++;
    }
    void Player2Captured()
    {
        Debug.Log("Red Captured");
        GM.P2Score++;
    }
    void Player2CapturedP1()
    {
        Debug.Log("P2 captured blue territory");
        GM.P2Score++;
        GM.P1Score--;
    }
    void Player1CapturedP2()
    {
        Debug.Log("P1 captured red territory");

        GM.P1Score++;
        GM.P2Score--;
    }

}
