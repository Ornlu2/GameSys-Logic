using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleSegment : MonoBehaviour {

    public bool P1Captured;
    public bool P2Captured;

    private GameManager GM;
    private SpriteRenderer TriangleSeg;
    private Color OriginalColor;

    // Use this for initialization
    void Start () {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        //Fetch the mesh renderer component from the GameObject
        TriangleSeg = GetComponent<SpriteRenderer>();
        
        //Fetch the original color of the GameObject
        OriginalColor = TriangleSeg.color;
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    private void OnMouseOver()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
           // Debug.Log("Target Position: " + hit.collider.gameObject.transform.position);
        }
        if (GM.Player1Turn == true)
        {
            if(P2Captured==false)
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 255);

            }

            if (Input.GetMouseButtonUp(0)&& P2Captured == false&& P1Captured == false)
            {
                Player1Captured();
                P1Captured = true;
            }
          

                    
        }
        if (GM.Player2Turn == true)
        {
            if (P1Captured == false)
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
            }
            if (Input.GetMouseButtonUp(0)&& P1Captured ==false&& P2Captured ==false)
            {
                Player2Captured();
                P2Captured = true;
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
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 255);
        Debug.Log("Blue Captured");
        GM.ChangePlayer();
    }
    void Player2Captured()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        Debug.Log("Red Captured");
        GM.ChangePlayer();
    }

}
