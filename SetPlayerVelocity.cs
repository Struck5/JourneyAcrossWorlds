using UnityEngine;
using System.Collections;

public class SetPlayerVelocity : MonoBehaviour
{

    public float NewVelocity = 0;

    public void OnTriggerEnter2D(Collider2D other)
    {
        GameObject.Find("Player").GetComponent<CharacterController2D>().SetForce(new Vector2(0, NewVelocity));
    }
}
