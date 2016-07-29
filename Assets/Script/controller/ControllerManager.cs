using UnityEngine;
using System.Collections;
using System.Xml;// 追加で記述
using UnityEngine.UI;
public class ControllerManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ModelManager modelManager = ModelManager.Instance;
        modelManager.addDataComplete(dataCompleteHandler);
        modelManager.loadDataStart();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    //
    void dataCompleteHandler()
    {
        GameObject gameObject = Instantiate(Resources.Load("prefab/view/ViewManager")) as GameObject;
        ViewManager controllerManager = gameObject.GetComponent<ViewManager>();
    }
}
