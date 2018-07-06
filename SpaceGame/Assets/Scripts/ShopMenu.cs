using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class ShopMenu : MonoBehaviour 
{
    public Text creditText;

    private void Update()
    {
        creditText.text = ((int)PlayerPrefs.GetFloat("Credit")).ToString();
    }
    public void ChangeToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
