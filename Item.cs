using UnityEngine;

public class Item
{
    public string item_Name1;
    public string item_Name2;
    public string item_Name3;
    public string item_Name4;
    public string item_Name5;
    public int itemID;
    public int item_level;
    public int item_wear_base_1;
    public int item_wear_base_2;
    public int item_wear_base_3;
    public int item_wear_base_4;
    public int item_wear_base_5;
    public int item_wear_addEachLevel_1;
    public int item_wear_addEachLevel_2;
    public int item_wear_addEachLevel_3;
    public int item_wear_addEachLevel_4;
    public int item_wear_addEachLevel_5;
    public int item_use_base_1;
    public int item_use_base_2;
    public int item_use_base_3;
    public int item_use_base_4;
    public int item_use_base_5;
    public int item_use_addEachLevel_1;
    public int item_use_addEachLevel_2;
    public int item_use_addEachLevel_3;
    public int item_use_addEachLevel_4;
    public int item_use_addEachLevel_5;
    public int item_Value;
    public ItemType item_Type;
    public string item_DisplayName;
    public string item_Description;


    public Sprite itemIcon;
    public int currentLevelstage = 0;
    public int currentLevel;
    public int currentUseValue;
    public int currentWearValue;
    public int currentChanceValue;
    public float chanceToUpgrade;
    public int maxUpgrades_1 = 5;
    public int maxUpgrades_2 = 7;
    public int maxUpgrades_3 = 10;
    public int maxUpgrades_4 = 15;
    public int maxUpgrades_5 = 25;
    public int UseChanceBase4 = 0;
    public int UseChanceBase5 = 40;



    public enum ItemType
    {
        Light,
        Nature,
        Shadow,
        Liquid,
        Elemental,
        Consumable,
        Ressource,
        Empty,
        Quest
    }

    public Item(string itemName1, string itemName2, string itemName3, string itemName4, string itemName5, int itemId, int itemLevel, int itemWearBase1, int itemWearBase2, int itemWearBase3, int itemWearBase4, int itemWearBase5, int itemWearAddEachLevel1, int itemWearAddEachLevel2, int itemWearAddEachLevel3, int itemWearAddEachLevel4, int itemWearAddEachLevel5, int itemUseBase1, int itemUseBase2, int itemUseBase3, int itemUseBase4, int itemUseBase5, int itemUseAddEachLevel1, int itemUseAddEachLevel2, int itemUseAddEachLevel3, int itemUseAddEachLevel4, int itemUseAddEachLevel5, int itemValue, ItemType itemType, string itemDisplayName, string itemDescription)
    {
        item_Name1 = itemName1;
        item_Name2 = itemName2;
        item_Name3 = itemName3;
        item_Name4 = itemName4;
        item_Name5 = itemName5;
        itemID = itemId;
        item_level = itemLevel;
        item_wear_base_1 = itemWearBase1;
        item_wear_base_2 = itemWearBase2;
        item_wear_base_3 = itemWearBase3;
        item_wear_base_4 = itemWearBase4;
        item_wear_base_5 = itemWearBase5;
        item_wear_addEachLevel_1 = itemWearAddEachLevel1;
        item_wear_addEachLevel_2 = itemWearAddEachLevel2;
        item_wear_addEachLevel_3 = itemWearAddEachLevel3;
        item_wear_addEachLevel_4 = itemWearAddEachLevel4;
        item_wear_addEachLevel_5 = itemWearAddEachLevel5;
        item_use_base_1 = itemUseBase1;
        item_use_base_2 = itemUseBase2;
        item_use_base_3 = itemUseBase3;
        item_use_base_4 = itemUseBase4;
        item_use_base_5 = itemUseBase5;
        item_use_addEachLevel_1 = itemUseAddEachLevel1;
        item_use_addEachLevel_2 = itemUseAddEachLevel2;
        item_use_addEachLevel_3 = itemUseAddEachLevel3;
        item_use_addEachLevel_4 = itemUseAddEachLevel4;
        item_use_addEachLevel_5 = itemUseAddEachLevel5;
        item_Value = itemValue;
        item_Type = itemType;
        item_DisplayName = itemDisplayName;
        item_Description = itemDescription;
        itemIcon = Resources.Load<Sprite>("" + itemName1);
    }

