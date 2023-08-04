using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dan.Main;
using Dan.Models;
using TMPro;

public class LBManager : MonoBehaviour
{

    private string _leaderboardPublicKey = "6a795be7cd50c2f5853653a0b7db6b91232444d6e0ea20abdef00ec3f04ae9fc";
    [SerializeField] TMP_Text[] _entradas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Load() => LeaderboardCreator.GetLeaderboard(_leaderboardPublicKey, OnLBLoaded);

    void OnLBLoaded(Entry[] entries)
    {
        foreach (var entryField in _entradas)
            {
                entryField.text = "";
            }
            
        for (int i = 0; i < _entradas.Length; i++)
            {
                string username = entries[i].Username;

                if(username.Length > 15){
                    username = username.Substring(0, 15);
                }

                _entradas[i].text = $"{entries[i].RankSuffix()}. {username} : {entries[i].Score}";
            }
    }

    public void Submit(string UsernameInput, int playerScore)
    {
        LeaderboardCreator.UploadNewEntry(_leaderboardPublicKey, UsernameInput, playerScore, Callback, ErrorCallback);
    }
    
    public void DeleteEntry()
    {
        LeaderboardCreator.DeleteEntry(_leaderboardPublicKey, Callback, ErrorCallback);
    }

    public void ResetPlayer()
    {
        LeaderboardCreator.ResetPlayer();
    }
    
    private void Callback(bool success)
    {
        if (success)
            Load();
    }
    
    private void ErrorCallback(string error)
    {
        Debug.LogError(error);
    }
}
