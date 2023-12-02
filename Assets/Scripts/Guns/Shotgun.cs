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
        Shoot();
        Zoom();
    }
}
