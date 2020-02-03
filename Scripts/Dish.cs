using System;
using UnityEngine;

public class Dish : PointNClickable
{
    public AnimationTransform animationTransform;
    public AudioSource successSFX;

    public void Start()
    {
        Debug.Log("WOTW big big");
        Debug.Log(WillOTheWisp.wotwBigBig);
    }

    public override AudioSource Interact()
    {
        if (animationTransform.state == AnimationTransform.State.BEFORE)
        {
            // big wotw inactive
            if (!WillOTheWisp.wotwBigBig.activeSelf)
            {
                WillOTheWisp.wotwBigBig.SetActive(true);
                Debug.Log("Big WOTW active");
                return successSFX;
            }
            // big wotw follows
            else if (Lamp.nbWosps == 3)
            {
                Debug.Log("NB WOSPS: 3");
                animationTransform.state = AnimationTransform.State.MOVING;
                Debug.Log("Dish falls");
                return successSFX;
            }

            Debug.Log("NB WOSPS: " + Lamp.nbWosps);
            Debug.Log("Dish does not move");
            return null;
        }
        else
        {
            Debug.Log("Nothing happens, dish already fallen");
            return null;
        }
    }
}
