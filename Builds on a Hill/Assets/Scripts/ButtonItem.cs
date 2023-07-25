using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonItem : MonoBehaviour
{

    public Building building;
    public ResourceManager resourceManager;
    Button button;

    AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (resourceManager.gold < building.goldCost || resourceManager.stone < building.stoneCost ||  
            resourceManager.wood < building.woodCost || resourceManager.gem < building.gemCost)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }

    public void PlayPopSound()
    {
        source.Play();
    }
}
