using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public float score;
    public Collider bola;
    public float multiplier;
    public Color color;
    public AudioManager audioManager;
    public VFXManager vfxManager;
    public ScoreManager scoreManager;

    private MeshRenderer _meshRenderer;
    
    private Renderer _renderer;
    private Animator _animator;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {   
        _renderer.material.SetColor("_Color", color);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == bola)
        {
            audioManager.PlaySFX(collision.transform.position);
            vfxManager.PlayVFX(collision.transform.position);
            scoreManager.AddScore(score);
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;

            _animator.SetTrigger("hit");
        }
    }
}