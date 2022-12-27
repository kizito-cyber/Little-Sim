using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
{

    [System.Serializable] class ShopItem
    {
        public Sprite image;
        public int price;
        public bool isPurchased;
    }

    [SerializeField] List<ShopItem> shopItemsList;
    GameObject itemTemplate;
    GameObject g;
    [SerializeField] Transform shopScrollView;
    Button buyBtn;
    // Start is called before the first frame update
    void Start()
    {
        itemTemplate = shopScrollView.GetChild(0).gameObject;
        int shopCount = shopItemsList.Count;
        for(int i=0;i<shopCount;i++)
        {
            g = Instantiate(itemTemplate, shopScrollView);
            g.transform.GetChild(0).GetComponent<Image>().sprite = shopItemsList[i].image;
            g.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = shopItemsList[i].price.ToString();
            buyBtn = g.transform.GetChild(2).GetComponent<Button>();
            buyBtn.interactable =!shopItemsList[i].isPurchased;
            buyBtn.AddEventListener(i, OnShopItemBtnClicked);
        }
        Destroy(itemTemplate);
    }

    void OnShopItemBtnClicked(int itemIndex)
    {
        shopItemsList[itemIndex].isPurchased = true;

        buyBtn = shopScrollView.GetChild(itemIndex).GetChild(2).GetComponent<Button>();
        buyBtn.interactable = false;
        buyBtn.transform.GetChild(0).GetComponent<Text>().text = "PURCHASED";
    }

   
}
