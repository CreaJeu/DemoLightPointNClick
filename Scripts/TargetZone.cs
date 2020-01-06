using UnityEngine;
using System.Collections;

public class TargetZone : PointNClickable
{
    public GameObject lampWOTW;

    public override void Interact()
    {
        Debug.Log("interact with zone");
        lampWOTW.SetActive(true);
    }
}
