using UnityEngine;


public class Soldier : MonoBehaviour
{
    [SerializeField] private ESoldierTeam _soldierType;

    public ESoldierTeam SoldierType { get => _soldierType; private set => _soldierType = value; }
}
