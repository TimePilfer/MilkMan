using UnityEngine;
using System.Collections;

public class Arm : MonoBehaviour {

    //Vector3 mouse_pos;
    //Transform target; //Assign to the object you want to rotate
    //Vector3 object_pos;
    //float angle;

    private float x;
    private Vector3 ls;

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

    void Start()
    {
        x = transform.localScale.x;
        ls = transform.localScale;
    }

    void Update()
    {
        if (BasicControls.facingRight == true)
        {
            Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

            float rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            if (dir.x >= 0)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

                ls.x = x;
                transform.localScale = ls;
            }
            else
            {
                transform.rotation = Quaternion.Euler(0f, 0f, rotZ + 180);
                ls.x = -x;
                transform.localScale = ls;
            }
        }
        else
        {
            Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

            float rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            if (dir.x >= 0)
            {
                transform.rotation = Quaternion.Euler(0f + 180, 0f + 180, rotZ);

                ls.x = x;
                transform.localScale = ls;
            }
            else
            {
                transform.rotation = Quaternion.Euler(0f + 180, 0f + 180, rotZ + 180);
                ls.x = -x;
                transform.localScale = ls;
            }
        }

        
    }
}



