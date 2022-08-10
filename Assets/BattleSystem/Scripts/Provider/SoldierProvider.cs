using System.Collections.Generic;
using UnityEngine;

public class SoldierProvider : MonoBehaviour
{
    private static SoldierProvider _instance;

    public static SoldierProvider Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<SoldierProvider>();
            }
            return _instance;
        }
    }    

    private Soldier[] _soldiers;

    public Soldier[] GetSoldiers()
    {
        _soldiers = FindObjectsOfType<Soldier>();
        return _soldiers;
    }
 
    public List<Soldier> GetSoldiersBySoldierType(ESoldierTeam soldierType, bool excludeDeadSoldiers)
    {
        List<Soldier> soldierBySoldierType = new List<Soldier>();

        foreach (Soldier soldier in GetSoldiers())
        {
            if (soldier.SoldierType == soldierType)
            {
                if (soldier.GetComponent<Damagable>().IsDead && excludeDeadSoldiers) continue;

                soldierBySoldierType.Add(soldier);
            }
        }

        return soldierBySoldierType;
    }
}
