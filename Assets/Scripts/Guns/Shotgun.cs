using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shotgun : Gun
{
    [SerializeField] private float spreadAngle;
    [SerializeField] private float numberOfShots;


    private void Update()
    {
        Shooting();
        Zoom();
    }

    public override void Shooting()
    {
        if(shootCd <= 0f)
        {
            if(InputManager.Instance.PlayerLeftMouse())
            {
                for (int i = 0; i < numberOfShots; i++)
                {
                    float randomAngleX = Random.Range(-spreadAngle, spreadAngle);
                    float randomAngleY = Random.Range(-spreadAngle, spreadAngle);

                    Vector3 direction = Quaternion.Euler(randomAngleX, randomAngleY, 0) * transform.TransformDirection(Vector3.forward);

                    RaycastHit hitInfo;

                    if (Physics.Raycast(centerOfCamera, direction, out hitInfo, maxShootDistance))
                    {
                        Instantiate(shotHolePrefab, hitInfo.point, Quaternion.identity);
                        Debug.DrawRay(shootPoint.position, direction * hitInfo.distance, Color.yellow);
                    }
                }

                Debug.Log($"Shooting");
                shootCd = ShootCooldown;
            }            
        }
        else
        {
            shootCd -= Time.deltaTime;
        }
    }
}
