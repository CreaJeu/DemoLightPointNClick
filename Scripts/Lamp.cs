using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : PointNClickable
{
    private WillOTheWisp lampWOTW;
    public GameObject wospObject;

    void Start()
    {
        lampWOTW = wospObject.GetComponent<WillOTheWisp>();    
    }

    public override void Interact()
    {
        //Debug.Log("Interact with lamp");
        if (wospObject.activeSelf)
        {
            lampWOTW.setPlayerAsTarget();
            lampWOTW.middle.x = 0;
            lampWOTW.middle.y = 3;
            lampWOTW.middle.z = 0;

            lampWOTW.range.x = 3;
            lampWOTW.range.y = 2;
            lampWOTW.range.z = 4;

            lampWOTW.speed = 9;
            //Debug.Log("Set player as target");
        }
    }
}
