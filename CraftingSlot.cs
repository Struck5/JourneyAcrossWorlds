using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CraftingSlot : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public Item item;
    private Inventory inventory;
    private GameObject _emptySprite;

    public void Awake()
    {
        _emptySprite = GameObject.Find("EmptySprite");
        item = new Item("Empty", "", "", "", "", 1000, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, Item.ItemType.Empty, "", "");
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
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
            transform.GetChild(0).GetComponent<Image>().sprite = _emptySprite.GetComponent<Image>().sprite;
        }
    }


    public void OnPointerDown(PointerEventData data)
    {
        if (inventory.draggingItem)
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
