using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GridSystem : MonoBehaviour
{
    [SerializeField] Transform[] slots;
    [SerializeField] List<Transform> availableSlots;
    [SerializeField] ParticleSystem smokeParticle;
    [SerializeField] int price=50;
    [SerializeField] Button pawnButton;
    [SerializeField] Button rookButton;
    [SerializeField] GameObject shopPanel;
    [SerializeField] ToggleScript toggle;
    [SerializeField] TMP_Text pawnPrice;
    [SerializeField] TMP_Text rookPrice;
    private bool canVibrate;

    public Transform selectedSlot;
    private Vector3 instPos;
    
    public void SpawnPrefab(GameObject prefab)
    {
        var coinAmount=PlayerPrefs.GetInt("Coin");
        canVibrate = toggle.canVibrate;
        if (coinAmount>=price)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].transform.childCount == 0)
                {
                    availableSlots.Add(slots[i]);
                }
            }

            selectedSlot = availableSlots[Random.Range(0, availableSlots.Count)];
            instPos = selectedSlot.position;
            StartCoroutine(SmokeParticle(instPos));
            var prefabInst = Instantiate(prefab, instPos, Quaternion.identity);
            for (int child = 0; child < prefabInst.transform.childCount; child++)
            {
                if (prefabInst.transform.GetChild(child).name=="poof")
                {
                    prefabInst.transform.GetChild(child).GetComponent<AudioSource>().Play();
                }
            }
            if (canVibrate)
            {
                Handheld.Vibrate();
            }
            prefabInst.transform.parent = selectedSlot.transform;
            availableSlots.Clear();
            CoinController.Instance.DecreaseAmountOfCoin(price);
        }
       
    }

    IEnumerator SmokeParticle(Vector3 pos)
    {
        var smokeInst = Instantiate(smokeParticle, pos, Quaternion.identity);
        yield return new WaitForSeconds(0.75f);
        Destroy(smokeInst.gameObject);
    }

    private void Update()
    {
        if (shopPanel.activeInHierarchy)
        {
            var coins = PlayerPrefs.GetInt("Coin");
            if (coins<price)
            {
                pawnButton.interactable = false;
                rookButton.interactable = false;
                pawnPrice.alpha = 0.5f;
                rookPrice.alpha = 0.5f;
            }
        }
    }

}
