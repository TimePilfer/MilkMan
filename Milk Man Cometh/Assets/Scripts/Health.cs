using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * This class handles everything related to the player's health bar. Moving it when the player loses or gains health, and drawing it on load.
 */
public class Health : MonoBehaviour {

    public float barDisplay; //current progress
    //Rect Position
    public Vector2 pos = new Vector2(20, 40);
    //Rect Size
    public Vector2 size = new Vector2(60, 20);
    //The texture's for the health bar
    public Texture emptyTex;
    public Texture fullTex;
    //The main rect
    public Rect rect;
    //The temporary rect
    public Rect temp;

    void Awake()
    {
        ////Creates two new rects for the health bar
        //rect = new Rect(0, 0, size.x, size.y * barDisplay);
        //temp = new Rect(0, 0, size.x, size.y * barDisplay);

        ////Flip the rects
        //rect.yMax = temp.yMin;
        //rect.yMin = temp.yMax;
        this.rect.y = this.rect.y * barDisplay;
    }
    /*
     * Currently, 
     */
    //void OnGUI()
    //{
    //    //Draw the rects
    //    //draw the background:
    //    GUI.BeginGroup(new Rect(pos.y, pos.x, size.x, size.y));
    //        GUI.Box(new Rect(0, 0, size.x, size.y), fullTex);

    //    //draw the filled-in part:
    //        GUI.BeginGroup(new Rect(0, 0, size.x, size.y * barDisplay));
    //            GUI.Box(new Rect(0, 0, size.x, size.y), emptyTex);
    //        GUI.EndGroup();
    //    GUI.EndGroup();
    //}

    void Update()
    {
        //Makes a rect
        rect = new Rect(0, 0, size.x, size.y * barDisplay);

        //bardisplay - changes with the player's health attribute
        barDisplay = (float)Damage.player.health/3;
        //        barDisplay = MyControlScript.staticHealth;
        transform.localScale = new Vector2(transform.localScale.x, barDisplay);
        transform.position = new Vector2(transform.position.x, transform.position.y);
    }
}
