using UnityEngine;
using System.Collections;

public class CardBackground : MonoBehaviour {
    public bool isMouseDown = false;
    public delegate void CallBack();
    private CallBack mouseUpCallBack;
    GameObject parentGameObject;
    Vector3 offset;

    public void addMouseUpCallBack(CallBack callback)
    {
        mouseUpCallBack += callback;
    }

    void OnMouseDown()
    {
        isMouseDown = true;
        offset = parentGameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        offset.z = 0;

        Vector3 vector = parentGameObject.transform.position;
        vector.z = -1;
        parentGameObject.transform.position = vector;
    }
    void OnMouseDrag()
    {
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Vector3 vector = Camera.main.ScreenToWorldPoint(currentScreenPoint);
        parentGameObject.transform.position = new Vector3(vector.x, vector.y, -1) + offset;
    }
    void OnMouseUp()
    {
        isMouseDown = false;
        mouseUpCallBack();
    }
    // Use this for initialization
    void Start()
    {
        parentGameObject = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
