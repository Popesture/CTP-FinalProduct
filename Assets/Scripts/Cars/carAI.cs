using UnityEngine;
using System.Collections;

public class carAI : MonoBehaviour {

	public Transform thisObject;
	public Transform target;
	private NavMeshAgent navComponent;
	public int numCount = 0;

    public bool isStopped = false;


	void Awake() 
	{
		target = GameObject.FindGameObjectWithTag("Player").transform; //Find a end goal zone
		navComponent = this.gameObject.GetComponent<NavMeshAgent>(); //Find navigation mesh in which to 'walk/drive'
		Simulate ();
	}
	
	void Simulate() 
	{
		
		//float remainingDist = Vector3.Distance(target.position, transform.position); //Tracks how far car is from target
		
		if(target)
		{
			navComponent.SetDestination(target.position); //Function to map path to target
		}
		
		else
		{
			if(target = null)
			{
				target = this.gameObject.GetComponent<Transform>();//Error check in case of no/null target
			}
			else
			{
				target = GameObject.FindGameObjectWithTag("Player").transform; //else search for target
			}
		}				
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player")
		{
			Destroy (gameObject); //Destory car if it hits its goal
		}        
    }

    void OnTriggerStay(Collider col)
    {        
        if (col.gameObject.tag == "detectCube") //if the car hits a traffic light..
        {
            checkLight();//call checkLight to determine if it can pass the lights
        }

        if (col.gameObject.tag == "detectCube2")//""
        {
            checkLight2();//""
        }

        if (col.gameObject.tag == "railCube") //if the car hits a railway stop..
        {
            railCheck();
        }


        if (col.gameObject.tag == "stopCube") //if the car hits a stopCube behind another car..
        {
            if (col.gameObject.GetComponent<StopCar>().isStopped)//Check if the car infront has stopped
            {
                gameObject.GetComponent<NavMeshAgent>().speed = 0.0f;//if so, stop as well
            }
            else
            {
                gameObject.GetComponent<NavMeshAgent>().speed = 2.5f;//otherwise keep going
            }
        }
    }

    void checkLight()
    {
        if (GameObject.Find("detectCube").GetComponent<TLightControllerREDSTART>().isGreen == true)
        {
            gameObject.GetComponent<NavMeshAgent>().speed = 2.5f;
            isStopped = false;
        }
        else
        {
            gameObject.GetComponent<NavMeshAgent>().speed = 0.0f; //Stop car moving while light is red
            isStopped = true;
        }        
    }

    void checkLight2()
    {
        if (GameObject.FindGameObjectWithTag("detectCube2").GetComponent<TLightControllerGREENSTART>().isGreen == true)
        {
            gameObject.GetComponent<NavMeshAgent>().speed = 2.5f;
            isStopped = false;
        }
        else
        {
            gameObject.GetComponent<NavMeshAgent>().speed = 0.0f; //Stop car moving while light is red
            isStopped = true;
        }
    }

    void railCheck()
    {
        if (GameObject.FindGameObjectWithTag("railCube").GetComponent<trainXScript>().isTrainCrossing == true)
        {
            gameObject.GetComponent<NavMeshAgent>().speed = 0.0f; //Stop car moving while train is crossing
            isStopped = true;
        }
        else
        {
            gameObject.GetComponent<NavMeshAgent>().speed = 2.5f;
            isStopped = false;
        }
    }
}
