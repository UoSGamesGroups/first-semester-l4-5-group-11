using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemData : MonoBehaviour {
    public List<Item> items = new List<Item>();

    void Awake()
    {
        items.Add(new Item("Medicine",0,"Helps cure sickness", Item.ItemType.QuestItem));
        items.Add(new Item("Keys", 1, "Opens a locked door", Item.ItemType.QuestItem));
    }

}
