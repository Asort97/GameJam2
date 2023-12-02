using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Gun: MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float ShootCooldown;
    public float shootCd;
    public bool canShoot;
    
    private void Start()
    {
        shootCd = ShootCooldown;
    }

    public virtual void Shoot()
    {
        if(shootCd <= 0f)
        {
            if(InputManager.Instance.PlayerLeftMouse())
            {
                Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

                shootCd = ShootCooldown;
            }            
        }
        else
        {
            shootCd -= Time.deltaTime;
        }
    }

    public virtual void Zoom()
    {
    }

    public virtual void Reload()
    {

    }
}
