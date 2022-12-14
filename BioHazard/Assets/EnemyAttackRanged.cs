using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackRanged : MonoBehaviour
{
    public enum GunState
    {
        none, shooting, reloading
    }
    public bool fireMode = false;
    public float damage, fireRate, spread, reloadTime;
    public int magSize, bulletsPerTap, bulletsLeft, totalBullets;
    public bool autoFire;
    public GunState state = GunState.none;

    float timeBetweenShot;
    float reloadTimer;
    Vector3 spreadDirection;

    public GameObject Projectile;
    public Transform BulletOrigin;

    public void Update()
    {
        timeBetweenShot += Time.deltaTime;
        if (bulletsLeft == 0 && totalBullets > 0 && bulletsLeft < magSize)
        {
            StartReload();
        }
        if (timeBetweenShot > fireRate)
        {
            if (fireMode)
            {
                Shoot();
                fireMode = false;
            }
        }
        
        if (reloadTimer > 0)
        {
            reloadTimer -= Time.deltaTime;
        }
        else if (state == GunState.reloading)
        {
            Reload();
        }
    }

    void Shoot()
    {
        float spreadX = Random.Range(-spread, spread);
        float spreadY = Random.Range(-spread, spread);


        //Vector3 direction = new Vector3(spreadX, spreadY, 0);
        //Quaternion tempRotation = BulletOrigin.transform.rotation;
        //BulletOrigin.transform.Rotate(spreadX, spreadY, 0);

        state = GunState.shooting;
        Instantiate(Projectile, BulletOrigin.position, BulletOrigin.rotation);
        timeBetweenShot = 0;
        bulletsLeft -= bulletsPerTap;


        //BulletOrigin.transform.rotation = tempRotation;

    }

    void StartReload()
    {
        state = GunState.reloading;
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
}
