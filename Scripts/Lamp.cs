using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : PointNClickable
{
    private LampWillOTheWisp lampWOTW;
    public GameObject wospObject;

    void Start()
    {
        lampWOTW = wospObject.GetComponent<LampWillOTheWisp>();    
    }

    public override void Interact()
    {
        Debug.Log("Interact with lamp");
        if (wospObject.activeSelf)
        {
            lampWOTW.setPlayerAsTarget();
            lampWOTW.range = new Vector3(0.1f,0.1f,0.1f);
            wospObject.transform.localPosition = Vector3.zero;
            lampWOTW.speed = 5;
            Debug.Log("Set player as target");
        }
    }
}
