using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   //'private' defines variables within the scope of 'public class Player'
   private BoxCollider2D boxCollider;
   private Vector3 moveDelta;
   private RaycastHit2D hit;

   private void Start() //Note: This is a function that runs at game start
   {
       boxCollider = GetComponent<BoxCollider2D>();
   }

   private void FixedUpdate() //Note: This is a function that runs every frame
   {
       //Check for input
       float x = Input.GetAxisRaw("Horizontal"); //-1, 0, or 1
       float y = Input.GetAxisRaw("Vertical"); //-1, 0, or 1
       
       // Reset moveDelta
       moveDelta = new Vector3(x,y,0);

       //Swap sprite direction based on movement
       if (moveDelta.x > 0) 
            transform.localScale = new Vector3(1, 1, 1);
       else if (moveDelta.x < 0) 
            transform.localScale = new Vector3(-1, 1, 0);

        // Horizontal: Checks if we can move in given direction by casting a box - if box returns null then we can move
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null) //box does not detect collision object, movement is allowed
        {
        //Movement
        transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
        
        // Same as above, but for vertical
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null) //box does not detect collision object, movement is allowed
        {
        //Movement
        transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }



   }
}
