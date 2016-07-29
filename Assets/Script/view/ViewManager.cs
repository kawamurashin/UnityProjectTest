using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ViewManager : MonoBehaviour {
    private List<Card> cardList;
    // Use this for initialization
    void Start () {
        //

        GameObject gameObject;
        Card card;
        ModelData modelData;
        Debug.Log("view manager start");
        ModelManager modelManager = ModelManager.Instance;
        List<ModelData> list = modelManager.List;
        //
        Vector3 vector;
        Vector2 minStageSize = Camera.main.ViewportToWorldPoint(Vector2.zero);
        Vector2 maxStageSize = Camera.main.ViewportToWorldPoint(Vector2.one);
        float _width = maxStageSize.x - minStageSize.x;
        float _height = maxStageSize.y - minStageSize.y;

        cardList = new List<Card>();
        int n = list.Count;
        Debug.Log("n : " + n);
        for(int i = 0; i< n;i++)
        {
            modelData = list[i];
            gameObject = Instantiate(Resources.Load("prefab/view/Card")) as GameObject;
            card = gameObject.GetComponent<Card>();
            card.setModelData(modelData);
            card.addMouseUpCallBack(mouseUpHandler);
            vector = new Vector3();
            vector.x = minStageSize.x + _width * Random.value;
            vector.y = minStageSize.y + _height * Random.value;
            gameObject.transform.position = vector;
            //

            //
            cardList.Add(card);

        }
        sortCardList();

    }
	
	// Update is called once per frame
	void Update () {
	
	}
    //
    public void mouseUpHandler(Card targetCard)
    {
        int i;
        int n;
        Card card;
        //
        n = cardList.Count;
        for(i=0;i<n;i++)
        {
            card = cardList[i];
            if(card == targetCard)
            {
                cardList.Remove(targetCard);
                cardList.Add(targetCard);
                break;
            }
        }
        sortCardList();
    }
    private void sortCardList()
    {
        int i;
        int n;
        Vector3 vector;
        Card card;
        n = cardList.Count;
        for (i = 0; i < n; i++)
        {
            card = cardList[i];
            vector = card.transform.position;
            vector.z = 2.1f *n  - 2.1f * i;
            card.transform.position = vector;

        }
    }
}
