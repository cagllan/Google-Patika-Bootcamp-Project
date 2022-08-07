using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float _damageAmount;
  
    public void DealDamage(Damagable damagable)
    {
        damagable.TakeDamage(_damageAmount);
    }
}
