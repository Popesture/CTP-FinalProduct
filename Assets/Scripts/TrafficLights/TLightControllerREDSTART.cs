using UnityEngine;
using System.Collections;

public class TLightControllerREDSTART : MonoBehaviour {

    public bool isGreen = false;
    public bool isYel = false;
    public bool isRedYel = false;
    public float timeLeft = 8.0f;
    public float yelTime = 2.0f;

    public GameObject redLight;
    public GameObject yelLight;
    public GameObject greLight;
    public GameObject redYelLight;

    // Use this for initialization
    void Start () {
        isGreen = false;
        isYel = false;
        timeLeft = 8.0f;
    }
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        yelTime -= Time.deltaTime;
        if (timeLeft < 0)
        {
            CheckState();
        }
        if(yelTime < 0)
        {
            CheckState();
        }
    }

    void setRed()
    {
        redLight.gameObject.SetActive(true);
        yelLight.gameObject.SetActive(false);
        isGreen = false;
        setTime();
    }

    void setYel()
    {
        yelLight.gameObject.SetActive(true);
        greLight.gameObject.SetActive(false);
        isYel = true;
        isGreen = false;
        setTime();
    }

    void setGre()
    {
        greLight.gameObject.SetActive(true);
        redYelLight.gameObject.SetActive(false);
        yelLight.gameObject.SetActive(false);
        isGreen = true;
        setTime();
    }

    void setRedYel()
    {
        redYelLight.gameObject.SetActive(true);
        redLight.gameObject.SetActive(false);
        isRedYel = true;
        isGreen = false;
        setTime();
    }

    void setTime() //resets the lights durations
    {
        yelTime = 2.0f;
        timeLeft = 8.0f;
    }

    void CheckState()//Checks for which state lights are currently in and calls next configuration of lights
    {
        if(isGreen && timeLeft <= 0)
        {
            setYel();
        }

        if(isYel && yelTime <= 0)
        {
            setRed();
            isYel = false;
        }
        if(!isRedYel && timeLeft <= 0)
        {
            setRedYel();
        }

        if(isRedYel && yelTime <= 0)
        {
            setGre();
            isRedYel = false;
        }
    }
   
}
