using UnityEngine;
using System.Collections;

public class DeadTree : PointNClickable
{
    public GameObject wotw1;
    public GameObject wotw2;
    public GameObject wotw3;
    public GameObject wotw4;
    public GameObject wotw5;

    public override void Interact()
    {
        Debug.Log("Interact with dead tree");
        if (wotw1.activeSelf && wotw2.activeSelf && wotw3.activeSelf
            && wotw4.activeSelf && wotw5.activeSelf)
        {
            Debug.Log("Changed will of the wisps parent to dead tree");
            wotw1.transform.SetParent(this.transform);
            wotw2.transform.SetParent(this.transform);
            wotw3.transform.SetParent(this.transform);
            wotw4.transform.SetParent(this.transform);
            wotw5.transform.SetParent(this.transform);
        }
    }
}
