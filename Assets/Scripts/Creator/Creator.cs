using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Creator : MonoBehaviour {

    public Selectable button;

    public void Start()
    {
        //Creates 3D array of gameobjects
        GameObject[,,] GameObjectArray3D = new GameObject[100, 1, 100];

        //Loop through all the array indexes and instantiate a simple Cube
        for (int x = 0; x < GameObjectArray3D.GetLength(0); x++)
        {
            for (int y = 0; y < GameObjectArray3D.GetLength(1); y++)
            {
                for (int z = 0; z < GameObjectArray3D.GetLength(2); z++)
                {
                    //Cubes are placed to create a grid to work on
                    GameObjectArray3D[x, y, z] = GameObject.CreatePrimitive(PrimitiveType.Cube);

                    //Sets the positon of the new object to the x,y,z of the current array index
                    GameObjectArray3D[x, y, z].transform.position = new Vector3(x, y, z);
                }
            }
        }
    }

    public GameObject PrefabToPlace;
    public void Update()
    {
        PrefabToPlace = button.GetComponent<itemSelect>().selectedPiece;

        //Creates PrefabToPlace at the position of the object hit by a raycast
        if (Input.GetMouseButton(0))
        {
            RaycastHit RChit;
            if (Physics.Raycast(new Ray(Camera.main.transform.position, Camera.main.transform.forward), out RChit, Mathf.Infinity))//Raycasts out of the camera, you might want to use the mouse etc
            {
                GameObject.Instantiate(PrefabToPlace, RChit.collider.transform.position, Quaternion.identity);
            }
        }
    }
}
