using UnityEngine;
using System.Collections;

public class LootingWoodplank : MonoBehaviour
{
    public AudioClip CollectedSound;
    public float volume = 0.2f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();
        if (player == null)
            return;

        GameObject.Find("Managers").GetComponent<GameHud>().woodplank += 1;
        AudioSource.PlayClipAtPoint(CollectedSound, transform.position, volume);
        Destroy(gameObject);
    }
}
