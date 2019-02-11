using UnityEngine;
using System.Collections;

public class Grave : PointNClickable
{
    // WillOTheWhisp
    public WillOTheWisp wotw; 

    public override void Interact() 
    {
        Debug.Log("Interaction with grave");
        wotw.gameObject.SetActive(true);
    }
}
