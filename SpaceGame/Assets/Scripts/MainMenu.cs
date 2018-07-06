using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
    public Text highscoreText;
    public Text creditText;
    private float creditTemp;
    private float creditMainTemp;
    private float creditMain;
	// Use this for initialization
	void Start () 
    {
        //Displays HS, Credits, Joy
        highscoreText.text = ((int)PlayerPrefs.GetFloat("Highscore")).ToString();
        creditText.text = ((int)PlayerPrefs.GetFloat("Credit")).ToString();
        //Credit text adding.
        creditTemp = (int)PlayerPrefs.GetFloat("CreditTemp");
        creditMainTemp = Convert.ToInt32(creditText.text);
        creditMain = creditTemp + creditMainTemp;
        PlayerPrefs.SetFloat("Credit", creditMain);
        PlayerPrefs.SetFloat("CreditTemp", 0);
        creditText.text = ((int)PlayerPrefs.GetFloat("Credit")).ToString();
	}
    public void ToGame()
    {
        SceneManager.LoadScene("SpaceGame");
    }
    public void ToShop()
    {
        SceneManager.LoadScene("TheShop");
    }
}
