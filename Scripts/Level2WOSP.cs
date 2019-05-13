using UnityEngine;
using System.Collections;

public class Level2WOSP : MonoBehaviour
{
    public Player player;
    public float dMin;
    public float dMax;
    public float yAmplitude;
    private float yMin;
    private float yMax;

	// Use this for initialization
	void Start()
	{
        yMin = transform.position.y - yAmplitude;
        yMax = yMin + yAmplitude;
	}

	// Update is called once per frame
    void Update()
    {
        float d = Vector3.Distance(player.transform.position, this.transform.position);
        if (d < dMin)
        {
            transform.position = new Vector3(transform.position.x, yMin, transform.position.z);
        }
        else if (d >= dMin && d <= dMax)
        {
            float posY = yMin + (d - dMin) * (yMax - yMin) / (dMax - dMin);
            transform.position = new Vector3(transform.position.x, posY, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, yMax, transform.position.z);
        }
    }
}
