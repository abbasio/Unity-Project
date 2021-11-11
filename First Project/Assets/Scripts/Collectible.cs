using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : Collidable
{
  //Logic
  protected bool collected; //Only accessible by this class and its children

  protected override void OnCollide(Collider2D coll) //Overrides the usual collision function with a new, collectible-specific collision event
  {
    if (coll.name == "Player") //If the object currently colliding with this collectible is the player
        OnCollect();
  }

  protected virtual void OnCollect() 
  {
      collected = true;
  }
}
