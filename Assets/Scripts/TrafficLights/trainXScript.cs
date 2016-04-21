using UnityEngine;
using System.Collections;

public class trainXScript : MonoBehaviour
{

    public bool isTrainCrossing = false;
    public float timeLeft = 5.0f;
    public float crossTimeLeft = 8.0f;

    public GameObject crossingPole;

    public Quaternion rot;

    // Use this for initialization
    void Start()
    {
        isTrainCrossing = false;
        timeLeft = 5.0f;
        crossTimeLeft = 8.0f;
        rot = crossingPole.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0 && isTrainCrossing)
        {
            simCrossingUp();
        }
        else if (timeLeft <= 0 && !isTrainCrossing)
        {
            simCrossingDown();
        }
    }

    void simCrossingUp()
    {
        rot = crossingPole.transform.rotation;

        if (rot.z > 0)
        {
            crossingPole.transform.Rotate(rot.x, rot.y, -1);//raise the traffic barrier
        }

        if(rot.z < 0)
        {
            isTrainCrossing = false;
            resetTime();            
        }        
    }

    void simCrossingDown()
    {
        rot = crossingPole.transform.rotation;

        if (rot.z < 0.7)
        {
            crossingPole.transform.Rotate(rot.x, rot.y, 1);//lower the traffic barrier
        }
        if (rot.z > 0.7)
        {
            isTrainCrossing = true;
            resetTime();            
        }
    }

    void resetTime()
    {
        timeLeft = 5.0f;
    }
}
