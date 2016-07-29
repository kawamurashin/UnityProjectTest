using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject gameObject = Instantiate(Resources.Load("prefab/controller/ControllerManager")) as GameObject;
        ControllerManager controllerManager = gameObject.GetComponent<ControllerManager>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
