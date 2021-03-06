using UnityEngine;
using System.Collections;

public class DeadTree : ChangeScene
{
    public GameObject[] wotw;
    public AnimationTransform animationTransform;
    public float timeUntilFall;
	public AudioSource successSFX;

    Vector3 rangeWOTW = new Vector3(2, 2, 2);

    bool waitingToFall = false;

	public override AudioSource Interact()
    {
        base.Interact();
		if (waitingToFall)
		{
			return null;
		}
        // Debug.Log("Interact with dead tree");
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
            // Debug.Log("Changed will of the wisps parent to dead tree");
            foreach (GameObject w in wotw)
            {
                w.transform.SetParent(this.transform);
                w.GetComponent<WillOTheWisp>().middle = transform.position;
                w.GetComponent<WillOTheWisp>().middle.y += 1.5f;
                w.GetComponent<WillOTheWisp>().range = rangeWOTW;
            }
            waitingToFall = true;
			return successSFX;
        }
		return null;
    }

    public void Update()
    {
        if(waitingToFall)
        {
            timeUntilFall -= Time.deltaTime;
            if (timeUntilFall <= 0)
            {
                animationTransform.state = AnimationTransform.State.MOVING;
                waitingToFall = false;
                this.isOn = true;
            }
        }   
    }
}
