﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

    [SerializeField] private float MinSpeed = 2;
    [SerializeField] private float ImpactForce = 10f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 speed = rb.velocity;

        if (MinSpeed > speed.magnitude)
        {
            speed = rb.velocity.normalized * MinSpeed;
            speed.y = rb.velocity.y;
            rb.velocity = speed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector3 dir = collision.contacts[0].point - transform.position;
            dir = -dir.normalized;
            rb.velocity = Vector3.zero;

            rb.AddForce(dir * ImpactForce, ForceMode.Impulse);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 dir = collision.contacts[0].point - transform.position;
            dir = -dir.normalized;

            rb.velocity = Vector3.zero;
            rb.AddForce(dir * ImpactForce * 3, ForceMode.Impulse);
        }
    }
}
