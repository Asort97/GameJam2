using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayPhysics : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private Ray _ray;
    public RaycastHit _hit;

    public Ray _Ray
    {

        get
        {

            return _ray;
        }
    }
    
    private void Awake()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void RayPhys()
    {
        _ray = _camera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height /2));
    }

    private void Update()
    {
        RayPhys();
    }
}
