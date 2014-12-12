using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour
{
    public LevelManager levelManager;

	void Start () 
    {
	
	}
	
    public void PlayerHitCheckPoint()
    {

    }

    private IEnumerator PlayerHitCheckpointCo(int bonus)
    {
        yield break;
    }

    public void PlayerLeftCheckpoint()
    {

    }

    public void SpawnPlayer(Player player)
    {
        player.RespawnAt(transform);
    }

	public void AssignObjectToCheckpoint()
    {
	
	}

    public void GreenLight()
    {
        var greenAnimation = this.gameObject.animation.enabled = false;
        return;
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            levelManager.WhatCheckpointIsActive = levelManager.Checkpoints.IndexOf(this);
        }
    }

}
