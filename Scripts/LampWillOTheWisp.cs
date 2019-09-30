using UnityEngine;
using System.Collections;

public class LampWillOTheWisp : MonoBehaviour
{
    protected float timeTillRand;
    protected Vector3 acceleration;
    protected Vector3 currSpeed;
    protected Vector3 newTarget;
    protected Vector3 oldTarget;

    public Vector3 middle;
    public Vector3 range;
    public float speed = 10.0f;

    protected Vector3 posMin;
    protected Vector3 posMax;

    public Player player;

    protected float getSpeed()
    {
        return speed;
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

    protected void rechooseTargetRd()
    {
        float x = Random.Range(getPosMin().x, getPosMax().x);
        float y = Random.Range(getPosMin().y, getPosMax().y);
        float z = Random.Range(getPosMin().z, getPosMax().z);

        newTarget.x = x;
        newTarget.y = y;
        newTarget.z = z;
    }

    void Start()
    {
        currSpeed = Vector3.zero;
        acceleration = Vector3.zero;
        timeTillRand = -1;
        if(middle == Vector3.zero)
        {
            middle = transform.localPosition;
        }
    }


    public void setPlayerAsTarget()
    {
        transform.SetParent(player.transform);
    }

    void Update()
    {
        float dt = Time.deltaTime;
        if (timeTillRand <= 0)
        {
            oldTarget = transform.localPosition;
            rechooseTargetRd();
            timeTillRand = Vector3.Distance(oldTarget, newTarget) / getSpeed();
            Debug.Log("Time till rand: " + timeTillRand);
            Vector3 gap = newTarget - oldTarget;
            acceleration = (-1 / (timeTillRand * timeTillRand)) * (timeTillRand * currSpeed - gap);
        }

        currSpeed += acceleration * dt;
        transform.localPosition += currSpeed * dt;
        transform.rotation = Quaternion.identity;
        timeTillRand -= dt;
    }
}
