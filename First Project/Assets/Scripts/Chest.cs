using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectible
{
    public Sprite emptyChest;
    public int goldAmount = 5;
    
    protected override void OnCollect()
    { 
        if(!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            Debug.Log("Grant " + goldAmount + " gold!");
            //gold += goldAmount;
        }
        

    }
}
