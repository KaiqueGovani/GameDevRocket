using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

#pragma warning disable

public class UI : MonoBehaviour
{
    // Waves
    public TMP_Text waveText;
    public Animator waveTextAnim;

    public GameObject healthBar;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetWaveText(int wave)
    {
        waveText.text = $"Wave {wave}";
        waveTextAnim.Play("Fade", -1, 0f);
    }

    public void UpdateHealhBar(float health)
    {
        healthBar.GetComponent<Slider>().value = health;
    }
}
