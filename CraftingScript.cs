using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CraftingScript : MonoBehaviour
{
    public List<GameObject> CraftingSlots = new List<GameObject>();
    public Text ChanceX1;
    public Text ChanceX2;
    public Text ChanceX3;
    public Text CrystalLevel;
    public Text Success;

    private float _successtimer;
    private GameObject _crystal;
    private GameObject _emptySprite;
    private GameObject _slot1;
    private GameObject _slot2;
    private GameObject _slot3;
    private GameObject _slot4;
    private GameObject _slot5;
    private GameObject _slot6;
    private GameObject _slot7;
    private GameObject _slot8;
    private GameObject _showChanceToUpgrade;

    public int Chance1 = 0;
    public int Chance2 = 0;
    public int Chance3 = 0;

    private bool TripleNotAvailable;
    private bool DoubleNotAvailable;
    private bool SimpleNotAvailable;

    private float base_chance_1 = 60;
    private float base_chance_2 = 48;
    private float base_chance_3 = 39;
    private float base_chance_4 = 30;
    private float base_chance_5 = 15;

    private float base_multiplier_doubleUpgrade = 0.666666f;
    private float base_multiplier_tripleUpgrade = 0.416666f;

    private float bonus_ressource_simple = 1.5f;
    private float bonus_ressource_double = 1.75f;
    private float bonus_ressource_triple = 2f;
    private float add_extraRessource = 0.25f;

    public int simpleRessource = 0;
    public int specialRessource = 0;

    private void Awake()
    {
        _crystal = GameObject.Find("Crystal_Slot");
        _emptySprite = GameObject.Find("EmptySprite");
        _slot1 = GameObject.Find("CraftingSlot1");
        _slot2 = GameObject.Find("Ressource2");
        _slot3 = GameObject.Find("Ressource3");
        _slot4 = GameObject.Find("Ressource4");
        _slot5 = GameObject.Find("Ressource5");
        _slot6 = GameObject.Find("Ressource6");
        _slot7 = GameObject.Find("Ressource7");
        _slot8 = GameObject.Find("Ressource8");
        _showChanceToUpgrade = GameObject.Find("ShowChanceToUpgrade");
    }


    private void Start()
    {
        CraftingSlots.Add(_slot1);
        CraftingSlots.Add(_slot2);
        CraftingSlots.Add(_slot3);
        CraftingSlots.Add(_slot4);
        CraftingSlots.Add(_slot5);
        CraftingSlots.Add(_slot6);
        CraftingSlots.Add(_slot7);
        CraftingSlots.Add(_slot8);
    }

    public void Update()
    {
        _successtimer -= Time.deltaTime;
        if (_successtimer <= 0)
            Success.text = "";

        if (_crystal.GetComponent<Image>().sprite.name != "Empty")
        {
            CrystalLevel.text = ("" + CraftingSlots[0].GetComponent<CraftingSlot>().item.currentLevelstage);
            GetChances();
            ChangeText();
            ShowChanceToUpgrade();
        }
        else
        {
            HideChanceToUpgrade();
            CrystalLevel.text = "";
        }

    }


    public void AddRessourceAtEmptySlot(GameObject Ressource)
    {
        for (int i = 1; i < 8; i++)
        {
            if (CraftingSlots[i].GetComponent<Image>().sprite.name.Equals("Empty"))
            {
                CraftingSlots[i].GetComponent<Image>().sprite = Ressource.GetComponent<Image>().sprite;
                break;
            }
        }
    }

    public void UpgradeCrystal(string name)
    {
        var rnd = Random.Range(0, 100);
        Debug.Log(rnd);


        if (Chance3 >= rnd && !TripleNotAvailable)
        {
            CraftingSlots[0].GetComponent<CraftingSlot>().item.AddLevelstage();
            CraftingSlots[0].GetComponent<CraftingSlot>().item.AddLevelstage();
            CraftingSlots[0].GetComponent<CraftingSlot>().item.AddLevelstage();
            Success.text = "EXTREME SUCCESS";
        }
        else if (Chance2 >= rnd && !DoubleNotAvailable)
        {
            CraftingSlots[0].GetComponent<CraftingSlot>().item.AddLevelstage();
            CraftingSlots[0].GetComponent<CraftingSlot>().item.AddLevelstage();
            Success.text = "GREAT SUCCESS";
        }
        else if (Chance1 >= rnd && !SimpleNotAvailable)
        {
            CraftingSlots[0].GetComponent<CraftingSlot>().item.AddLevelstage();
            Success.text = "SUCCESS";
        }
        else
        {
            Success.text = "Upgrade failed :(";
        }

        SimpleNotAvailable = false;
        DoubleNotAvailable = false;
        TripleNotAvailable = false;
        _successtimer = 2;
        simpleRessource = 0;
        for (int i = 7; i > 0; i--)
        {
            if (CraftingSlots[i].GetComponent<Image>().sprite.name != "Empty")
            {
                CraftingSlots[i].GetComponent<Image>().sprite = _emptySprite.GetComponent<Image>().sprite;
            }
        }
    }

    public void ShowChanceToUpgrade()
    {
        _showChanceToUpgrade.SetActive(true);
    }

    public void HideChanceToUpgrade()
    {
        _showChanceToUpgrade.SetActive(false);
    }

    public void GetChances()
    {
        float C1 = 0;
        float C2 = 0;
        float C3 = 0;

        if (CraftingSlots[0].GetComponent<CraftingSlot>().item.currentLevel == 1)
        {
            if (simpleRessource == 1)
            {
                C1 = base_chance_1;
                C2 = base_chance_1 * base_multiplier_doubleUpgrade;
                C3 = base_chance_1 * base_multiplier_tripleUpgrade;
            }

            if (simpleRessource > 1 && simpleRessource < 5)
            {
                C1 = (base_chance_1) * (bonus_ressource_simple + ((simpleRessource - 2) * add_extraRessource));
                C2 = (base_chance_1 * base_multiplier_doubleUpgrade * (bonus_ressource_double + ((simpleRessource - 2) * add_extraRessource)));
                C3 = (base_chance_1 * base_multiplier_tripleUpgrade * (bonus_ressource_triple + ((simpleRessource - 2) * add_extraRessource)));
            }


            if (simpleRessource == 5)
            {
                C1 = (base_chance_1) * (bonus_ressource_simple + ((simpleRessource - 1) * add_extraRessource));
                C2 = (base_chance_1 * base_multiplier_doubleUpgrade * (bonus_ressource_double + ((simpleRessource - 1) * add_extraRessource)));
                C3 = (base_chance_1 * base_multiplier_tripleUpgrade * (bonus_ressource_triple + ((simpleRessource - 1) * add_extraRessource)));
            }


            if (simpleRessource == 6)
            {
                C1 = (base_chance_1) * (bonus_ressource_simple + ((simpleRessource) * add_extraRessource));
                C2 = (base_chance_1 * base_multiplier_doubleUpgrade * (bonus_ressource_double + ((simpleRessource) * add_extraRessource)));
                C3 = (base_chance_1 * base_multiplier_tripleUpgrade * (bonus_ressource_triple + ((simpleRessource) * add_extraRessource)));
            }


            if (simpleRessource == 7)
            {
                C1 = (base_chance_1) * (bonus_ressource_simple + ((simpleRessource + 2) * add_extraRessource));
                C2 = (base_chance_1 * base_multiplier_doubleUpgrade * (bonus_ressource_double + ((simpleRessource + 2) * add_extraRessource)));
                C3 = (base_chance_1 * base_multiplier_tripleUpgrade * (bonus_ressource_triple + ((simpleRessource + 2) * add_extraRessource)));
            }
        }

        if (CraftingSlots[0].GetComponent<CraftingSlot>().item.currentLevel == 2)
        {
            if (simpleRessource == 1)
            {
                C1 = base_chance_2;
                C2 = base_chance_2 * base_multiplier_doubleUpgrade;
                C3 = base_chance_2 * base_multiplier_tripleUpgrade;
            }

            if (simpleRessource > 1 && simpleRessource < 5)
            {
                C1 = (base_chance_2) * (bonus_ressource_simple + ((simpleRessource - 2) * add_extraRessource));
                C2 = (base_chance_2 * base_multiplier_doubleUpgrade * (bonus_ressource_double + ((simpleRessource - 2) * add_extraRessource)));
                C3 = (base_chance_2 * base_multiplier_tripleUpgrade * (bonus_ressource_triple + ((simpleRessource - 2) * add_extraRessource)));
            }


            if (simpleRessource == 5)
            {
                C1 = (base_chance_2) * (bonus_ressource_simple + ((simpleRessource - 1) * add_extraRessource));
                C2 = (base_chance_2 * base_multiplier_doubleUpgrade * (bonus_ressource_double + ((simpleRessource - 1) * add_extraRessource)));
                C3 = (base_chance_2 * base_multiplier_tripleUpgrade * (bonus_ressource_triple + ((simpleRessource - 1) * add_extraRessource)));
            }


            if (simpleRessource == 6)
            {
                C1 = (base_chance_2) * (bonus_ressource_simple + ((simpleRessource) * add_extraRessource));
                C2 = (base_chance_2 * base_multiplier_doubleUpgrade * (bonus_ressource_double + ((simpleRessource) * add_extraRessource)));
                C3 = (base_chance_2 * base_multiplier_tripleUpgrade * (bonus_ressource_triple + ((simpleRessource) * add_extraRessource)));
            }


            if (simpleRessource == 7)
            {
                C1 = (base_chance_2) * (bonus_ressource_simple + ((simpleRessource + 2) * add_extraRessource));
                C2 = (base_chance_2 * base_multiplier_doubleUpgrade * (bonus_ressource_double + ((simpleRessource + 2) * add_extraRessource)));
                C3 = (base_chance_2 * base_multiplier_tripleUpgrade * (bonus_ressource_triple + ((simpleRessource + 2) * add_extraRessource)));
            }
        }
        if (CraftingSlots[0].GetComponent<CraftingSlot>().item.currentLevel == 3)
        {
            if (simpleRessource == 1)
            {
                C1 = base_chance_3;
                C2 = base_chance_3 * base_multiplier_doubleUpgrade;
                C3 = base_chance_3 * base_multiplier_tripleUpgrade;
            }

            if (simpleRessource > 1 && simpleRessource < 5)
            {
                C1 = (base_chance_3) * (bonus_ressource_simple + ((simpleRessource - 2) * add_extraRessource));
                C2 = (base_chance_3 * base_multiplier_doubleUpgrade * (bonus_ressource_double + ((simpleRessource - 2) * add_extraRessource)));
                C3 = (base_chance_3 * base_multiplier_tripleUpgrade * (bonus_ressource_triple + ((simpleRessource - 2) * add_extraRessource)));
            }


            if (simpleRessource == 5)
            {
                C1 = (base_chance_3) * (bonus_ressource_simple + ((simpleRessource - 1) * add_extraRessource));
                C2 = (base_chance_3 * base_multiplier_doubleUpgrade * (bonus_ressource_double + ((simpleRessource - 1) * add_extraRessource)));
                C3 = (base_chance_3 * base_multiplier_tripleUpgrade * (bonus_ressource_triple + ((simpleRessource - 1) * add_extraRessource)));
            }


            if (simpleRessource == 6)
            {
                C1 = (base_chance_3) * (bonus_ressource_simple + ((simpleRessource) * add_extraRessource));
                C2 = (base_chance_3 * base_multiplier_doubleUpgrade * (bonus_ressource_double + ((simpleRessource) * add_extraRessource)));
                C3 = (base_chance_3 * base_multiplier_tripleUpgrade * (bonus_ressource_triple + ((simpleRessource) * add_extraRessource)));
            }


            if (simpleRessource == 7)
            {
                C1 = (base_chance_3) * (bonus_ressource_simple + ((simpleRessource + 2) * add_extraRessource));
                C2 = (base_chance_3 * base_multiplier_doubleUpgrade * (bonus_ressource_double + ((simpleRessource + 2) * add_extraRessource)));
                C3 = (base_chance_3 * base_multiplier_tripleUpgrade * (bonus_ressource_triple + ((simpleRessource + 2) * add_extraRessource)));
            }
        }
        if (CraftingSlots[0].GetComponent<CraftingSlot>().item.currentLevel == 4)
        {
            if (simpleRessource == 1)
            {
                C1 = base_chance_4;
                C2 = base_chance_4 * base_multiplier_doubleUpgrade;
                C3 = base_chance_4 * base_multiplier_tripleUpgrade;
            }

            if (simpleRessource > 1 && simpleRessource < 5)
            {
                C1 = (base_chance_4) * (bonus_ressource_simple + ((simpleRessource - 2) * add_extraRessource));
                C2 = (base_chance_4 * base_multiplier_doubleUpgrade * (bonus_ressource_double + ((simpleRessource - 2) * add_extraRessource)));
                C3 = (base_chance_4 * base_multiplier_tripleUpgrade * (bonus_ressource_triple + ((simpleRessource - 2) * add_extraRessource)));
            }


            if (simpleRessource == 5)
            {
                C1 = (base_chance_4) * (bonus_ressource_simple + ((simpleRessource - 1) * add_extraRessource));
                C2 = (base_chance_4 * base_multiplier_doubleUpgrade * (bonus_ressource_double + ((simpleRessource - 1) * add_extraRessource)));
                C3 = (base_chance_4 * base_multiplier_tripleUpgrade * (bonus_ressource_triple + ((simpleRessource - 1) * add_extraRessource)));
            }


            if (simpleRessource == 6)
            {
                C1 = (base_chance_4) * (bonus_ressource_simple + ((simpleRessource) * add_extraRessource));
                C2 = (base_chance_4 * base_multiplier_doubleUpgrade * (bonus_ressource_double + ((simpleRessource) * add_extraRessource)));
                C3 = (base_chance_4 * base_multiplier_tripleUpgrade * (bonus_ressource_triple + ((simpleRessource) * add_extraRessource)));
            }


            if (simpleRessource == 7)
            {
                C1 = (base_chance_4) * (bonus_ressource_simple + ((simpleRessource + 2) * add_extraRessource));
                C2 = (base_chance_4 * base_multiplier_doubleUpgrade * (bonus_ressource_double + ((simpleRessource + 2) * add_extraRessource)));
                C3 = (base_chance_4 * base_multiplier_tripleUpgrade * (bonus_ressource_triple + ((simpleRessource + 2) * add_extraRessource)));
            }
        }
        if (CraftingSlots[0].GetComponent<CraftingSlot>().item.currentLevel == 5)
        {
            if (simpleRessource == 1)
            {
                C1 = base_chance_5;
                C2 = base_chance_5 * base_multiplier_doubleUpgrade;
                C3 = base_chance_5 * base_multiplier_tripleUpgrade;
            }

            if (simpleRessource > 1 && simpleRessource < 5)
            {
                C1 = (base_chance_5) * (bonus_ressource_simple + ((simpleRessource - 2) * add_extraRessource));
                C2 = (base_chance_5 * base_multiplier_doubleUpgrade * (bonus_ressource_double + ((simpleRessource - 2) * add_extraRessource)));
                C3 = (base_chance_5 * base_multiplier_tripleUpgrade * (bonus_ressource_triple + ((simpleRessource - 2) * add_extraRessource)));
            }


            if (simpleRessource == 5)
            {
                C1 = (base_chance_5) * (bonus_ressource_simple + ((simpleRessource - 1) * add_extraRessource));
                C2 = (base_chance_5 * base_multiplier_doubleUpgrade * (bonus_ressource_double + ((simpleRessource - 1) * add_extraRessource)));
                C3 = (base_chance_5 * base_multiplier_tripleUpgrade * (bonus_ressource_triple + ((simpleRessource - 1) * add_extraRessource)));
            }


            if (simpleRessource == 6)
            {
                C1 = (base_chance_5) * (bonus_ressource_simple + ((simpleRessource) * add_extraRessource));
                C2 = (base_chance_5 * base_multiplier_doubleUpgrade * (bonus_ressource_double + ((simpleRessource) * add_extraRessource)));
                C3 = (base_chance_5 * base_multiplier_tripleUpgrade * (bonus_ressource_triple + ((simpleRessource) * add_extraRessource)));
            }


            if (simpleRessource == 7)
            {
                C1 = (base_chance_5) * (bonus_ressource_simple + ((simpleRessource + 2) * add_extraRessource));
                C2 = (base_chance_5 * base_multiplier_doubleUpgrade * (bonus_ressource_double + ((simpleRessource + 2) * add_extraRessource)));
                C3 = (base_chance_5 * base_multiplier_tripleUpgrade * (bonus_ressource_triple + ((simpleRessource + 2) * add_extraRessource)));
            }
        }

        if (C1 > 100)
        {
            C1 = 100;
            Chance1 = (int)C1;

        }
        else
        {
            Chance1 = (int)C1;
        }

        if (C2 > 100)
        {
            C2 = 100;
            Chance2 = (int)C2;

        }
        else
        {
            if (C2 == 0)
                Chance2 = (int)C2;
            else
                Chance2 = (int)C2 + 1;
        }

        if (C3 > 100)
        {
            C3 = 100;
            Chance3 = (int)C3;

        }
        else
        {
            if (C3 == 0)
                Chance3 = (int)C3;
            else
                Chance3 = (int)C3 + 1;
        }
    }

    public void ChangeText()
    {
        if (CraftingSlots[0].GetComponent<CraftingSlot>().item.currentLevel == 1)
        {
            if (CraftingSlots[0].GetComponent<CraftingSlot>().item.maxUpgrades_1 <=
                CraftingSlots[0].GetComponent<CraftingSlot>().item.currentLevelstage)
            {
                ChanceX1.text = ("/");
                SimpleNotAvailable = true;
            }
            else
            {
                ChanceX1.text = ("Simple Upgrade: " + Chance1 + "%");
            }

            if (CraftingSlots[0].GetComponent<CraftingSlot>().item.maxUpgrades_1 <=
                CraftingSlots[0].GetComponent<CraftingSlot>().item.currentLevelstage + 1)
            {
                ChanceX2.text = ("/");
                DoubleNotAvailable = true;
            }
            else
            {
                ChanceX2.text = ("Double Upgrade: " + Chance2 + "%");
            }

            if (CraftingSlots[0].GetComponent<CraftingSlot>().item.maxUpgrades_1 <=
                CraftingSlots[0].GetComponent<CraftingSlot>().item.currentLevelstage + 2)
            {
                ChanceX3.text = ("/");
                TripleNotAvailable = true;
            }
            else
            {
                ChanceX3.text = ("Triple Upgrade: " + Chance3 + "%");
            }
        }
        if (CraftingSlots[0].GetComponent<CraftingSlot>().item.currentLevel == 2)
        {
            if (CraftingSlots[0].GetComponent<CraftingSlot>().item.maxUpgrades_2 <=
                CraftingSlots[0].GetComponent<CraftingSlot>().item.currentLevelstage)
            {
                ChanceX1.text = ("/");
                SimpleNotAvailable = true;
            }
            else
            {
                ChanceX1.text = ("Simple Upgrade: " + Chance1 + "%");
            }

            if (CraftingSlots[0].GetComponent<CraftingSlot>().item.maxUpgrades_2 <=
                CraftingSlots[0].GetComponent<CraftingSlot>().item.currentLevelstage + 1)
            {
                ChanceX2.text = ("/");
                DoubleNotAvailable = true;
            }
            else
            {
                ChanceX2.text = ("Double Upgrade: " + Chance2 + "%");
            }

            if (CraftingSlots[0].GetComponent<CraftingSlot>().item.maxUpgrades_2 <=
                CraftingSlots[0].GetComponent<CraftingSlot>().item.currentLevelstage + 2)
            {
                ChanceX3.text = ("/");
                TripleNotAvailable = true;
            }
            else
            {
                ChanceX3.text = ("Triple Upgrade: " + Chance3 + "%");
            }
        }
        if (CraftingSlots[0].GetComponent<CraftingSlot>().item.currentLevel == 3)
        {
            if (CraftingSlots[0].GetComponent<CraftingSlot>().item.maxUpgrades_3 <=
                CraftingSlots[0].GetComponent<CraftingSlot>().item.currentLevelstage)
            {
                ChanceX1.text = ("/");
                SimpleNotAvailable = true;
            }
            else
            {
                ChanceX1.text = ("Simple Upgrade: " + Chance1 + "%");
            }

            if (CraftingSlots[0].GetComponent<CraftingSlot>().item.maxUpgrades_3 <=
                CraftingSlots[0].GetComponent<CraftingSlot>().item.currentLevelstage + 1)
            {
                ChanceX2.text = ("/");
                DoubleNotAvailable = true;
            }
            else
            {
                ChanceX2.text = ("Double Upgrade: " + Chance2 + "%");
            }

            if (CraftingSlots[0].GetComponent<CraftingSlot>().item.maxUpgrades_3 <=
                CraftingSlots[0].GetComponent<CraftingSlot>().item.currentLevelstage + 2)
            {
                ChanceX3.text = ("/");
                TripleNotAvailable = true;
            }
            else
            {
                ChanceX3.text = ("Triple Upgrade: " + Chance3 + "%");
            }
        }
        if (CraftingSlots[0].GetComponent<CraftingSlot>().item.currentLevel == 4)
        {
            if (CraftingSlots[0].GetComponent<CraftingSlot>().item.maxUpgrades_4 <=
                CraftingSlots[0].GetComponent<CraftingSlot>().item.currentLevelstage)
            {
                ChanceX1.text = ("/");
                SimpleNotAvailable = true;
            }
            else
            {
                ChanceX1.text = ("Simple Upgrade: " + Chance1 + "%");
            }

            if (CraftingSlots[0].GetComponent<CraftingSlot>().item.maxUpgrades_4 <=
                CraftingSlots[0].GetComponent<CraftingSlot>().item.currentLevelstage + 1)
            {
                ChanceX2.text = ("/");
                DoubleNotAvailable = true;
            }
            else
            {
                ChanceX2.text = ("Double Upgrade: " + Chance2 + "%");
            }

            if (CraftingSlots[0].GetComponent<CraftingSlot>().item.maxUpgrades_4 <=
                CraftingSlots[0].GetComponent<CraftingSlot>().item.currentLevelstage + 2)
            {
                ChanceX3.text = ("/");
                TripleNotAvailable = true;
            }
            else
            {
                ChanceX3.text = ("Triple Upgrade: " + Chance3 + "%");
            }
        }
        if (CraftingSlots[0].GetComponent<CraftingSlot>().item.currentLevel == 5)
        {
            if (CraftingSlots[0].GetComponent<CraftingSlot>().item.maxUpgrades_5 <=
                CraftingSlots[0].GetComponent<CraftingSlot>().item.currentLevelstage)
            {
                ChanceX1.text = ("/");
                SimpleNotAvailable = true;
            }
            else
            {
                ChanceX1.text = ("Simple Upgrade: " + Chance1 + "%");
            }

            if (CraftingSlots[0].GetComponent<CraftingSlot>().item.maxUpgrades_5 <=
                CraftingSlots[0].GetComponent<CraftingSlot>().item.currentLevelstage + 1)
            {
                ChanceX2.text = ("/");
                DoubleNotAvailable = true;
            }
            else
            {
                ChanceX2.text = ("Double Upgrade: " + Chance2 + "%");
            }

            if (CraftingSlots[0].GetComponent<CraftingSlot>().item.maxUpgrades_5 <=
                CraftingSlots[0].GetComponent<CraftingSlot>().item.currentLevelstage + 2)
            {
                ChanceX3.text = ("/");
                TripleNotAvailable = true;
            }
            else
            {
                ChanceX3.text = ("Triple Upgrade: " + Chance3 + "%");
            }
        }
    }
}
