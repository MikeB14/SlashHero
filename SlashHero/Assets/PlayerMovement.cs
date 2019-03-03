using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D RB;
    //public Transform Cursor;
    public bool IsAttacking = false;
    public bool IsGrounded = true;


    IEnumerator Grounded()
    {
        yield return new WaitForSeconds(3f);


    }


	// Use this for initialization
	void Start () {
        RB = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ReGround();
    }

    private void MovePlayer()
    {
        if(Input.GetMouseButtonDown(0)){
            Vector2 MousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            Vector2 ObjectPos = Camera.main.ScreenToWorldPoint(MousePos);
            transform.position = (ObjectPos);

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        IsGrounded = false;
        //StartCoroutine(Grounded());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsGrounded = true;
    }

    void ReGround (){
        if(IsGrounded == false){
            transform.Translate(0, -0.1f, 0);
        }
        /*
        else if(IsGrounded == true){
            transform.position = Vector2.zero;
        }
        */
    }

}
