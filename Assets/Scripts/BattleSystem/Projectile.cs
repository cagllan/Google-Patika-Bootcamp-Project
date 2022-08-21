using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private IEnumerator _destroyMeRoutine;
    [SerializeReference] ESoldierTeam _targetSoldierType;
    
    void Start()
    {
        StartDestroyMeRoutine();
    }

    
    void Update()
    {        
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.forward, 5f * Time.deltaTime);       
    }

    private void StartDestroyMeRoutine()
    {
        StopDestroyMeRoutine();

        _destroyMeRoutine = DestroyMeProgress();
        StartCoroutine(_destroyMeRoutine);

    }

    private void StopDestroyMeRoutine()
    {
        if (_destroyMeRoutine != null)
        {
            StopCoroutine(_destroyMeRoutine);
        }
    }

    private IEnumerator DestroyMeProgress()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        StopDestroyMeRoutine();
    }
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Soldier>() == null) return;

        if(other.gameObject.GetComponent<Soldier>().SoldierType == _targetSoldierType)
        {
            gameObject.GetComponent<DamageDealer>().DealDamage(other.gameObject.GetComponent<Damagable>());
            Destroy(gameObject);
        }
    }

   




}
