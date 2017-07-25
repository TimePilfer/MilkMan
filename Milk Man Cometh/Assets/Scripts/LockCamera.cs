using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCamera : MonoBehaviour {

    void Update()
    {
        //transform.localEulerAngles.y=0;

        transform.position = new Vector3(transform.position.x, 13, transform.position.z);
    }
}
