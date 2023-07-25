using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    public float gold;
    public float stone;
    public float wood;
    public float gem;


    public TMP_Text goldText;
    public TMP_Text stoneText;
    public TMP_Text woodText;
    public TMP_Text gemText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = gold.ToString();
        stoneText.text = stone.ToString();
        woodText.text = wood.ToString();
        gemText.text = gem.ToString();
    }
}
