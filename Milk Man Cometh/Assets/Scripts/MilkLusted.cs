using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkLusted : MonoBehaviour {

    public static int LustMeter = 0;
    private static int Last_LustMeter = 0;

    private UnityEngine.UI.Slider MilkLust;

	// Use this for initialization
	void Start () {
        MilkLust = GameObject.Find("HUDCanvas/LustMeter").GetComponent<UnityEngine.UI.Slider>();
        MilkLust.value = 0;
    }
	
	// Update is called once per frame
	void Update () {
		if (Last_LustMeter != LustMeter)
        {
            MilkLust.value = LustMeter;
            Last_LustMeter = LustMeter;
        }
	}
}
