using UnityEngine;
using System.Collections;

public class StopCar : MonoBehaviour {
    public bool isStopped = false;
    carAI myParent;

    void Start()
    {
        myParent = transform.parent.GetComponent<carAI>();
    }

	// Update is called once per frame
	void Update () {
        if(myParent.isStopped)
        {
            isStopped = true;
        }
        else
        {
            isStopped = false;
        }
    }
}
