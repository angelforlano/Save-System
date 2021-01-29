using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public GameObject storeButtonPrefab;
    public Transform canvasStoreTransform;

    void Start()
    {
        Object[] items = Resources.LoadAll("", typeof(Item));

        for (int i = 0; i < items.Length; i++)
        {
            var item = items[i] as Item;
            var storeButton = Instantiate(storeButtonPrefab, canvasStoreTransform);

            storeButton.transform.GetChild(0).GetComponent<Text>().text = item.itemName;
            storeButton.transform.GetChild(1).GetComponent<Image>().sprite = item.itemIcon;
            storeButton.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = item.price + "$";
        }
    }
}