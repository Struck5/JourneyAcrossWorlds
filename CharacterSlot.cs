using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharacterSlot : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public int index;
    private Item item;
    private Inventory inventory;
    private Player player;


    public void Awake()
    {
        item = new Item("Empty", "", "", "", "", 1000, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, Item.ItemType.Empty, "", "");
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }


    public void Update()
    {
        if (item.item_Type != Item.ItemType.Empty)
        {
            transform.GetChild(0).GetComponent<Image>().enabled = true;
            transform.GetChild(0).GetComponent<Image>().sprite = item.itemIcon;
        }
        else
        {
            transform.GetChild(0).GetComponent<Image>().enabled = false;
        }


        if (item.item_Type == Item.ItemType.Liquid)
        {
            player.SpeedMultiplier = item.currentWearValue;
        }
        if (item.item_Type == Item.ItemType.Light && player.MaxHealthModified != player.MaxHealth + item.currentWearValue)
        {
            player.AddMaxHealth(item.currentWearValue);
        }
        if (item.item_Type == Item.ItemType.Nature)
        {
            // AddItemSlots (auf mehrere Seiten auslagern, scrollbar)
        }
        if (item.item_Type == Item.ItemType.Shadow)
        {
            // AddDamage
        }
        if (item.item_Type == Item.ItemType.Elemental)
        {
            // IncreaseDropChance
        }
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (inventory.draggingItem)
        {
            if (index == 0 && inventory.draggedItem.item_Type == Item.ItemType.Light)
            {
                if (item.item_Type != Item.ItemType.Empty)
                {
                    Item temp = item;
                    item = inventory.draggedItem;
                    inventory.draggedItem = temp;
                    inventory.showDraggedItem(temp, -1);
                }
                else
                {
                    item = inventory.draggedItem;
                    inventory.closeDraggeditem();
                }
            }
            if (index == 1 && inventory.draggedItem.item_Type == Item.ItemType.Shadow)
            {
                if (item.item_Type != Item.ItemType.Empty)
                {
                    Item temp = item;
                    item = inventory.draggedItem;
                    inventory.draggedItem = temp;
                    inventory.showDraggedItem(temp, -1);
                }
                else
                {
                    item = inventory.draggedItem;
                    inventory.closeDraggeditem();
                }
            }
            if (index == 2 && inventory.draggedItem.item_Type == Item.ItemType.Nature)
            {
                if (item.item_Type != Item.ItemType.Empty)
                {
                    Item temp = item;
                    item = inventory.draggedItem;
                    inventory.draggedItem = temp;
                    inventory.showDraggedItem(temp, -1);
                }
                else
                {
                    item = inventory.draggedItem;
                    inventory.closeDraggeditem();
                }
            }
            if (index == 3 && inventory.draggedItem.item_Type == Item.ItemType.Liquid)
            {
                if (item.item_Type != Item.ItemType.Empty)
                {
                    Item temp = item;
                    item = inventory.draggedItem;
                    inventory.draggedItem = temp;
                    inventory.showDraggedItem(temp, -1);
                }
                else
                {
                    item = inventory.draggedItem;
                    inventory.closeDraggeditem();
                }
            }
            if (index == 4 && inventory.draggedItem.item_Type == Item.ItemType.Elemental)
            {
                if (item.item_Type != Item.ItemType.Empty)
                {
                    Item temp = item;
                    item = inventory.draggedItem;
                    inventory.draggedItem = temp;
                    inventory.showDraggedItem(temp, -1);
                }
                else
                {
                    item = inventory.draggedItem;
                    inventory.closeDraggeditem();
                }
            }
        }
    }

    public void OnDrag(PointerEventData data)
    {
        if (item.item_Type != Item.ItemType.Empty)
        {
            inventory.draggedItem = item;
            inventory.showDraggedItem(item, -1);
            item = new Item("Empty", "", "", "", "", 1000, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, Item.ItemType.Empty, "", "");
        }
    }
}
