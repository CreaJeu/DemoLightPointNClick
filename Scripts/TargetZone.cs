using UnityEngine;
using System.Collections;

public class TargetZone : PointNClickable
{
    public GameObject lampWOTW;

	public override AudioSource Interact()
    {
        Debug.Log("interact with zone");
        lampWOTW.SetActive(true);
		return null;
    }
}
