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

                    if ( P2Captured == false)
                    {
                        P2Captured = true;
                        P1Captured = false;
                        Player1Captured();

                    }
                    else if (P1Captured == true)
                    {
                        return;
                    }
                    else if (P2Captured ==true)
                    {
                        GM.P1Score++;
                        GM.P2Score--;
                    }

                }



            }
            if (GM.Player2Turn == true)
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);


                if (Input.GetMouseButtonUp(1))
                {

                    if (P1Captured == false )
                    {
                        P2Captured = true;
                        P1Captured = false;
                        Player2Captured();
                    }
                    else if(P2Captured ==true)
                    {
                        return;
                    }
                    else if (P1Captured == true)
                    {
                        GM.P2Score++;
                        GM.P1Score--;
                    }

                }



            }
        }
    }
    private void OnMouseExit()
    {
        /*
        if (P2Captured == true&& P1Captured ==false)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
            Debug.Log("Mouse leaving space blue");

        }
       else  if (P1Captured ==true&& P2Captured ==false)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 255);
            Debug.Log("Mouse leaving space red");

        }
        */
         
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
