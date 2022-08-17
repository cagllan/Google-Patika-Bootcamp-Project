using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDamageParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem _meleeDamageParticle;

    [SerializeField] DamageDealer _damageDealer;

    private void Start() 
    {
        _damageDealer.OnDealDamage += OnDealDamage;
    }

    private void OnDestroy() 
    {
        _damageDealer.OnDealDamage -= OnDealDamage;
    }
    private void OnDealDamage()
    {
        PlayMeleeDamageParticle();
    }

    private void PlayMeleeDamageParticle()
    {
        _meleeDamageParticle.Play();
    }
}
