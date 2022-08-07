using System;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    [SerializeField] private float _health;

    public float Health {get => _health; private set {_health = value;}}
    public bool IsDead {get; private set;}

    // Event
    public Action<Damagable> OnTookDamage {get;set;}
    public Action<Damagable> OnDied {get;set;}
    
    public void TakeDamage(float damageAmount)
    {       
            if(IsDead) return;
            
            _health -= damageAmount;          

            if(_health <= 0)
            {
                _health = 0;
                IsDead = true;                
                
                if(IsDead)
                {                    
                    Debug.Log(gameObject.name + "Karakter öldü");
                    OnTookDamage?.Invoke(this);
                    OnDied?.Invoke(this);                    
                    return;
                }          
            }
                           
            OnTookDamage?.Invoke(this);
    }

}
