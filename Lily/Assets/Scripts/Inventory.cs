using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
    public int slotsX, slotsY; // The number of slots on each axis
    public List<Item> slots = new List<Item>();
    public GUISkin skin;
    public List<Item> inventory = new List<Item>();
    private bool ShowInventory;
    private ItemData database;
    private bool showToolTip;
    private string ToolTip;
    private bool ItemDrag;
    private Item ItemDragged;
    private int DragIndex;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < (slotsX * slotsY); i++)
        {
            slots.Add(new Item());
            inventory.Add(new Item());
        }
        database = GameObject.FindGameObjectWithTag("Item Data").GetComponent<ItemData>();
        AddItem(0);
        AddItem(1);

    }
	void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            ShowInventory = !ShowInventory;
        }
    }
	// Update is called once per frame
	void OnGUI ()
    {
        if (GUI.Button(new Rect(550, 40, 100, 40), "Save")) //Save button
            SaveInventory();
        if (GUI.Button(new Rect(550, 90, 100, 40), "Load")) //Load button
            LoadInventory();
        ToolTip = "";
        GUI.skin = skin;
        if (ShowInventory)
        {
            DrawInventory();
        if (showToolTip)
            GUI.Box(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 140, 140), ToolTip); //Item description box
        }
            if (ItemDrag)
        {
            GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 40, 40), ItemDragged.itemIcon);
        }
	}
        void DrawInventory()
    {
        Event e = Event.current; // Allows us to simply type "e" instead of event.current all the time.

        int i = 0; // each time draw inventory is called, it will reset to 0.
        for (int y = 0; y < slotsY; y++)
        {                                                           // Changing the Y coordinate to be at top allows the items to be shown going right rather than down
            for (int x = 0; x < slotsX; x++)            
            {
                Rect slotRect = new Rect(x * 100,y * 100, 80, 80);
                GUI.Box(slotRect, "", skin.GetStyle("Empty Slot"));
                slots[i] = inventory[i];

                if (slots[i].itemName != null)
                {
                    GUI.DrawTexture(slotRect, inventory[i].itemIcon); //Draws texture within rectangle
                    if(slotRect.Contains(e.mousePosition))
                    {
                       ToolTip = CreateToolTip(slots[i]);
                        showToolTip = true;
                        if (e.button == 0 && e.type == EventType.mouseDrag && !ItemDrag)
                        {
                            ItemDrag = true;
                            DragIndex = i;
                            ItemDragged = slots[i];
                            inventory[i] = new Item();
                        }
                        if (e.type == EventType.mouseUp && ItemDrag)
                        {
                            inventory[DragIndex] = inventory[i];
                            inventory[i] = ItemDragged;
                            ItemDrag = false;
                            ItemDragged = null;
                        }
                    }
                }       else
                {
                    if(slotRect.Contains(e.mousePosition))
                    {
                        if(e.type == EventType.mouseUp && ItemDrag)
                        {
                            inventory[i] = ItemDragged;
                            ItemDrag = false;
                            ItemDragged = null;
                        }
                    }
                }
                if (ToolTip == "")     // Doesn't show item box if an item is not hovered on top of.
                {
                    showToolTip = false;
                }
                i++;
            }
        }
    }
    string CreateToolTip(Item item)
    {
        ToolTip = "<color=#f7fffc>" + item.itemName + "</color>\n" + item.itemDesc; // \n is used to create a line down so that item description can be placed below
        return ToolTip;                       // Place a color number before the words you want colored.
    }


             void ItemRemove(int id) //Removes item with the specific ID. Does not remove all items with the same ID.(Hence use of break)
      {
        for (int i = 0; i < inventory.Count; i++)
            if (inventory [i]. itemID == id)
            {
                inventory[i] = new Item();
                break;
            }
    }

        void AddItem(int id)  //Focusing on the item ID being used
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemName == null)
            {
                for (int j = 0; j < database.items.Count; j++)
                    {
                        if (database.items[j].itemID == id)
                    {
                        inventory[i] = database.items[j];
                    }
                    }
                break;
            }
        }
    }
        bool InventoryContains(int id)
    {
        bool result = false;
        for(int i = 0; i < inventory.Count; i++)
        {
            result = inventory[i].itemID == id; //One = is setting the value, two == is checking a condition (boolean)
            if (result)
            {
                break;
            }
        }
        return result;
    }
    void SaveInventory()
    {
        for (int i = 0; i < inventory.Count; i++)
            PlayerPrefs.SetInt("Inventory" + i, inventory[i].itemID); // Saves the current state of where the items were left.
    }
    void LoadInventory()
    {
        for (int i = 0; i < inventory.Count; i++)
            inventory[i] = PlayerPrefs.GetInt("Inventory" + i, -1) >= 0 ? database.items[PlayerPrefs.GetInt("Inventory" + i)]: new Item(); //Loads previous position of objects.
    }
}
