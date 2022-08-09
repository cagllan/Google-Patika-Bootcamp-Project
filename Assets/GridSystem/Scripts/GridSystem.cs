using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    [SerializeField] Transform[] slots;
    [SerializeField] List<Transform> availableSlots;
    [SerializeField] ParticleSystem smokeParticle;
    public Transform selectedSlot;
    private Vector3 instPos;
    
    public void SpawnPrefab(GameObject prefab)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].transform.childCount==0)
            {
                availableSlots.Add(slots[i]);
            }
        }

        selectedSlot = availableSlots[Random.Range(0, availableSlots.Count)];
        instPos = selectedSlot.position;
        StartCoroutine(SmokeParticle(instPos));
        var prefabInst = Instantiate(prefab, instPos, Quaternion.identity);
        prefabInst.transform.parent = selectedSlot.transform;
        availableSlots.Clear();
    }

    IEnumerator SmokeParticle(Vector3 pos)
    {
        var smokeInst = Instantiate(smokeParticle, pos, Quaternion.identity);
        yield return new WaitForSeconds(0.75f);
        Destroy(smokeInst.gameObject);
    }

}
