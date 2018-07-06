using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour 
{
    private float score = 0.0f;

    private float difficultyLevel = 1.0f;
    private int maxDifficultyLevel = 6;
    private int scoreToNextLevel = 10;
    private bool isDead = false;

    public Text scoreText;
    public DeathMenu deathMenu;

	// Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (isDead)
            return;
        if (score >= scoreToNextLevel)
            LevelUp();
        score += Time.deltaTime * difficultyLevel;
        scoreText.text = ((int)score).ToString();
	}
    void LevelUp()
    {
        if (difficultyLevel == maxDifficultyLevel)
            return;
        
        scoreToNextLevel *= 2;
        difficultyLevel++;

        GetComponent<PlayerMotor>().SetSpeed(difficultyLevel/2);
    }
    public void OnDeath()
    {
        isDead = true;
        if(PlayerPrefs.GetFloat("Highscore") < score)
            PlayerPrefs.SetFloat("Highscore", score);
        PlayerPrefs.SetFloat("CreditTemp", score);
        deathMenu.ToggleDeathMenu(score);
    }
}