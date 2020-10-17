using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] int health = 20;
    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    [SerializeField] int maxHealth = 100;
    public int MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }

    [SerializeField] int ammo = 15;
    public int Ammo
    {
        get { return ammo; }
        set { ammo = value; }
    }

    [SerializeField] int maxAmmo = 200;
    public int MaxAmmo
    {
        get { return maxAmmo; }
        set { maxAmmo = value; }
    }

    [SerializeField] int treasure = 0;
    public int Treasure
    {
        get { return treasure; }
        set { treasure = value; }
    }

    [SerializeField] bool greyKey = false;
    public bool GreyKey
    {
        get { return greyKey; }
        set { greyKey = value; }
    }

    [SerializeField] bool goldKey = false;
    public bool GoldKey
    {
        get { return goldKey; }
        set { goldKey = value; }
    }

    [SerializeField] bool isDead = false;
    public bool IsDead
    {
        get { return isDead; }
        set { isDead = value; }
    }

    float painAlpha = 0.0f;
    public float PainAlpha
    {
        get { return painAlpha; }
    }

    float tPain = 0;
    float lerpSpeed = 6f;

    CharacterController Controller { get; set; }

    [SerializeField] AudioClip healthClip;
    [SerializeField] AudioClip ammoClip;
    [SerializeField] AudioClip treasureClip;
    [SerializeField] AudioClip keyClip;
    [SerializeField] AudioClip painClip;
    [SerializeField] AudioClip deathClip;

    AudioSource audioSource;
    Camera camera;

    [SerializeField] LayerMask mask;

    [SerializeField] string enemyTag = "Enemy";
    [SerializeField] GameObject bulletImpactPrefab;
    [Header("These are set on Start()")]
    [SerializeField] GameObject bulletImpact;

    public UIManager restart;

    void Awake()
    {
        Controller = GetComponent<CharacterController>();
        audioSource = GetComponentInChildren<AudioSource>();
        camera = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        if (tPain < 1 && !isDead)
        {
            //This will increment tParam based on Time.deltaTime multiplied by a speed multiplier
            tPain += Time.deltaTime * lerpSpeed;
            painAlpha = Mathf.Lerp(painAlpha, 0, tPain);
        }

    }

    void LateUpdate()
    {
        if (isDead == true) painAlpha = 0.5f;
    }

    public void AddHealth(int amount)
    {
        health += amount;
        if (health > maxHealth) health = maxHealth;
        if (audioSource != null && healthClip != null)
        {
            audioSource.clip = healthClip;
            audioSource.Play();
        }
    }

    public void RemoveHealth(int amount)
    {
        health -= amount;

        float alphaAmount = (float)amount / 10;
        alphaAmount = Mathf.Clamp(alphaAmount, 0.0f, 0.5f);
        if (alphaAmount > painAlpha)
        {
            painAlpha = alphaAmount;
            tPain = 0f;
        }

        if (health > 0 && audioSource != null && painClip != null)
        {
            audioSource.clip = painClip;
            audioSource.Play();
        }
        if (health <= 0 && audioSource != null && deathClip != null && !isDead)
        {
            audioSource.clip = deathClip;
            audioSource.Play();
            isDead = true;
            health = 0;
        }
        if (health < 0) health = 0;
    }

    public void AddAmmo(int amount)
    {
        ammo += amount;
        if (ammo > maxAmmo) ammo = maxAmmo;
        if (audioSource != null && ammoClip != null)
        {
            audioSource.clip = ammoClip;
            audioSource.Play();
        }
    }

    public void RemoveAmmo(int amount)
    {
        ammo -= amount;
        if (ammo < 0) ammo = 0;
    }

    public void AddTreasure(int amount)
    {
        treasure += amount;
        if (audioSource != null && treasureClip != null)
        {
            audioSource.clip = treasureClip;
            audioSource.Play();
        }
    }

    public void RemoveTreasure(int amount)
    {
        treasure -= amount;
        if (treasure < 0) ammo = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag ("Enemy"))
        {
            restart.ReloadLevel();
        }
    }

    /*
    public void AddKey(Key.KeyType keyType)
    {
        bool keyAdded = false;
        switch (keyType)
        {
            case Key.KeyType.grey:
                greyKey = true;
                keyAdded = true;
                break;
            case Key.KeyType.gold:
                goldKey = true;
                keyAdded = true;
                break;
        }

        if (audioSource != null && keyClip != null && keyAdded == true)
        {
            audioSource.clip = keyClip;
            audioSource.Play();
        }
    }

    public void RemoveKey(Key.KeyType keyType)
    {
        switch (keyType)
        {
            case Key.KeyType.grey:
                greyKey = false;
                break;
            case Key.KeyType.gold:
                goldKey = false;
                break;
        }
    }
    */
}
