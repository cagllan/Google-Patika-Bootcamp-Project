using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Drag : MonoBehaviour
{
    Vector3 dist;
    Vector3 startPos;
    float posX;
    float posZ;
    float posY;
    [SerializeField] GameObject[] slots;
    [SerializeField] float[] distances;
    [SerializeField] int nearestDistanceElement;
    [SerializeField] GameObject upgradedPrefab;
    [SerializeField] Transform fightPanel;
    [SerializeField] ParticleSystem poofParticle;
    [SerializeField] ToggleScript toggle;
    [SerializeField] AudioSource poof;

    private void Awake()
    {
        toggle=GameObject.FindGameObjectWithTag("Zemin").GetComponent<ToggleScript>();
        slots = GameObject.FindGameObjectsWithTag("Slot");
        fightPanel = GameObject.Find("Canvas").transform.GetChild(0);
    }
    void OnMouseDown()
    {
        startPos = transform.position;
        dist = Camera.main.WorldToScreenPoint(transform.position);
        posX = Input.mousePosition.x - dist.x;
        posY = Input.mousePosition.y - dist.y;
        posZ = Input.mousePosition.z - dist.z;
    }

    void OnMouseDrag()
    {
        float disX = Input.mousePosition.x - posX;
        float disY = Input.mousePosition.y - posY;
        float disZ = Input.mousePosition.z - posZ;
        Vector3 lastPos = Camera.main.ScreenToWorldPoint(new Vector3(disX, disY, disZ));
        transform.position = new Vector3(lastPos.x, startPos.y, lastPos.z);

    }

    private void OnMouseUp()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            distances[i] = Vector3.Distance(slots[i].transform.position, transform.position);
        }

        nearestDistanceElement = Array.IndexOf(distances, distances.Min());
        if (slots[nearestDistanceElement].transform.childCount == 0)
        {
            transform.position = slots[nearestDistanceElement].transform.position;
            transform.parent = slots[nearestDistanceElement].transform;
        }
        else
        {
            if (slots[nearestDistanceElement].transform.GetChild(0).tag == gameObject.tag && slots[nearestDistanceElement].transform != transform.parent && upgradedPrefab != null&&!fightPanel.gameObject.activeInHierarchy)
            {
                Destroy(slots[nearestDistanceElement].transform.GetChild(0).gameObject);
                Destroy(gameObject);
                var upgradedInst = Instantiate(upgradedPrefab, slots[nearestDistanceElement].transform.position, Quaternion.identity);
                upgradedInst.transform.parent = slots[nearestDistanceElement].transform;
                for (int i = 0; i < upgradedPrefab.transform.childCount; i++)
                {
                    if (upgradedInst.transform.GetChild(i).name== "CFX_MagicPoof")
                    {
                        upgradedInst.transform.GetChild(i).GetComponent<AudioSource>().Play();
                        poofParticle = upgradedInst.transform.GetChild(i).GetComponent<ParticleSystem>();
                        poofParticle.Play();
                        
                    }
                }
                if (toggle.canVibrate)
                    {
                Handheld.Vibrate();
                }
          


            }
            else
            {
                transform.position = transform.parent.position;
            }

        }

    }


    IEnumerator PoofParticle(Vector3 pos)
    {
        var poofInst = Instantiate(poofParticle, pos, Quaternion.identity);
        yield return new WaitForSeconds(0.75f);
        Destroy(poofInst.gameObject);
    }
}
