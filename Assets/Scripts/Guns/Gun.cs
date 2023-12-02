using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Gun: MonoBehaviour
{
    public Transform shootPoint;
    [SerializeField] private GameObject bulletPrefab;
    public Vector3 centerOfCamera;
    public GameObject shotHolePrefab;
    public float maxShootDistance;
    public float ShootCooldown;
    public float shootCd;
    public bool canShoot;
    
    private void Start()
    {
        centerOfCamera = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
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
