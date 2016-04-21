using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ScrollableList : MonoBehaviour
{
    public GameObject itemPrefab;
    public int itemCount = 10, columnCount = 1;
    public Scrollbar bar;

    string[] itemNames = new string[13];
    public Sprite[] itemImages = new Sprite[13];
    public Text textRef;
    public Image imageRef;

    public GameObject[] piecePrefab = new GameObject[13];
    public Selectable button;


    void Start()
    {
        #region Array Container
        itemNames[0] = "Corner";
        itemNames[1] = "Cross-T-Section";
        itemNames[2] = "Cross-X-Section";
        itemNames[3] = "30 Meter-Straight";
        itemNames[4] = "40 Meter-Straight";
        itemNames[5] = "50 Meter-Straight";
        itemNames[6] = "60 Meter-Straight";
        itemNames[7] = "70 Meter-Straight";
        itemNames[8] = "80 Meter-Straight";
        itemNames[9] = "90 Meter-Straight";
        itemNames[10] = "Pedestrian";
        itemNames[11] = "Car";
        itemNames[12] = "Car";
        
        #endregion

        RectTransform rowRectTransform = itemPrefab.GetComponent<RectTransform>();
        RectTransform containerRectTransform = gameObject.GetComponent<RectTransform>();

        //calculate the width/height of each child item
        float width = containerRectTransform.rect.width / columnCount;
        float ratio = width / rowRectTransform.rect.width;
        float height = rowRectTransform.rect.height * ratio;
        int rowCount = itemCount / columnCount;
        if (itemCount % rowCount > 0)
            rowCount++;

        //adjust the height of the container so that it will fit all its children
        float scrollHeight = height * rowCount;
        containerRectTransform.offsetMin = new Vector2(containerRectTransform.offsetMin.x, -scrollHeight / 2);
        containerRectTransform.offsetMax = new Vector2(containerRectTransform.offsetMax.x, scrollHeight / 2);

        int j = 0;
        for (int i = 0; i < itemCount; i++)
        {
            if (i % columnCount == 0)
                j++;
            
            //create a new item, name it, and set the parent
            GameObject newItem = Instantiate(itemPrefab) as GameObject;
            newItem.name = gameObject.name + " item at (" + i + "," + j + ")";
            newItem.transform.SetParent(gameObject.transform);

            //set its text and image            
            textRef.text = itemNames[i];  
            imageRef.sprite = itemImages[i];

            //set its button information
            button.GetComponent<itemSelect>().selectedPiece = piecePrefab[i];
                     

            //move and size the new item
            RectTransform rectTransform = newItem.GetComponent<RectTransform>();

            float x = -containerRectTransform.rect.width / 2 + width * (i % columnCount);
            float y = containerRectTransform.rect.height / 2 - height * j;
            rectTransform.offsetMin = new Vector2(x, y);

            x = rectTransform.offsetMin.x + width;
            y = rectTransform.offsetMin.y + height;
            rectTransform.offsetMax = new Vector2(x, y);
        }

        //set scroll bar to the top
        bar.value = 0.9f;
    }

    public void Update()
    {
        if (bar.value > 0.9f)
        {
            bar.value = 0.9f;
        }


    }
}
