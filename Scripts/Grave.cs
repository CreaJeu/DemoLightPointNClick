using UnityEngine;
using System.Collections;

public class Grave : PointNClickable
{
    // WillOTheWhisp
    public WillOTheWisp wotw; 
	public AudioSource successSFX;

	public override AudioSource Interact() 
    {
        Debug.Log("Interaction with grave");
		if (!wotw.gameObject.activeSelf)
		{
			wotw.gameObject.SetActive(true);
			return successSFX;
		}
		return null;
    }
}
