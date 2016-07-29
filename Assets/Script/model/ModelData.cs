using UnityEngine;
using System.Collections;
using System.Xml;// 追加で記述
public class ModelData {
    private Texture2D _texture;
    //
    private string _image;
    private string _cardName;

    public Texture2D Texture
    {
        get
        {
            return _texture;
        }

        set
        {
            _texture = value;
        }
    }

    public string CardName
    {
        get
        {
            return _cardName;
        }

        set
        {
            _cardName = value;
        }
    }

    public string Image
    {
        get
        {
            return _image;
        }

        set
        {
            _image = value;
        }
    }

    // Use this for initialization
    public void setData()
    {

    }

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
