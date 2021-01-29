using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public int gold;
    public int gems;

    public GameObject storeButtonPrefab;
    public Transform canvasStoreTransform;

    void Start()
    {
        var gameData = SaveSystem.Instance.GetGameData();
        
        gold = gameData.gold;
        gems = gameData.gems;

        Object[] items = Resources.LoadAll("", typeof(Item));

        for (int i = 0; i < items.Length; i++)
        {
            var item = items[i] as Item;
            var storeButton = Instantiate(storeButtonPrefab, canvasStoreTransform);

            storeButton.transform.GetChild(0).GetComponent<Text>().text = item.itemName;
            storeButton.transform.GetChild(1).GetComponent<Image>().sprite = item.itemIcon;
            storeButton.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = item.price + "$";
            storeButton.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() => BuyItem(item.price));
        }
    }

    public void BuyItem(int price)
    {
        Debug.Log(price);

        if (gold >= price)
        {
            gold -= price;

            SaveSystem.Instance.gameData.gold = gold;
            SaveSystem.Instance.gameData.gems = gems;

            // ADD Item...
        } else {
            Debug.Log("Not Gold");
        }
    }
}