using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : Collidable
{
   public string[] sceneNames; //List of random potential locations
   
   protected override void OnCollide(Collider2D coll)
   {
       if (coll.name == "Player")
       {
           //Save game
           GameManager.instance.SaveState();
           //Teleport player
           string sceneName = sceneNames[Random.Range(0, sceneNames.Length)]; //Selects a random scene from the sceneNames array for the teleport location
           SceneManager.LoadScene(sceneName);
       }
   }
}
