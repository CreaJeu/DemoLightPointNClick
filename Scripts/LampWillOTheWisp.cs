using UnityEngine;
using System.Collections;

public class LampWillOTheWisp : MonoBehaviour
{
    protected float timeTillRand;
    protected Vector3 acceleration;
    protected Vector3 currSpeed;
    protected Vector3 newTarget;
    protected Vector3 oldTarget;
    //protected Vector3 localPosition;
    protected Vector3 destinationPicked;
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

        if (followsPlayer)
        {
            destinationPicked = DestinationPicker.destination;
            newTarget += destinationPicked;
        }
    }

    void Start()
    {
        currSpeed = Vector3.zero;
        acceleration = Vector3.zero;
        //localPosition = new Vector3(0, 0, 0);
        followsPlayer = false;
        timeTillRand = -1;
        if(middle == Vector3.zero)
        {
            middle = transform.position;
        }
    }


    public void setPlayerAsTarget()
    {
        followsPlayer = true;
        //middle = ... => cf. Lamp.Interact()
        timeTillRand = 0;
    }

    void Update()
    {
        float dt = Time.deltaTime;
        // changement de cible
        if (timeTillRand <= 0 || (followsPlayer && destinationPicked != DestinationPicker.destination))
        {
            oldTarget = transform.position;
            rechooseTargetRd();
            timeTillRand = Vector3.Distance(oldTarget, newTarget) / getSpeed();
            Vector3 gap = newTarget - oldTarget;
            acceleration = (-1 / (timeTillRand * timeTillRand)) * (timeTillRand * currSpeed - gap);
        }

        currSpeed += acceleration * dt;
        transform.position += currSpeed * dt;
        //transform.rotation = Quaternion.identity;
        timeTillRand -= dt;
    }
}
