using UnityEngine;
using System.Collections;
using System.Xml;// 追加で記述
using UnityEngine.UI;
public class ControllerManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("start controller");
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
        ModelManager modelManager = ModelManager.Instance;
        Debug.Log("complete :");
        //Debug.Log(modelManager.texture);

        GameObject gameObject = Instantiate(Resources.Load("prefab/view/ViewManager")) as GameObject;
        ViewManager controllerManager = gameObject.GetComponent<ViewManager>();


        //XmlNode all = document.FirstChild.FirstChild;    //最初のノード　'FelicaData'タグ
        /*
        Debug.Log("FirstChild " + all.InnerText);   //子ノードをふくむ、すべてのタグのテキストが表示される
                                                    //
        XmlNodeList header = all.FirstChild.ChildNodes; //最初のノード＝'Header'タグの、子ノードのリスト
        foreach (XmlNode node in header)
        {
            Debug.Log(node.Name + ", " + node.InnerText);   //タグ名と、テキストを表示
        }
        //
        XmlNodeList models = document.GetElementsByTagName("Model");  //'Model'タグのリストを作る
        foreach (XmlNode model in models)
        {
            Debug.Log(model.Attributes["id"].Value + ", " + model.InnerText);   //属性'id'と、テキストを表示
        }
        //
        XmlNode actionsNode = document.GetElementsByTagName("Actions")[0];
        XmlNodeList actions = actionsNode.ChildNodes;
        foreach (XmlNode action in actions)
        {
            Debug.Log(action.Attributes["id"].Value + ", " + action.InnerText); //属性'id'と、テキストを表示
        }
        */

    }
}
