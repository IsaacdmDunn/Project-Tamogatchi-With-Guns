using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public enum GunState
    {
        none, shooting, reloading
    }

    public float damage, fireRate, spread, reloadTime;
    public int magSize, bulletsPerTap, bulletsLeft,totalBullets;
    public bool autoFire;
    public GunState state = GunState.none;

    float timeBetweenShot;
    float reloadTimer;
    Vector3 spreadDirection;

    public GameObject Projectile;
    public Transform BulletOrigin;
    public Camera camera;

    public Animator gunAnimations;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeBetweenShot += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0) && bulletsLeft == 0 && totalBullets > 0 && bulletsLeft < magSize)
        {
            StartReload();
        }
        if (Input.GetKey(KeyCode.Mouse0) && timeBetweenShot>fireRate && bulletsLeft > 0 && state==GunState.none)
        {
            for (int i = 0; i < bulletsPerTap; i++)
            {
                Shoot();
                
            }
            state = GunState.none;
        }

        if (Input.GetKeyDown(KeyCode.R) && state != GunState.reloading && totalBullets > 0 && bulletsLeft < magSize)
        {
            StartReload();
        }

        if (reloadTimer > 0)
        {
            reloadTimer -= Time.deltaTime;
        }
        else if (state == GunState.reloading)
        {
            gunAnimations.SetBool("Reloading", false);
            Reload();
        }

        if (magSize== bulletsLeft && state == GunState.reloading)
        {
            
            
        }

        if (Random.Range(0,1000) == 1)
        {
            gunAnimations.SetTrigger("Idle2");
        }
    }

    void StartReload()
    {
        state = GunState.reloading;
        gunAnimations.SetBool("Reloading", true);
        reloadTimer = reloadTime;
    }

    void Reload()
    {
        
        state = GunState.none;
        int bulletsMissing = magSize - bulletsLeft;
        bulletsLeft = magSize;
        totalBullets -= bulletsMissing;
        if (totalBullets < 0)
        {
            bulletsLeft += totalBullets;
            totalBullets = 0;
        }
    }

    void Shoot()
    {
        float spreadX = Random.Range(-spread, spread);
        float spreadY = Random.Range(-spread, spread);


        Vector3 direction = new Vector3(spreadX, spreadY, 0);
        Quaternion tempRotation = BulletOrigin.transform.rotation;
        BulletOrigin.transform.Rotate(spreadX, spreadY, 0); 

        state = GunState.shooting;
        Instantiate(Projectile, BulletOrigin.position, BulletOrigin.rotation);
        timeBetweenShot = 0;
        bulletsLeft -= bulletsPerTap;


        BulletOrigin.transform.rotation = tempRotation;

    }
}
