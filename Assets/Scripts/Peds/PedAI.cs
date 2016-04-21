using UnityEngine;
using System.Collections;

public class PedAI : MonoBehaviour {

	public Transform thisObject;
	public Transform target;
	private NavMeshAgent navComponent;

    public bool isStopped = false;

    string pedGoal;


	void Awake() 
	{
        findGoal();

        target = GameObject.FindGameObjectWithTag(pedGoal).transform; //Find a end goal zone
		navComponent = this.gameObject.GetComponent<NavMeshAgent>(); //Find navigation mesh in which to 'walk'        

		Simulate ();
	}
	
	void Simulate() 
	{
		
		//float remainingDist = Vector3.Distance(target.position, transform.position); //Tracks how far pedestrian is from target

        if (target)
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
				target = GameObject.FindGameObjectWithTag(pedGoal).transform; //else search for target
			}
		}				
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == pedGoal)
		{
			Destroy (gameObject); //Destory pedestrian if it hits its goal
		}        
    }

    void findGoal() // calculate which goal to head toward
    {
        int rNumb;

        rNumb = Random.Range(1, 10);

        if (rNumb % 2 == 0)
        {
            pedGoal = "pedGoal2";            
        }
        else
        {
            pedGoal = "pedGoal";
        }
    }
       

    //void OnTriggerStay(Collider col)
    //{       
        

    //    if (col.gameObject.tag == "stopCube")
    //    {
    //        if (col.gameObject.GetComponent<StopCar>().isStopped)
    //        {
    //            gameObject.GetComponent<NavMeshAgent>().speed = 0.0f;
    //        }
    //        else
    //        {
    //            gameObject.GetComponent<NavMeshAgent>().speed = 2.5f;
    //        }
    //    }
    //}

}
