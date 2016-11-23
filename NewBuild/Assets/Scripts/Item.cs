using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item : MonoBehaviour
{
    public enum ItemType
    {
        QuestItem,
        Powerup
    }

    public string itemName;
    public int itemID;
    public string itemDesc;
    public Sprite itemIcon;
    public ItemType itemType;
    public Inventory Inv;


    void Start()
    {
        itemIcon = GetComponent<SpriteRenderer>().sprite;
    }

    void OnMouseUpAsButton()
    {
        Inv.AddItem(this);
        gameObject.SetActive(false);
    }
}
 