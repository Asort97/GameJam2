using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    private void Start()
    {
        
    }

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
                Shoot();
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
