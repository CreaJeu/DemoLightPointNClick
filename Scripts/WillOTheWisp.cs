using UnityEngine;
using System.Collections;

public class WillOTheWisp : MonoBehaviour
{
    float timeTillRand;
    Vector3 acceleration;
    Vector3 currSpeed;
    Vector3 newTarget;
    Vector3 oldTarget;

    public Vector3 middle;
    public Vector3 range;

    private Vector3 posMin;
    private Vector3 posMax;

    float getSpeed()
    {
        return 20f;
    }

    Vector3 getPosMin()
    {
        posMin.x = middle.x - range.x;
        posMin.y = middle.y - range.y;
        posMin.z = middle.z - range.z;

        return posMin;
    }

    Vector3 getPosMax()
    {
        posMax.x = middle.x + range.x;
        posMax.y = middle.y + range.y;
        posMax.z = middle.z + range.z;

        return posMax;
    }

    void rechooseTargetRd()
    {
        float x = Random.Range(getPosMin().x, getPosMax().x);
        float y = Random.Range(getPosMin().y, getPosMax().y);
        float z = Random.Range(getPosMin().z, getPosMax().z);

        newTarget.x = x;
        newTarget.y = y;
        newTarget.z = z;
    }

	// Use this for initialization
	void Start()
	{
        currSpeed = Vector3.zero;
        acceleration = Vector3.zero;
        timeTillRand = -1;
	}

	// Update is called once per frame
	void Update()
    {
        float dt = Time.deltaTime;
        // changement de cible
        if (timeTillRand <= 0)
        {
            oldTarget = transform.localPosition;
            rechooseTargetRd();
            // Debug.Log("changement de cible " + newTarget.x + " " + newTarget.y + " " + newTarget.z);
            timeTillRand = Vector3.Distance(oldTarget, newTarget) / getSpeed();
            Vector3 gap = newTarget - oldTarget;
            acceleration = (-1 / (timeTillRand * timeTillRand)) * (timeTillRand * currSpeed - gap);
        }

        currSpeed += acceleration * dt;
        transform.localPosition += currSpeed * dt;
        timeTillRand -= dt;
	}
}
