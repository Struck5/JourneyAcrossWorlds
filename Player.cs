using System.Runtime.Serialization.Formatters;
using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
    private bool _isFacingRight;
    private CharacterController2D _controller;
    private float _normalizedHorizontalSpeed;
    public GameObject CameraObject;


    public float MaxSpeed = 10f;
    public float SpeedAccelerationOnGround = 10f;
    public float SpeedAccelerationInAir = 5f;
    public int MaxHealth = 100;
    public int MaxHealthModified;
    public GameObject OuchEffect;
    public Projectile Projectile_SmallAndFast;
    public Projectile Projectile_Medium;
    public Projectile Projectile_BigAndSlow;
    public float FireRate;
    public Transform ProjectileFireLocation;
    public bool EmptyAmmo;
    public int ChooseWeapon = 0;

    public int SpeedMultiplier = 1;
    
    public float ImmuneTime = 1f;
    public bool _immune = false;

    public int Health { get; set; }
    public bool IsDead { get; private set; }

    private float _timer;
    private float _canFireIn;
    private bool _inventoryOpen;

    public AudioClip JumpSound;
    public float volume = 0.2f;

    bool grounded = true;
    Animator animator;


    public void Awake()
    {
        GameObject.Find("Canvas_Inventory").GetComponent<Canvas>().enabled = false;
        _controller = GetComponent<CharacterController2D>();
        _isFacingRight = transform.localScale.x > 0;
        MaxHealthModified = MaxHealth;
        Health = MaxHealthModified;

        GetComponent<CharacterController2D>();

        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        if (_timer > 0)
        {
            _immune = true;
            _timer -= Time.deltaTime;
        }
        else
        {
            _immune = false;
        }

        _canFireIn -= Time.deltaTime;

        if (!IsDead)
            HandleInput();

        var movementFactor = _controller.State.IsGrounded ? SpeedAccelerationOnGround : SpeedAccelerationInAir;

        // ReSharper disable ConvertIfStatementToConditionalTernaryExpression

        if (IsDead)
            _controller.SetHorizontalForce(0);
        else
            _controller.SetHorizontalForce(Mathf.Lerp(_controller.Velocity.x, _normalizedHorizontalSpeed * (MaxSpeed * ((100 + SpeedMultiplier) / 100)) , Time.deltaTime * movementFactor));
    }

    public void Kill()
    {
        _controller.HandleCollisions = false;
        collider2D.enabled = false;
        IsDead = true;
        Health = 0;

        _controller.SetForce(new Vector2(0, 20));
    }

    public void RespawnAt(Transform spawnPoint)
    {
        if (!_isFacingRight)
            Flip();

        _controller.HandleCollisions = true;
        collider2D.enabled = true;
        IsDead = false;
        Health = MaxHealthModified;

        transform.position = spawnPoint.position;
    }

    public void TakeDamage (int damage)
    {
        if (_immune == false)
        {
            Instantiate(OuchEffect, transform.position, transform.rotation);
            Health -= damage;
        }

        _timer = ImmuneTime;
        if (Health <= 0)
            LevelManager.Instance.KillPlayer();
    }


    private void HandleInput()
    {
        if (Input.GetKey(KeyCode.D))
        {
            GameObject.Find("CameraObject").GetComponent<FollowPlayer>().ChangeX += 0.004f; 
            _normalizedHorizontalSpeed = 1;
            if (!_isFacingRight)
            {
                Flip();
            }
    
        }
        else if (Input.GetKey(KeyCode.A))
        {
            GameObject.Find("CameraObject").GetComponent<FollowPlayer>().ChangeX -= 0.004f; 
            _normalizedHorizontalSpeed = -1;
            if (_isFacingRight)
            {
                Flip();
            }

        }
        else
        {
            if (GameObject.Find("CameraObject").GetComponent<FollowPlayer>().ChangeX > 0.5)
            GameObject.Find("CameraObject").GetComponent<FollowPlayer>().ChangeX -= 0.001f;
            if (GameObject.Find("CameraObject").GetComponent<FollowPlayer>().ChangeX < -0.5)
                GameObject.Find("CameraObject").GetComponent<FollowPlayer>().ChangeX += 0.001f; 
            _normalizedHorizontalSpeed = 0;
        }

        if (_controller.CanJump && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Ground", false);
            AudioSource.PlayClipAtPoint(JumpSound, transform.position, volume);
            _controller.Jump();
        }

        if (Input.GetMouseButtonDown(0))
            FireProjectile(ChooseWeapon);
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChooseWeapon += 1;

            if (ChooseWeapon > 2)
                ChooseWeapon = 0;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!_inventoryOpen)
            {
                GameObject.Find("Canvas_Inventory").GetComponent<Canvas>().enabled = true;
                _inventoryOpen = true;
            }
            else
            {
                GameObject.Find("Canvas_Inventory").GetComponent<Canvas>().enabled = false;
                _inventoryOpen = false;
            }
        }




#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.L))
        {
            GameObject.Find("Managers").GetComponent<GameHud>().stone += 1;
            GameObject.Find("Managers").GetComponent<GameHud>().wood += 1;
            GameObject.Find("Managers").GetComponent<GameHud>().ammo += 1;
        }
#endif

    }

    private void FireProjectile(int chooseWeapon)
    {
        Vector3 spawnLocation = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 direction = (Input.mousePosition - spawnLocation).normalized;

        if (chooseWeapon == 0)
        {
            if (_canFireIn > 0 || EmptyAmmo )
                return;
            GameObject.Find("Managers").GetComponent<GameHud>().ammo -= 1;
            var projectile = (Projectile)Instantiate(Projectile_SmallAndFast, ProjectileFireLocation.position, ProjectileFireLocation.rotation);
            projectile.Initialize(gameObject, direction, _controller.Velocity);
        }
        if (chooseWeapon == 1)
        {
            if (_canFireIn > 0 || EmptyAmmo)
                return;
            GameObject.Find("Managers").GetComponent<GameHud>().wood -= 1;
            var projectile = (Projectile)Instantiate(Projectile_Medium, ProjectileFireLocation.position, ProjectileFireLocation.rotation);
            projectile.Initialize(gameObject, direction, _controller.Velocity);
        }
        if (chooseWeapon == 2)
        {
            if (_canFireIn > 0 || EmptyAmmo)
                return;
            GameObject.Find("Managers").GetComponent<GameHud>().stone -= 1;
            var projectile = (Projectile)Instantiate(Projectile_BigAndSlow, ProjectileFireLocation.position, ProjectileFireLocation.rotation);
            projectile.Initialize(gameObject, direction, _controller.Velocity);
        }


        _canFireIn = FireRate;
    }

    private void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        _isFacingRight = transform.localScale.x > 0;
    }


    public void AddMaxHealth(int additionalMaxHealth)
    {
        MaxHealthModified = MaxHealth + additionalMaxHealth;
    }
}
