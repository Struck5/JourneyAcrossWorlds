using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<GameObject> Slots = new List<GameObject>();
    public List<Item> Items = new List<Item>(); 
    public GameObject slots;
    private ItemDatabase database;
    private float x = 3;
    private float y;

    public GameObject tooltip;
    public GameObject draggedItemGameObject;
    public bool draggingItem = false;
    public Item draggedItem;
    public int indexOfDraggedItem;

    public void showTooltip(Vector3 toolPosition, Item item)
    {
        tooltip.SetActive(true);
        tooltip.GetComponent<RectTransform>().localPosition = new Vector3(toolPosition.x + 600f ,toolPosition.y + 480f, toolPosition.z);

        tooltip.transform.GetChild(0).GetComponent<Text>().text = item.item_DisplayName + item.item_level;
        tooltip.transform.GetChild(2).GetComponent<Text>().text = item.item_Description;
    }

    public void showDraggedItem(Item item, int slotNumber)
    {
        indexOfDraggedItem = slotNumber;
        draggedItemGameObject.SetActive(true);
        draggedItem = item;
        draggingItem = true;
        draggedItemGameObject.GetComponent<Image>().sprite = item.itemIcon;
        closeTooltip();
    }

    public void closeDraggeditem()
    {
        draggingItem = false;
        draggedItemGameObject.SetActive(false);
    }

    public void closeTooltip()
    {
        tooltip.SetActive(false);
    }

	void Start ()
	{
	    int SlotAmount = 0;


	    database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();

	    for (int i = 1; i < 6; i++)
	    {
	        for (int k = 1; k < 6; k++)
	        {
	            GameObject slot = (GameObject) Instantiate(slots);
	            slot.GetComponent<SlotScript>().slotNumber = SlotAmount;
                Slots.Add(slot);
                Items.Add(new Item());
	            slot.transform.SetParent(this.gameObject.transform);
	            slot.name = "slot" + i + "." + k;
                slot.GetComponent<RectTransform>().localPosition = new Vector3(x, y, 0);
	            x += + 76;
	            if (k == 5)
	            {
	                x = 3;
	                y -= 76;
	            }
	            SlotAmount++;
	        }
	    }
        addItem(11);
        addItem(11);
        addItem(11);
        addItem(21);
        addItem(31);
	    addItem(41);
        addItem(41);
        addItem(41);
        addItem(41);
        addItem(51);
	}

    void Update()
    {
        if (draggingItem)
        {
            Vector3 posi = (Input.mousePosition - GameObject.FindGameObjectWithTag("Canvas_Inventory").GetComponent<RectTransform>().localPosition);
            draggedItemGameObject.GetComponent<RectTransform>().localPosition = new Vector3(posi.x -50, posi.y -50, posi.z);
        }
    }
	
	void addItem (int id) 
    {
	    for (int i = 0; i < database.items.Count; i++)
	    {
	        if (database.items[i].itemID == id)
	        {
                Item item = new Item(database.items[i]); 
                addItemAtEmptySlot(item);
	            break;
	        }
	    }
	}

    void addItemAtEmptySlot(Item item)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].item_Name1 == null)
            {
                Items[i] = item;
                break;
            }
        }
    }

    public void addItemSlots(int value)
    {
        // seite 2
    }
}
