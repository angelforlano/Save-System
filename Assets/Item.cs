﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Items/New Item", order = 1)]
public class Item : ScriptableObject
{
    public string itemName;
    public string itemDesc;
    public int price = 25;
    public GameObject model;
    public Sprite itemIcon;
}