using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	public GameObject plane;
	public int width = 10; //Default value 10 - Can be changed in the creator
	public int height = 10; //Default value 10 - Can be changed in the creator

	private GameObject [,] grid = new GameObject[10,10];//May have to change this for creator!

	void Awake() //May have to change this for creator!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
	{
		for(int x = 0; x < width; x++)
		{
			for(int z = 0; z < height; z++)
			{
				GameObject gridPlane = (GameObject)Instantiate(plane); //instance the plane
				gridPlane.transform.position = new Vector3(gridPlane.transform.position.x + x, //set position to these coordiantes
				                                           gridPlane.transform.position.y,
				                                           gridPlane.transform.position.z + z);
				grid[x,z] = gridPlane; // Add instanced object to array

			}
		}
	}

	void OnGUI()
	{
		//if(GUIText. G

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
