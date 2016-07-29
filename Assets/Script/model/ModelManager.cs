using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;// 追加で記述
using System.Xml;// 追加で記述
using UnityEngine.UI;
public class ModelManager : MonoBehaviour {
    public delegate void CallBack();
    private CallBack dataComplete;
    //
    
    private List<ModelData> list;
    int imageCount;
    int imageTotal;
    public void addDataComplete(CallBack callback)
    {
        dataComplete += callback;
    }
    private static ModelManager instace;
    private ModelManager()
    {

    }
    public static ModelManager Instance
    {
        get
        {
            if(instace == null)
            {
                GameObject gameObject = new GameObject("ModelManager");
                instace = gameObject.AddComponent<ModelManager>();
            }
            return instace;
        }
    }

    public List<ModelData> List
    {
        get
        {
            return list;
        }
    }

    //
    public void loadDataStart()
    {
        
        StartCoroutine(loadData());
    }
    IEnumerator loadData()
    {
        string path = "file://" + Application.dataPath + "/Data/xml/data.xml";
        WWW www = new WWW(path);
        yield return www;

        if (www.error == null)
        {
            // request completed!
            list = new List<ModelData>();
            ModelData modelData;
            XmlNode textNode;
            string cardName;
            string image;
            XmlNode node;

            string text = www.text;
            XmlDocument document = new XmlDocument();
            document.LoadXml(text);
            //
            XmlNodeList nodelist = document.SelectNodes("data/cards/card");
            for (int i = 0; i < nodelist.Count; i++)
            {
                node = nodelist[i];
                textNode = (XmlNode)(node.SelectNodes("text")[0]);
                cardName = textNode.InnerText;
                textNode = (XmlNode)(node.SelectNodes("image")[0]);
                image = textNode.InnerText;
                //
                modelData = new ModelData();
                modelData.CardName = cardName;
                modelData.Image = image;

                list.Add(modelData);
            }
            loadImageStart();
        }
        else
        {
            // something wrong!
            Debug.Log("WWW Error: " + www.error);
        }
    }
    private void loadImageStart()
    {
        imageCount = 0;
        imageTotal = list.Count;
        for(int i=0; i < imageTotal; i++)
        {
            ModelData modelData = list[i];
            StartCoroutine(loadImage(modelData));
        }
    }

    IEnumerator loadImage(ModelData modelData)
    {
        string path = "file://" + Application.dataPath + "/" +  modelData.Image;
        WWW www = new WWW(path);

        // 画像ダウンロード完了を待機
        yield return www;
        if (www.error == null)
        {
            Texture2D texture = www.texture;
            modelData.Texture = texture;

            complete();
        }
        else
        {
            Debug.Log("WWW Image Error: " + www.error);
        }
    }
    void complete()
    {
        imageCount++;
        if(imageCount == imageTotal)
        {
            dataComplete();
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
