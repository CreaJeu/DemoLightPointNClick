using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bidon : PointNClickable {
	public override AudioSource Interact()
    {
        Debug.Log("interaction with bidon");
		return null;
    }
}
