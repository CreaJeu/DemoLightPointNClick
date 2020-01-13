using UnityEngine;
using System.Collections;

public class WotwBigBigZone : PointNClickable
{
    public WillOTheWisp wotwBigBig;
    public AudioSource successSFX;

    public override AudioSource Interact ()
    {
        if (wotwBigBig.isActiveAndEnabled)
        {
            // wotw follows player
            if(!wotwBigBig.isFollowsPlayer())
            {
                wotwBigBig.setPlayerAsTarget();
                return successSFX;
            }
            else
            {
                return null;
            }
        }

        return null;
    }
}
