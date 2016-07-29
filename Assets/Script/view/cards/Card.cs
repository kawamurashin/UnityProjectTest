using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Card : MonoBehaviour {
    public delegate void CallBack(Card card);
    private CallBack mouseUpCallBack;
    //
    CardBackground cardBackground;
    public void setModelData(ModelData modelData)
    {
        Texture2D texture = modelData.Texture;
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0));
        Transform transform = this.transform.FindChild("New Sprite");
        SpriteRenderer spriteRenderer = (SpriteRenderer)transform.GetComponent("SpriteRenderer");
        spriteRenderer.sprite = sprite;

        Debug.Log(modelData.CardName);

        Transform child = this.transform.FindChild("New Text");
        TextMesh textMesh = (TextMesh)child.GetComponent(typeof(TextMesh));
        textMesh.text = modelData.CardName;

    }
    public void addMouseUpCallBack(CallBack callback)
    {
        mouseUpCallBack += callback;
    }
    public void mouseUpHanlder()
    {
        mouseUpCallBack(this);
    }
	// Use this for initialization
	void Start () {

        Transform transform = this.transform.FindChild("CardBackground");
        cardBackground = (CardBackground)transform.GetComponent("CardBackground");
        cardBackground.addMouseUpCallBack(mouseUpHanlder);
	
	}
	
	// Update is called once per frame
	void Update () {
        if(cardBackground.isMouseDown == false)
        {
            Vector3 vector = this.transform.position;
            vector.x += 0.1f - 0.2f * Random.value;
            vector.y += 0.1f - 0.2f * Random.value;
            this.transform.position = vector;
        }

    }

}
