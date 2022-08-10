using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private IEnumerator _destroyMe;
    [SerializeReference] ESoldierTeam _targetSoldierType;
    
    void Start()
    {
        StartDestroyMeRoutine();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.forward, 5f * Time.deltaTime);
       
    }

    private void StartDestroyMeRoutine()
    {
        StopDestroyMeRoutine();

        _destroyMe = DestroyMeProgress();
        StartCoroutine(_destroyMe);

    }

    private void StopDestroyMeRoutine()
    {
        if (_destroyMe != null)
        {
            StopCoroutine(_destroyMe);
        }
    }

    private IEnumerator DestroyMeProgress()
    {

        yield return new WaitForSeconds(5);
        Destroy(gameObject);

    }

    private void OnDestroy()
    {
        StopDestroyMeRoutine();
    }
   

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Soldier>().SoldierType == _targetSoldierType)
        {
            gameObject.GetComponent<DamageDealer>().DealDamage(other.gameObject.GetComponent<Damagable>());
            Destroy(gameObject);
        }
    }

   




}
