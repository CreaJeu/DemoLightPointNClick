using System;
using UnityEngine;

public class Dish : PointNClickable
{
    public AnimationTransform animationTransform;
    public AudioSource successSFX;

    bool waitingToFall = false;

    public override AudioSource Interact()
    {
        if (animationTransform.state == AnimationTransform.State.BEFORE)
        {
            animationTransform.state = AnimationTransform.State.MOVING;
            return successSFX;
        }
        else
        {
            return null;
        }
    }
}
