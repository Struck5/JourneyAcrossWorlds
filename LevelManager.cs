using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    public Player Player { get; private set; }
    public CameraMovement Camera { get; private set;}

    public List<Checkpoint> Checkpoints;
    private int _currentCheckpointIndex = 0;

    public int WhatCheckpointIsActive = 0;
    
    public Checkpoint checkPoint;
    public AudioClip CheckpointSound;
    public float volume = 0.2f;

    public void Awake()
    {
        Instance = this;
    }

    public void Start ()
    {
        Checkpoints = FindObjectsOfType<Checkpoint>().OrderBy(t => t.transform.position.x).ToList();
        Checkpoints[_currentCheckpointIndex].gameObject.animation.Play();

        Player = FindObjectOfType<Player>();
        Camera = FindObjectOfType<CameraMovement>();

#if UNITY_EDITOR
        if (checkPoint != null)
            checkPoint.SpawnPlayer(Player);
        else
            Checkpoints[_currentCheckpointIndex].SpawnPlayer(Player);

#else
        Checkpoints[_currentCheckpointIndex].SpawnPlayer(Player);

#endif

    }

    public void Update()
    {
        Checkpoints[_currentCheckpointIndex].PlayerLeftCheckpoint();
        Checkpoints[_currentCheckpointIndex].PlayerHitCheckPoint();

        if (WhatCheckpointIsActive != _currentCheckpointIndex)
        {
            Checkpoints[_currentCheckpointIndex].gameObject.animation.Stop();
            Checkpoints[_currentCheckpointIndex].gameObject.renderer.enabled = true;
            AudioSource.PlayClipAtPoint(CheckpointSound, transform.position, volume);
            _currentCheckpointIndex = WhatCheckpointIsActive;
            Checkpoints[_currentCheckpointIndex].gameObject.animation.Play();
        }

        // TODO Time Bonus
    }

    public void KillPlayer()
    {
        StartCoroutine(KillPlayerCo());
    }

    private IEnumerator KillPlayerCo()
    {
        Player.Kill();
        Camera.IsFollowing = false;
        yield return new WaitForSeconds(2f);

        Camera.IsFollowing = true;

        if (_currentCheckpointIndex != -1)
            Checkpoints[_currentCheckpointIndex].SpawnPlayer(Player);

        // TODO Points
    }
}
