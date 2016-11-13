using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
    public int slotsX, slotsY;
    public List<Item> slots = new List<Item>();
    public GUISkin skin;
    public List<Item> inventory = new List<Item>();
    private bool ShowInventory;
    private ItemData database;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < (slotsX * slotsY); i++)
        {
            slots.Add(new Item());
        }
        database = GameObject.FindGameObjectWithTag("Item Data").GetComponent<ItemData>();
        inventory.Add(database.items[0]);
        inventory.Add(database.items[1]);
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
        GUI.skin = skin;
        if (ShowInventory)
        {
            DrawInventory();
        }

	}
        void DrawInventory()
    {
        for (int x = 0; x < slotsX; x++)
        {
            for (int y = 0; y < slotsY; y++)
            {
                GUI.Box(new Rect(x * 80, y * 80, 80, 80), y.ToString(), skin.GetStyle("Empty Slot"));
            }
        }
    }
}
