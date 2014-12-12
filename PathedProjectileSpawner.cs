using UnityEngine;
using System.Collections;

public class PathedProjectileSpawner : MonoBehaviour {

    public Transform Destination;
    public PathedProjectile Projectile;

    public GameObject SpawnEffect;
    public float Speed;
    public float FireRate;
    public float Delay = 0;
    private bool _firstShotDone;


    private float _nextShotInSeconds;

    public void Start()
    {
        _nextShotInSeconds = FireRate;
    }

    public void Update()
    {
        if (_firstShotDone == false)
        {
            if ((_nextShotInSeconds -= Time.deltaTime) > 0 - Delay)
                return;
        }
        else 
        {
            if ((_nextShotInSeconds -= Time.deltaTime) > 0)
            return;
        }

        _nextShotInSeconds = FireRate;
        var projectile = (PathedProjectile)Instantiate(Projectile, transform.position, transform.rotation);
        projectile.Initialize(Destination, Speed);
        _firstShotDone = true;

        if (SpawnEffect != null)
            Instantiate(SpawnEffect, transform.position, transform.rotation);
    }


    public void OnDrawGizmos()
    {
        if (Destination == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, Destination.position);
    }

}
