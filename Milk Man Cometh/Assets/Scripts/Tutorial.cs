using UnityEngine;
using System.Collections;
/*
 * This class will be attached invisible, pass-throughable objects. It will allow a message to be displayed when the player is occupying the same
 * space as the object. The message will be set in Unity in the editor when the script is attached to the object.
 */
public class Tutorial : MonoBehaviour
{
    //Is the player occupying the space?
    bool entered = false;
    //The text to display
    public string displayText;
    //Box coordinates
    public float boxX;
    public float boxY;
    //Box size
    public float boxWidth;
    public float boxHeight;

    //When the palyer enters the space, set the bool to true
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            entered = true;

        }

    }
    //When the palyer exits the space, set the bool to false
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            entered = false;
        }

    }
    //Displays the text on screen
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
