using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public GameObject buildingPos;
    public GameObject destructionSound;
    ResourceManager resourceManager;

    public float goldIncome;
    public float stoneIncome;
    public float woodIncome;
    public float gemIncome;

    public float goldCost;
    public float stoneCost;
    public float woodCost;
    public float gemCost;


    public float timeBetweenIncomes;
    float nextIncomeTime;

    // Start is called before the first frame update
    void Start()
    {
        resourceManager = FindObjectOfType<ResourceManager>();
        resourceManager.gold -= goldCost;
        resourceManager.stone -= stoneCost;
        resourceManager.wood -= woodCost;
        resourceManager.gem -= gemCost;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextIncomeTime)
        {
            resourceManager.gold += goldIncome;
            resourceManager.stone += stoneIncome;
            resourceManager.wood += woodIncome;
            resourceManager.gem += gemIncome;
            nextIncomeTime = Time.time + timeBetweenIncomes;
        }
    }

    void OnMouseDown()
    {
        RefundBuilding();
        Instantiate(buildingPos, transform.position, transform.rotation);
        Instantiate(destructionSound, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void RefundBuilding()
    {
        resourceManager.gold += goldCost/2;
        resourceManager.stone += stoneCost/2;
        resourceManager.wood += woodCost/2;
        resourceManager.gem += gemCost/2;
    }
}
