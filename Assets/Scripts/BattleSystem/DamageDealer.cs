using UnityEngine;
using System;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float _damageAmount;
    // [SerializeField] private ParticleSystem _meleeDamageParticle = null;

    public Action OnDealDamage {get;set;}
  
    public void DealDamage(Damagable damagable)
    {
        OnDealDamage?.Invoke();
        damagable.TakeDamage(_damageAmount);
    }
}
