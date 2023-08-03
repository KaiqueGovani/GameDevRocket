using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenu : MonoBehaviour
{
    [SerializeField] Vector3 CamPosUsername;
    [SerializeField] Vector3 CamPosStart;
    [SerializeField] GameObject MainCamera;
    [SerializeField] GameObject UsernameMenu;
    [SerializeField] GameObject StartMenu;
    [SerializeField] TMP_InputField InputField;
    [SerializeField] TMP_Text placeholder;
    [SerializeField] TMP_Text username;

    void Start() // Start is called before the first frame update
    {
        if(PlayerPrefs.GetString("Username", "") == "") // If there is no username saved
        {
            Debug.Log("Previous Username Not Found!");
            GetUsername();
        }
        // If there is a username saved
        username.text = $"Hi, {PlayerPrefs.GetString("Username")}!";
    }

    void Update() // Update is called once per frame
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync("Game"); // Load the game scene       
    }

    public void QuitGame()
    {
        Application.Quit(); // Quit the game
    }

    public void SetUsername()
    {
        string usernameInput = InputField.text;
        if (CheckUsername(usernameInput))
        {
            // Save the username in PlayerPrefs
            PlayerPrefs.SetString("Username",usernameInput);
            PlayerPrefs.Save();
            // Go to the main menu
            username.text = $"Hi, {PlayerPrefs.GetString("Username")}!";
            GoToMenu();
        }
    }

    void GetUsername()
    {
        // Go to the username menu
        StartMenu.SetActive(false);
        MainCamera.transform.position = CamPosUsername;
        UsernameMenu.SetActive(true);
    }

    bool CheckUsername(string user) // Check if the username is valid
    {
        if (user.Length < 3 || user.Length > 15) // If the username is too short or too long
        {
            InputField.text = "";
            placeholder.text = "Invalid Username!";
            return false;
        } 

        // If the username is valid
        Debug.Log("Valid Username. Saving in PlayerPrefs!");
        return true;
    }

    void GoToMenu()
    {
        // Go to the main menu
        UsernameMenu.SetActive(false);
        MainCamera.transform.position = CamPosStart;
        StartMenu.SetActive(true);
    }
}
