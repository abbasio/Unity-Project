using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public static GameManager instance; //static - accessible from anywhere
   private void Awake()
   {
       if (GameManager.instance != null) //If a game manager exists
       {
           Destroy(gameObject); //Prevents multiple game managers from existing simultaneously 
           return;
       }
       instance = this;
       SceneManager.sceneLoaded += LoadState; //Calls function every time the scene is loaded
       DontDestroyOnLoad(gameObject); //Keeps game object persistent
   }

   //Resources
   public List<Sprite> playerSprites;
   public List<Sprite> weaponSprites;
   public List<int> weaponPrices;
   public List<int> xpTable;

   //References
   public Player player;
   //public weapon weapon...

   //Logic
   public int gold;
   public int xp;

   //Save state
   /*
   * INT preferredSkin
   * INT gold
   * INT xp
   * INT weaponLevel
   */
   public void SaveState()
   {
       string save = "";
       save +="0" + "|";
       save += gold.ToString() + "|";
       save += xp.ToString() + "|";
       save += "0";

       PlayerPrefs.SetString("SaveState", save);

       Debug.Log(save);
   }

   public void LoadState(Scene s, LoadSceneMode mode)
   {
       if(!PlayerPrefs.HasKey("SaveState"))
       {
           return;
       }

       string[] data = PlayerPrefs.GetString("SaveState").Split('|');

       //Change player skin
       gold = int.Parse(data[1]);
       xp = int.Parse(data[2]);
       //Change weapon level
   }
}
