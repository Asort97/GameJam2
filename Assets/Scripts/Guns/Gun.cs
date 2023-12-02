using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Gun: MonoBehaviour
{
    public Transform shootPoint;
    [SerializeField] private GameObject bulletPrefab;
    public GameObject shotHolePrefab;
    public float maxShootDistance;
    public float ShootCooldown;
    public float shootCd;
    public bool canShoot;
    
    private void Start()
    {
        shootCd = ShootCooldown;
    }

    public virtual void Shooting() {}

    public virtual void Zoom()
    {
    }

    public virtual void Reload()
    {

    }
}
