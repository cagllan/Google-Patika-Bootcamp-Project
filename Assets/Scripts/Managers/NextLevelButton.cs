using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevelButton : MonoBehaviour
{
    private GameObject formationManagerGO;

    public void FindFormationManager()
    {
        formationManagerGO = GameObject.Find("FormationManager");
        formationManagerGO.GetComponent<FormationManager>().SaveFormation();
    }

}
