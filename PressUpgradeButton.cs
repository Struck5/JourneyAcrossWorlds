using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PressUpgradeButton : MonoBehaviour, IPointerDownHandler
{
    private CraftingScript _crafting;
    private GameObject _crystal;


    private void Awake()
    {
        _crafting = GameObject.FindGameObjectWithTag("Crafting").GetComponent<CraftingScript>();
        _crystal = GameObject.Find("Crystal_Slot");
    }


    public void OnPointerDown(PointerEventData data)
    {
        if (_crystal.GetComponent<Image>().sprite.name != "Empty")      // wieso auch immer GetComponentInChilden nicht funktioniert hat
        {
            var name = _crystal.GetComponent<Image>().sprite.name;
            _crafting.UpgradeCrystal(name);
        }
    }
}
