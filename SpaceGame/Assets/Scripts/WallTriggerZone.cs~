using UnityEngine;
using System.Collections;

public class WallTriggerZone : MonoBehaviour 
{
    public bool isDamaging;
    public float damage;
    private float minusDmg;
    private int hpLevel;
    private int shdLevel;
    private float hpD;
    private float shdD;

    void Update()
    {
        hpLevel = PlayerPrefs.GetInt("HpLevel");
        shdLevel = PlayerPrefs.GetInt("ShdLevel");
        switch (hpLevel)
        {
            case 0:
                hpD = 0;
                return;
            case 1:
                hpD = 2.5f;
                return;
            case 2:
                hpD = 3;
                return;
            case 3:
                hpD = 3.5f;
                return;
            case 4:
                hpD = 4;
                return;
            case 5:
                hpD = 4.5f;
                return;
            case 6:
                hpD = 5;
                return;
            case 7:
                hpD = 5.5f;
                return;
            case 8:
                hpD = 6;
                return;
        }
        switch (shdLevel)
        {
            case 0:
                shdD = 0;
                return;
            case 1:
                shdD = 2.5f;
                return;
            case 2:
                shdD = 3;
                return;
            case 3:
                shdD = 4;
                return;
            case 4:
                shdD = 5;
                return;
            case 5:
                shdD = 6;
                return;
            case 6:
                shdD = 7;
                return;
            case 7:
                shdD = 8;
                return;
            case 8:
                shdD = 9;
                return;
                 }
    }
    private void OnTriggerEnter(Collider col)
    {
        minusDmg = damage - (hpD + shdD);
        if(col.tag == "Player")
            col.SendMessage((isDamaging)?"TakeDamage":"HealDamage", minusDmg);
    }
}
