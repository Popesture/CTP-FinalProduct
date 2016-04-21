using UnityEngine;
using System.Collections;

public class menuCon : MonoBehaviour {

    public void ChangeScene(string a)
    {
        Application.LoadLevel(a); //loads a different scene
    }
}
