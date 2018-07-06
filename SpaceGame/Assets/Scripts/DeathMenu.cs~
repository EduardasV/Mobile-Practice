using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class DeathMenu : MonoBehaviour 
{
    public Text scoreText;
    public Text creditText;
    public Image backgroundImage;
    private bool isShown = false;
    private float transition = 0.0f;
    private float goldAmnt;
    private float creditTemp;
    private float creditMain;

	// Use this for initialization
	void Start () 
    {
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!isShown)
            return;
        transition += Time.deltaTime;
        backgroundImage.color = Color.Lerp(new Color(0,0,0,0),Color.black,transition);
	}
    public void ToggleDeathMenu(float score)
    {
        gameObject.SetActive(true);
        scoreText.text = ((int)score).ToString();
        if (score / 10 > 0)
            creditText.text = ((int)score / 10).ToString();
        else
            creditText.text = ((int)0).ToString();
        isShown = true;
    }
    public void Restart()
    {
        goldAmnt = ((int)PlayerPrefs.GetFloat("Credit"));
        creditTemp = (int)PlayerPrefs.GetFloat("CreditTemp");
        creditMain = creditTemp + goldAmnt;
        PlayerPrefs.SetFloat("Credit", creditMain);
        PlayerPrefs.SetFloat("CreditTemp", 0);
        creditText.text = ((int)PlayerPrefs.GetFloat("Credit")).ToString();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ChangeMenu()
    {
        SceneManager.LoadScene("Menu");

    }
}
