using UnityEngine;
using System.Collections;

public class LootingWood : MonoBehaviour
{
    public float ResetTimer = 600f;
    public float ResetCountdown = 0;
    private float TimesCollected = 1f;
    public bool IsActive = true;
    public AudioClip WoodCollectedSound;
    public float volume = 0.2f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();
        if (player == null)
            return;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GameObject.Find("Managers").GetComponent<GameHud>().wood += 1;
        AudioSource.PlayClipAtPoint(WoodCollectedSound, transform.position, volume);
        IsActive = false;
    }

    public void Update()
    {
        if (IsActive == false)
            ResetCountdown += -1;

        if (ResetCountdown <= 0)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;
            ResetCountdown = ResetTimer * TimesCollected;
            TimesCollected += .5f;
            IsActive = true;
        }

    }
}
