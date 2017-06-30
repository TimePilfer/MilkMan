using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour
{

    bool entered = false;
    public string displayText;
    public float boxX;
    public float boxY;
    public float boxWidth;
    public float boxHeight;



    
    

    ////this will tell us if the player
    //// has enter or has exit the collider
    //private bool showName = false;

    ////this is a unity function that fires 
    //// when this 2dCollider enters another collider
    //void OnTriggerEnter2D()
    //{
    //    //we know that the player has just enterd 
    //    // the collider so we want to show name
    //    showName = true;
    //}
    ////this is unity function that fires when
    //// this collider exits another collider
    //void OnTriggerExit2D()
    //{
    //    //we know the player has left the
    //    // collider so we dont want to show name
    //    showName = false;
    //}
    ////OnGUI is a unity function that will let us use GUI elements
    //void OnGUI()
    //{
    //    //if showName is true then show the lable
    //    if (showName == true)
    //    {
    //        //this creats a lable in top left corner and will
    //        // display the name of the object from the hierarchy
    //        GUI.Label(new Rect(10, 10, 100, 100), "Hi!");
    //    }
    //}



    //use this for initialization
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            entered = true;

        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            entered = false;
        }

    }

    void OnGUI()
    {

        if (entered)
        {
            GUI.skin.label.fontSize = 20;
            GUI.contentColor = Color.black;
            GUI.Label(new Rect(boxX, boxY, boxWidth, boxHeight), displayText);

        }

    }

}
