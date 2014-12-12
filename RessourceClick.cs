using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RessourceClick : MonoBehaviour, IPointerDownHandler
{
    public GameObject RessourceGameObject;
    private EnterCraftingZone _enterCraftingZone;
    private GameHud _manager;
    private CraftingScript _crafting;

    public void Awake()
    {
        _enterCraftingZone = GameObject.FindGameObjectWithTag("Blacksmith").GetComponent<EnterCraftingZone>();
        _manager = GameObject.Find("Managers").GetComponent<GameHud>();
        _crafting = GameObject.FindGameObjectWithTag("Crafting").GetComponent<CraftingScript>();
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (data.button == PointerEventData.InputButton.Right)
        {
            if (_enterCraftingZone.CraftingOpen)
            {
                if (gameObject.name == "Ressource_Wood" && _manager.wood > 0 && _crafting.simpleRessource < 7)
                {
                    _manager.wood -= 1;
                    _crafting.simpleRessource += 1;
                    _crafting.AddRessourceAtEmptySlot(RessourceGameObject);
                }

                if (gameObject.name == "Ressource_Stone" && _manager.stone > 0 && _crafting.simpleRessource < 7)
                {
                    _manager.stone -= 1;
                    _crafting.simpleRessource += 1;
                    _crafting.AddRessourceAtEmptySlot(RessourceGameObject);
                }
            }
        }
    }
}
