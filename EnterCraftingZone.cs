using UnityEngine;
using System.Collections;

public class EnterCraftingZone : MonoBehaviour
{
    public bool CraftingOpen;
    private GameObject _canvasCrafting;

    private void Awake()
    {
        _canvasCrafting = GameObject.Find("Canvas_Crafting");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        CraftingOpen = true;
        _canvasCrafting.GetComponent<Canvas>().enabled = true;
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        CraftingOpen = true;
        _canvasCrafting.GetComponent<Canvas>().enabled = true;
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        CraftingOpen = false;
        _canvasCrafting.GetComponent<Canvas>().enabled = false;
    }
}
