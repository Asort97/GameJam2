using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Gun: MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float maxShootDistance;
    public float ShootCooldown;
    public float shootCd;
    public bool canShoot;
    
    private void Start()
    {
        shootCd = ShootCooldown;
    }

    public void Shoot()
    {
        RaycastHit hit;

        if(Physics.Raycast(shootPoint.position, transform.TransformDirection(Vector3.forward), out hit, maxShootDistance))
        {
            Debug.DrawRay(shootPoint.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        }
    }

    public virtual void Shooting() {}

    public virtual void Zoom()
    {
    }

    public virtual void Reload()
    {

    }
}
