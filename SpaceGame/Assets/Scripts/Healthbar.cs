using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Healthbar : MonoBehaviour 
{
    public Image currentHP;
    public Text hpText;
    private float hp = 100;
    private float maxHP = 100;
    private float regeneration;
    private int regenLevel;


    private void Start()
    {
        regenLevel = PlayerPrefs.GetInt("HprLevel");
        switch (regenLevel)
        {
            case 1:
                regeneration = 1;
                break;
            case 2:
                regeneration = 1.5f;
                break;
            case 3:
                regeneration = 2;
                break;
            case 4:
                regeneration = 2.5f;
                break;
            case 5:
                regeneration = 3;
                break;
            case 6:
                regeneration = 3.5f;
                break;
            case 7:
                regeneration = 4;
                break;
            case 8:
                regeneration = 5;
                break;
        }
    }
    private void Update()
    {
        UpdateHealthbar();
        if (hp > 0)
        {
            if (hp < maxHP)
            {
                hp += regeneration * Time.deltaTime;
                if (hp > maxHP)
                {
                    hp = maxHP;
                }
            }
        }
    }
    private void UpdateHealthbar()
    {
        float ratio = hp / maxHP;
        currentHP.rectTransform.localScale = new Vector3(ratio, 1, 1);
        hpText.text = (ratio * 100).ToString("0") + '%';
    }
    private void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
            GetComponent<PlayerMotor>().Death();
        }
        UpdateHealthbar();
    }
}
