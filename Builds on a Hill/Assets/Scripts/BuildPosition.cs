using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPosition : MonoBehaviour
{
    BuildManager buildManager;
    // Start is called before the first frame update
    void Start()
    {
        buildManager = FindObjectOfType<BuildManager>();
        //buildManager = GameObject.Find("BuildManager").GetComponent<BuildManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() 
    {
        if(buildManager.buildingToPlace != null)
        {
            Instantiate(buildManager.buildingToPlace, transform.position, transform.rotation);
            buildManager.buildingToPlace = null;
            Destroy(gameObject);
        }
    }
}
