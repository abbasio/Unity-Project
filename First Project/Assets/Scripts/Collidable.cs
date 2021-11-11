using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter;
    private BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[10];

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>(); //Whatever object requires Box Collider 2D
    }

    protected virtual void Update()
    {
        //Collision work
        boxCollider.OverlapCollider(filter, hits); //Looks for objects that were collided with, puts it into the collider2D array
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null) //If nothing was collided with
                continue;
            
            OnCollide(hits[i]);
            
            hits[i] = null; //Cleans up array
        }
    }

    protected virtual void OnCollide(Collider2D coll)
    {
        Debug.Log(coll.name);
    }
}
