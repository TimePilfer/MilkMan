using UnityEngine;
using System.Collections;
/*
 * This class controls the arm of the robot which will fire bullets from it. It gives it full, 360 degrees of motion and will invert when the 
 * character is facing different directions. The bullet controls are handled in the bullet script.
 */
public class Arm : MonoBehaviour {

    //Vector3 mouse_pos;
    //Transform target; //Assign to the object you want to rotate
    //Vector3 object_pos;
    //float angle;

    //The x axis on the arm
    private float x;

    public Animator anim;
    //The characters location in 3d
    private Vector3 ls;

    public bool isPaused;
    //void Update()
    //{
    //    //var mouse = Input.mousePosition;
    //    //var screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
    //    //var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
    //    //var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
    //    //transform.rotation = Quaternion.Euler(0, 0, angle);

    //    var mousePos = Input.mousePosition;
    //    mousePos.z = 32; //The distance from the camera to the player object
    //    Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
    //    lookPos = lookPos - transform.position;
    //    //if (controls.facingRight == true)
    //    //{
    //        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
    //    //}
    //    //else
    //    //{
    //    //    float angle = Mathf.Atan2(-lookPos.y, lookPos.x) * Mathf.Rad2Deg;
    //    //}
    //    transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);


    //}

    //void Update()
    //{
    //    if (transform.localScale.x < 1)
    //    {
    //        var mousePos = Input.mousePosition;
    //        mousePos.z = 32; //The distance from the camera to the player object
    //        Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
    //        lookPos = lookPos - transform.position;
    //        //if (controls.facingRight == true)
    //        //{
    //        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
    //        //}
    //        //else
    //        //{
    //        //    float angle = Mathf.Atan2(-lookPos.y, lookPos.x) * Mathf.Rad2Deg;
    //        //}
    //        transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
    //    }
    //    else if (transform.localScale.x > -1)
    //    {
    //        var mousePos = Input.mousePosition;
    //        mousePos.z = 32; //The distance from the camera to the player object
    //        Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
    //        lookPos = lookPos - transform.position;
    //        //if (controls.facingRight == true)
    //        //{
    //        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
    //        //}
    //        //else
    //        //{
    //        //    float angle = Mathf.Atan2(-lookPos.y, lookPos.x) * Mathf.Rad2Deg;
    //        //}
    //        transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
    //    }
    //}

    //Gets the info for the character
    void Start()
    {
        x = transform.localScale.x;
        ls = transform.localScale;
        anim = GetComponentInParent<Animator>();
    }

    //Handles the character facing different directions
    void Update()
    {
        if (GameObject.Find("respawnPoint").GetComponent<Pause>().isPaused)
        {
            isPaused = true;
        }
        else
        {
            isPaused = false;
        }

        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("RobotDeath"))
        {
            if (!isPaused)
            {
                //If the characters are facing right
                if (BasicControls.facingRight == true)
                {
                    //The vector3 position of the character
                    Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
                    //The rotation of the character
                    float rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                    //If the arm is pointing towards the front of the character
                    if (dir.x >= 0)
                    {
                        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

                        ls.x = x;
                        transform.localScale = ls;
                    }
                    //If the arm is pointing towards the away from the character
                    else
                    {
                        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + 180);
                        ls.x = -x;
                        transform.localScale = ls;
                    }
                }
                //If the characters are facing left
                else
                {
                    //The vector3 position of the character
                    Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
                    //The rotation of the character
                    float rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                    //If the arm is pointing towards the front of the character
                    if (dir.x >= 0)
                    {
                        //The +180 on x and y lets the arm rotate properly in the other direction
                        transform.rotation = Quaternion.Euler(0f + 180, 0f + 180, rotZ);

                        ls.x = x;
                        transform.localScale = ls;
                    }
                    //If the arm is pointing towards the away from the character
                    else
                    {
                        //The +180 on x and y lets the arm rotate properly in the other direction
                        transform.rotation = Quaternion.Euler(0f + 180, 0f + 180, rotZ + 180);
                        ls.x = -x;
                        transform.localScale = ls;
                    }
                }
            }
            
        }

            

        
    }
}



