using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LBUI : MonoBehaviour
{
    [SerializeField] LBManager _lbManager;

    [SerializeField] GameObject lostTexts;
    [SerializeField] GameObject LBBoardArea;
    [SerializeField] GameObject LBButton;

    private void Start() {
        _lbManager = FindObjectOfType<LBManager>();
    }

    public void SeeLeaderBoards()
    {
        lostTexts.SetActive(false);
        LBButton.SetActive(false);

        LBBoardArea.SetActive(true);

        _lbManager.Load();
    }
    
}
