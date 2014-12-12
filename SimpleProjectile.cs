using UnityEngine;
using System.Collections;

public class SimpleProjectile : Projectile, ITakeDamage
{

    public int Damage;
    public GameObject DestroyedEffect;
    public int PointsToGiveToPlayer;
    public float TimeToLive;
    private float _scaleTime;

    public bool IsWood;
    public bool IsStone;
    private bool _craftingZoneTriggered;
    private bool _stored;

    public void Update()
    {
        if (!IsWood && !IsStone)
        {
            if ((TimeToLive -= Time.deltaTime) <= 0)
            {
                DestroyProjectile();
                return;
            }

            transform.Translate(Direction * (Speed * Time.deltaTime), Space.World);
        }

        if (IsWood || IsStone)
        {
            if (!_craftingZoneTriggered)
            {
                if ((TimeToLive -= Time.deltaTime) <= 0)
                {
                    DestroyProjectile();
                    return;
                }

                transform.Translate(Direction * (Speed * Time.deltaTime), Space.World);
            }
            if (_craftingZoneTriggered)
            {

                if ((TimeToLive -= Time.deltaTime) > 0)
                {
                    transform.Translate(Direction * (Speed * Time.deltaTime * TimeToLive), Space.World);
                    return;
                }
                else
                {
                    if ((_scaleTime += Time.deltaTime) < 1)
                    {
                        gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, new Vector3(0.8f, 0.8f, 0.8f), Time.deltaTime);
                    }
                    if ((_scaleTime += Time.deltaTime) >= 1.2f)
                    {
                        gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, new Vector3(0, 0, -3f), Time.deltaTime * 4);
                    }
                    if ((_scaleTime += Time.deltaTime) >= 3f)
                    {
                        DestroyProjectile();
                        if (IsWood)
                            GameObject.Find("CraftingStation").GetComponent<CraftingStation>().ActiveWood += 1;
                        if (IsStone)
                            GameObject.Find("CraftingStation").GetComponent<CraftingStation>().ActiveStone += 1;
                    }
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == 15)
        {
            _craftingZoneTriggered = true;
            return;
        }
    }

    public void TakeDamage(int damage, GameObject instigator)
    {
        DestroyProjectile();
    }

    protected override void OnCollideOther(Collider2D other)
    {
        DestroyProjectile();
    }

    protected override void OnCollideTakeDamage(Collider2D other, ITakeDamage takeDamage)
    {
        takeDamage.TakeDamage(Damage, gameObject);
        DestroyProjectile();
    }

    public void DestroyProjectile()
    {
        if (DestroyedEffect != null)
            Instantiate(DestroyedEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
