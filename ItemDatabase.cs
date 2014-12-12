using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    void Start()
    {
        items.Add(new Item("Empty", "", "", "", "", 1000, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, Item.ItemType.Empty, "", ""));
        items.Add(new Item("crystal_light_1", "crystal_light_2", "crystal_light_3", "crystal_light_4", "crystal_light_5", 11, 1, 10, 20, 45, 100, 200, 2, 3, 4, 5, 10, 30, 55, 100, 1000, 1000, 5, 5, 10, 0, 0, 1, Item.ItemType.Light, "Light ", "Description"));
        items.Add(new Item("crystal_jungle_1", "crystal_jungle_2", "crystal_jungle_3", "crystal_jungle_4", "crystal_jungle_5", 21, 1, 5, 10, 20, 40, 85, 1, 1, 2, 2, 3, 5, 10, 30, 60, 60, 1, 2, 3, 0, 0, 1, Item.ItemType.Nature, "Nature ", "Description"));
        items.Add(new Item("crystal_shadow_1", "crystal_shadow_2", "crystal_shadow_3", "crystal_shadow_4", "crystal_shadow_5", 31, 1, 2, 12, 30, 50, 100, 2, 2, 2, 2, 2, 2, 12, 30, 50, 50, 2, 2, 2, 0, 0, 1, Item.ItemType.Shadow, "Shadow ", "Description"));
        items.Add(new Item("crystal_water_1", "crystal_water_2", "crystal_water_3", "crystal_water_4", "crystal_water_5", 41, 1, 5, 10, 20, 30, 50, 1, 1, 1, 1, 2, 5, 10, 20, 30, 30, 1, 1, 1, 0, 0, 1, Item.ItemType.Liquid, "Liquid", "Description"));
        items.Add(new Item("crystal_elemental_1", "crystal_elemental_2", "crystal_elemental_3", "crystal_elemental_4", "crystal_elemental_5", 51, 1, 10, 40, 100, 150, 350, 5, 5, 5, 10, 10, 1, 10, 25, 50, 50, 1, 1, 1, 0, 0, 1, Item.ItemType.Elemental, "Elemental ", "Description"));
    }
}