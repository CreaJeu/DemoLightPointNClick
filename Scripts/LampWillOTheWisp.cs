using UnityEngine;
using System.Collections;

public class LampWillOTheWisp : MonoBehaviour
{
    protected float timeTillRand;
    protected Vector3 acceleration;
    protected Vector3 currSpeed;
    protected Vector3 newTarget;
    protected Vector3 oldTarget;
    protected Vector3 localPosition;
    protected bool followsPlayer;

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

        newTarget += player.transform.position;
    }

    void Start()
    {
        currSpeed = Vector3.zero;
        acceleration = Vector3.zero;
        localPosition = new Vector3(0, 0, 0);
        followsPlayer = false;
        timeTillRand = -1;
        if(middle == Vector3.zero)
        {
            middle = transform.localPosition;
        }
    }


    public void setPlayerAsTarget()
    {
        followsPlayer = true;
        middle.x = 0;
        middle.y = 2;
        middle.z = 0;

        range.x = 2;
        range.y = 2;
        range.z = 2;

        newTarget = transform.position;
        timeTillRand = 0;
    }

    void Update()
    {
        if (followsPlayer)
        {
            float dt = Time.deltaTime;

            if (timeTillRand <= 0)
            {
                oldTarget = newTarget;
                rechooseTargetRd();
                timeTillRand = Vector3.Distance(oldTarget, newTarget) / getSpeed();
                Vector3 gap = newTarget - oldTarget;
                Debug.Log(newTarget);
                acceleration = (-1 / (timeTillRand * timeTillRand)) * (timeTillRand * currSpeed - gap);
            }

            currSpeed += acceleration * dt;
            //localPosition += currSpeed * dt;
            transform.position += currSpeed * dt;
            //transform.position = localPosition + player.transform.position;
            //transform.rotation = Quaternion.identity;
            timeTillRand -= dt;
        }
        else
        {
            float dt = Time.deltaTime;
            if (timeTillRand <= 0)
            {
                oldTarget = transform.localPosition;
                rechooseTargetRd();
                timeTillRand = Vector3.Distance(oldTarget, newTarget) / getSpeed();
                Vector3 gap = newTarget - oldTarget;
                acceleration = (-1 / (timeTillRand * timeTillRand)) * (timeTillRand * currSpeed - gap);
            }

            currSpeed += acceleration * dt;
            transform.localPosition += currSpeed * dt;
            //transform.rotation = Quaternion.identity;
            timeTillRand -= dt;
        }
    }
}
