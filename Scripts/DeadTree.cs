using UnityEngine;
using System.Collections;

public class DeadTree : PointNClickable
{
    public GameObject[] wotw;

    Vector3 rangeWOTW = new Vector3(2,2,2);

    public override void Interact()
    {
        Debug.Log("Interact with dead tree");
        bool isAllWOTWActive = true;
        foreach(GameObject w in wotw)
        {
            if (!w.activeSelf)
            {
                isAllWOTWActive = false;
                break;
            }
        }


        if (isAllWOTWActive)
        {
            Debug.Log("Changed will of the wisps parent to dead tree");
            foreach(GameObject w in wotw)
            {
                w.transform.SetParent(this.transform);
                w.GetComponent<WillOTheWisp>().middle = transform.position;
                w.GetComponent<WillOTheWisp>().middle.y += 1.5f;
                w.GetComponent<WillOTheWisp>().range = rangeWOTW;
            }
        }
    }
}
