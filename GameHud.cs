using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameHud : MonoBehaviour
{
    public int days = 1;
    public int hours = 0;
    public int minutes = 0;
    public float InGameTime = 0f;
    private float _totalTime;
    public float TimeMultiplier = 10f;
    public Text currentTime;
    public Text currentWood;
    public Text currentStone;
    public Text currentAmmo;
    public int woodplank;
    public int wood;
    public int stone;
    public int ammo = 20;

    public void Update()
    {
        if (hours < 10 && minutes < 10)
            currentTime.text = ("Day " + days + " | 0" + hours + ":0" + minutes);

        if (hours >= 10 && minutes < 10)
            currentTime.text = ("Day " + days + " | " + hours + ":0" + minutes);

        if (hours < 10 && minutes >= 10)
            currentTime.text = ("Day " + days + " | 0" + hours + ":" + minutes);

        if (hours >= 10 && minutes >= 10)
            currentTime.text = ("Day " + days + " | " + hours + ":" + minutes);

        currentWood.text = ("" + wood);
        currentStone.text = ("" + stone);
        currentAmmo.text = ("" + ammo);

        if (ammo <= 0)
            GameObject.Find("Player").GetComponent<Player>().EmptyAmmo = true;
        if (ammo > 0)
            GameObject.Find("Player").GetComponent<Player>().EmptyAmmo = false;

        InGameTime += Time.deltaTime * TimeMultiplier;
        _totalTime += Time.deltaTime;
        Screen.showCursor = true;

        if (InGameTime >= 60)
        {
            minutes += 1;
            InGameTime -= 60;
        }
        if (minutes >= 60)
        {
            hours += 1;
            minutes -= 60;
        }
        if (hours >= 14)
        {
            days += 1;
            hours -= 14;
        }
   }
}
