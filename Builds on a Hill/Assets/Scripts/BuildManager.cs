using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public GameObject[] buildings;
    public GameObject buildingToPlace;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnClickButton(int index)
    {
        buildingToPlace = buildings[index];
    }
}
