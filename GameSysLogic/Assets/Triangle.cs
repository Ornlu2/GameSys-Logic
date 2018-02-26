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
    void Start () {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();


        TrianglePiece = gameObject.GetComponent<SpriteRenderer>();

        OriginalColor = TrianglePiece.color;

    }

    // Update is called once per frame
    void Update () {
		
       
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
                    if(P2Captured == true)
                    {
                        P1Captured = true;
                        Player1Captured();
                    }
                    else if(P2Captured ==false&& P1Captured == false)
                    {
                        P2Captured = true;
                        P1Captured = false;
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
                        P1Captured = true;
                        Player1Captured();
                    }
                    else if (P2Captured == false && P1Captured == false)
                    {
                        P2Captured = true;
                        P1Captured = false;
                    }
                }



            }
        }
    }
    private void OnMouseExit()
    {
        if (P1Captured == false && P2Captured == false)
        {
            gameObject.GetComponent<SpriteRenderer>().color = OriginalColor;
        }
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
}
