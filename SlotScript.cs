using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class SlotScript : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler
{
    public Item item = new Item("Empty", "", "", "", "", 1000, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, Item.ItemType.Empty, "", "");
    private Image itemImage;
    public int slotNumber;
    private Inventory inventory;
    private Player player;

    private Text itemLevel;

    // Use this for initialization
    public void Start()
    {
        itemLevel = gameObject.transform.GetChild(1).GetComponent<Text>();
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        itemImage = gameObject.transform.GetChild(0).GetComponent<Image>();
        for(int i=0; i<25; i++)
            inventory.Items[i].AssignTo();
    }

    // Update is called once per frame
    public void Update()
    {
        if (inventory.Items[slotNumber].item_Name1 != null)
        {
            itemImage.enabled = true;
            itemImage.sprite = inventory.Items[slotNumber].itemIcon;

            if (true)
            {
                itemLevel.enabled = true;
                itemLevel.text = "" + inventory.Items[slotNumber].currentLevelstage;
            }
        }
        else
        {
            itemImage.enabled = false;
        }

    }

    public void OnPointerDown(PointerEventData data)
    {
        if (data.button == PointerEventData.InputButton.Right)
        {
            inventory.Items[slotNumber] = new Item();
            itemLevel.enabled = false;
            inventory.closeTooltip();
            if (item.item_Type == Item.ItemType.Light)
            {
                player.Health += item.currentUseValue;
            }
            if (item.item_Type == Item.ItemType.Nature)
            {
                // Senkt die Respawnzeit von Ressourcen
            }
            if (item.item_Type == Item.ItemType.Shadow)
            {
                // Multipliziert den Schaden (temporär)
            }
            if (item.item_Type == Item.ItemType.Liquid)
            {
                // Höher springen (temporär)
            }
            if (item.item_Type == Item.ItemType.Elemental)
            {
                // Erzeugt Fähigkeitspunkte 
            }
        }

        if (data.button == PointerEventData.InputButton.Middle)
        {
            if (inventory.Items[slotNumber].currentLevelstage == 5)
                inventory.Items[slotNumber].UpgradeCrystalLevel();
            else
                inventory.Items[slotNumber].AddLevelstage();
        }

        if (data.button == PointerEventData.InputButton.Middle)
        {

        }

        if (inventory.Items[slotNumber].item_Name1 == null && inventory.draggingItem)
        {
            inventory.Items[slotNumber] = inventory.draggedItem;
            inventory.closeDraggeditem();
        }
        else
        {
            try
            {
                if (inventory.draggingItem && inventory.Items[slotNumber].item_Name1 != null)
                {
                    inventory.Items[inventory.indexOfDraggedItem] = inventory.Items[slotNumber];
                    inventory.Items[slotNumber] = inventory.draggedItem;
                    inventory.closeDraggeditem();
                }
            }
            catch
            {

            }

        }
    }

    public void OnPointerEnter(PointerEventData data)
    {
        if (inventory.Items[slotNumber].item_Name1 != null && !inventory.draggingItem)
        {
            inventory.showTooltip(inventory.Slots[slotNumber].GetComponent<RectTransform>().localPosition,
                inventory.Items[slotNumber]);
        }
    }

    public void OnPointerExit(PointerEventData data)
    {
        if (inventory.Items[slotNumber].item_Name1 != null)
        {
            inventory.closeTooltip();
        }
    }

    public void OnDrag(PointerEventData data)
    {
        if (!inventory.draggingItem)
        {
            if (inventory.Items[slotNumber].item_Name1 != null)
            {
                inventory.showDraggedItem(inventory.Items[slotNumber], slotNumber);
                inventory.Items[slotNumber] = new Item();

                itemLevel.enabled = false;
            }
        }
    }
}
