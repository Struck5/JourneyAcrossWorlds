using UnityEngine;
using System.Collections;

public class ShowCurrentWeapon : MonoBehaviour
{
    public Player player;
    public GameObject Ammo;
    public GameObject Wood;
    public GameObject Stone;


    public void Update()
    {
        if (player.ChooseWeapon == 0)
        {
            Ammo.SetActive(true);
            Wood.SetActive(false);
            Stone.SetActive(false);
        }
        if (player.ChooseWeapon == 1)
        {
            Ammo.SetActive(false);
            Wood.SetActive(true);
            Stone.SetActive(false);
        }
        if (player.ChooseWeapon == 2)
        {
            Ammo.SetActive(false);
            Wood.SetActive(false);
            Stone.SetActive(true);
        }
    }
}