    public Item(Item other)
    {
        item_Name1 = other.item_Name1;
        item_Name2 = other.item_Name2;
        item_Name3 = other.item_Name3;
        item_Name4 = other.item_Name4;
        item_Name5 = other.item_Name5;
        itemID = other.itemID;
        item_level = other.item_level;
        item_wear_base_1 = other.item_wear_base_1;
        item_wear_base_2 = other.item_wear_base_2;
        item_wear_base_3 = other.item_wear_base_3;
        item_wear_base_4 = other.item_wear_base_4;
        item_wear_base_5 = other.item_wear_base_5;
        item_wear_addEachLevel_1 = other.item_wear_addEachLevel_1;
        item_wear_addEachLevel_2 = other.item_wear_addEachLevel_2;
        item_wear_addEachLevel_3 = other.item_wear_addEachLevel_3;
        item_wear_addEachLevel_4 = other.item_wear_addEachLevel_4;
        item_wear_addEachLevel_5 = other.item_wear_addEachLevel_5;
        item_use_base_1 = other.item_use_base_1;
        item_use_base_2 = other.item_use_base_2;
        item_use_base_3 = other.item_use_base_3;
        item_use_base_4 = other.item_use_base_4;
        item_use_base_5 = other.item_use_base_5;
        item_use_addEachLevel_1 = other.item_use_addEachLevel_1;
        item_use_addEachLevel_2 = other.item_use_addEachLevel_2;
        item_use_addEachLevel_3 = other.item_use_addEachLevel_3;
        item_use_addEachLevel_4 = other.item_use_addEachLevel_4;
        item_use_addEachLevel_5 = other.item_use_addEachLevel_5;
        item_Value = other.item_Value;
        item_Type = other.item_Type;
        item_DisplayName = other.item_DisplayName;
        item_Description = other.item_Description;
        itemIcon = Resources.Load<Sprite>("" + item_Name1);
    }

    public Item()
    {
        
    }


    public void AddLevelstage()
    {
        if (currentLevel == 1 && currentLevelstage < maxUpgrades_1)
        {
            currentUseValue += item_use_addEachLevel_1;
            currentWearValue += item_wear_addEachLevel_1;
            currentLevelstage++;
            chanceToUpgrade += 6;
        }
        if (currentLevel == 2 && currentLevelstage < maxUpgrades_2)
        {
            currentUseValue += item_use_addEachLevel_2;
            currentWearValue += item_wear_addEachLevel_2;
            currentLevelstage++;
            chanceToUpgrade += 4;
        }
        if (currentLevel == 3 && currentLevelstage < maxUpgrades_3)
        {
            currentUseValue += item_use_addEachLevel_3;
            currentWearValue += item_wear_addEachLevel_3;
            currentLevelstage++;
            chanceToUpgrade += 3;
        }
        if (currentLevel == 4 && currentLevelstage < maxUpgrades_4)
        {
            currentUseValue += item_use_addEachLevel_4;
            currentWearValue += item_wear_addEachLevel_4;
            currentLevelstage++;
            chanceToUpgrade += 2.5f;
        }
        if (currentLevel == 5 && currentLevelstage < maxUpgrades_5)
        {
            currentUseValue += item_use_addEachLevel_5;
            currentWearValue += item_wear_addEachLevel_5;
            currentLevelstage++;
        }
    }

    public void UpgradeCrystalLevel()
    {
        if (currentLevel == 1)
        {
            currentUseValue = item_use_base_2;
            currentWearValue = item_wear_base_2;
            currentLevelstage = 0;
            chanceToUpgrade = 17;
            currentLevel++;
            itemIcon = Resources.Load<Sprite>("" + item_Name2);
            return;
        }
        if (currentLevel == 2)
        {
            currentUseValue = item_use_base_3;
            currentWearValue = item_wear_base_3;
            currentLevelstage = 0;
            chanceToUpgrade = 10;
            currentLevel++;
            itemIcon = Resources.Load<Sprite>("" + item_Name3);
            return;
        }
        if (currentLevel == 3)
        {
            currentUseValue = item_use_base_4;
            currentWearValue = item_wear_base_4;
            currentLevelstage = 0;
            chanceToUpgrade = 0;
            currentLevel++;
            itemIcon = Resources.Load<Sprite>("" + item_Name4);
            return;
        }
        if (currentLevel == 4)
        {
            currentUseValue = item_use_base_5;
            currentWearValue = item_wear_base_5;
            currentLevelstage = 0;
            chanceToUpgrade = 0;
            currentLevel++;
            itemIcon = Resources.Load<Sprite>("" + item_Name5);
            return;
        }
    }

    public void AssignTo()
    {
        currentLevel = item_level;

        if (item_level == 1)
        {
            currentUseValue = item_use_base_1;
            currentWearValue = item_wear_base_1;
            chanceToUpgrade = 20;
        }
        if (item_level == 2)
        {
            currentUseValue = item_use_base_2;
            currentWearValue = item_wear_base_2;
            chanceToUpgrade = 17;
        }
        if (item_level == 3)
        {
            currentUseValue = item_use_base_3;
            currentWearValue = item_wear_base_3;
            chanceToUpgrade = 10;
        }
        if (item_level == 4)
        {
            currentUseValue = item_use_base_4;
            currentWearValue = item_wear_base_4;
        }
        if (item_level == 5)
        {
            currentUseValue = item_use_base_5;
            currentWearValue = item_wear_base_5;
            currentChanceValue = 40;
        }
    }
}