using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Inventory : MonoBehaviour {

    public const int InventorySize = 6;

    public Item[] List = new Item[InventorySize];
    public Image[] InvSlots;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < InvSlots.Length; i++)
        {
            InvSlots[i].enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool AddItem(Item newItem)
    {
        // loop through the array to find an empty inventory slot
        int listIndex = -1;
        for (int i = 0; i < InventorySize; i++)
        {
            // find the first entry that has nothing in it
            if (List[i] == null)
            {
                listIndex = i;
                break;
            }
        }

        // if listIndex is still -1, the inventory is full, so we can't add anything to it.
        if ( listIndex == -1)
            return false;

        List[listIndex] = newItem;
        InvSlots[listIndex].sprite = newItem.itemIcon;
        InvSlots[listIndex].enabled = true;

        return true;
    }

    public void RemoveItem(Item item)
    {

    }
}
