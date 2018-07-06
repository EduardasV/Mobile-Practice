using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class FTLStatContainer : MonoBehaviour 
{
    public Text levelText;
    public Text goldCostText;
    private float goldAmnt;

    public Button button;
    private int hpLevel;
    private int hpLevelTemp;
    public Image level1;
    public Image level2;
    public Image level3;
    public Image level4;
    public Image level5;
    public Image level6;
    public Image level7;
    public Image level8;

    void Update()
    {
        hpLevel = (PlayerPrefs.GetInt("FTLLevel"));
        if(hpLevel == 0)
            goldCostText.text = "1000";
        goldAmnt = ((int)PlayerPrefs.GetFloat("Credit"));

        switch (hpLevel)
        {
            case 1:
                levelText.text = "1";
                level1.color = new Color32(0, 180, 70, 255);
                goldCostText.text = "2000";
                break;
            case 2:
                levelText.text = "2"; 
                level2.color = new Color32(0, 180, 70, 255);level1.color = new Color32(0, 180, 70, 255);
                goldCostText.text = "4000";
                break;
            case 3:
                levelText.text = "3";
                level3.color = new Color32(0, 180, 70, 255);level2.color = new Color32(0, 180, 70, 255);level1.color = new Color32(0, 180, 70, 255);
                goldCostText.text = "6000";
                break;
            case 4:
                levelText.text = "4";
                level4.color = new Color32(0, 180, 70, 255);level3.color = new Color32(0, 180, 70, 255);level2.color = new Color32(0, 180, 70, 255);level1.color = new Color32(0, 180, 70, 255);
                goldCostText.text = "8000";
                break;
            case 5:
                levelText.text = "5";
                level5.color = new Color32(0, 180, 70, 255);level4.color = new Color32(0, 180, 70, 255);level3.color = new Color32(0, 180, 70, 255);level2.color = new Color32(0, 180, 70, 255);level1.color = new Color32(0, 180, 70, 255);
                goldCostText.text = "10000";
                break;
            case 6:
                levelText.text = "6";
                level6.color = new Color32(0, 180, 70, 255);level5.color = new Color32(0, 180, 70, 255);level4.color = new Color32(0, 180, 70, 255);level3.color = new Color32(0, 180, 70, 255);level2.color = new Color32(0, 180, 70, 255);level1.color = new Color32(0, 180, 70, 255);
                goldCostText.text = "12000";
                break;
            case 7:
                levelText.text = "7";
                level7.color = new Color32(0, 180, 70, 255);level6.color = new Color32(0, 180, 70, 255);level5.color = new Color32(0, 180, 70, 255);level4.color = new Color32(0, 180, 70, 255);level3.color = new Color32(0, 180, 70, 255);level2.color = new Color32(0, 180, 70, 255);level1.color = new Color32(0, 180, 70, 255);
                goldCostText.text = "14000";
                break;
            case 8:
                levelText.text = "8";
                level8.color = new Color32(0, 180, 70, 255);level7.color = new Color32(0, 180, 70, 255);level6.color = new Color32(0, 180, 70, 255);level5.color = new Color32(0, 180, 70, 255);level4.color = new Color32(0, 180, 70, 255);level3.color = new Color32(0, 180, 70, 255);level2.color = new Color32(0, 180, 70, 255);level1.color = new Color32(0, 180, 70, 255);
                goldCostText.text = "MAX";
                button.interactable = false;
                break;
        }
    }

    public void LevelUp()
    {
        if(Convert.ToInt32(goldCostText.text) <= goldAmnt)
        {
            long moneyMin = Convert.ToInt64(goldCostText.text);
            float money = goldAmnt - moneyMin;
            PlayerPrefs.SetFloat("Credit", money);
            hpLevelTemp = (PlayerPrefs.GetInt("FTLLevel")) + 1;
            PlayerPrefs.SetInt("FTLLevel", hpLevelTemp);
        }
    }
}