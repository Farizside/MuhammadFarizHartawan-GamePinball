using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float maxSpeed;

    private Rigidbody _rig;

    private void Start()
    {
        _rig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_rig.velocity.magnitude > maxSpeed)
        {
            _rig.velocity = _rig.velocity.normalized * maxSpeed;
        }
    }
}
