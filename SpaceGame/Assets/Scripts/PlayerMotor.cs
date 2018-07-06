using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMotor : MonoBehaviour 
{
	private Vector3 moveVector;
	private float speed = 3.5f;
    private float animationDuration = 3.0f;
    private bool isDead = false;
    private float desiredRot;
    public float rotSpeed = 250;
    public float damping = 10;
    public GameObject FTLSkill;
    public BoxCollider playerBox;
    private int ftlLevel;
    private bool buttonPressed = false;
    private float timeLeft = 30;

    private void OnEnable()
    {
        desiredRot = transform.eulerAngles.y;
    }
	void Start () 
	{
        ftlLevel = PlayerPrefs.GetInt("FTLLevel");
        if (PlayerPrefs.GetInt("FTLLevel") > 0)
            FTLSkill.SetActive(true);
        else
            FTLSkill.SetActive(false);
	}
	void Update ()
    {
        if (isDead)
            return;
        if (Time.timeSinceLevelLoad < animationDuration)
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
            return;
                 }
        if (Input.GetMouseButton(0)) 
        {
            if (Input.mousePosition.x < Screen.width / 2) 
                desiredRot += rotSpeed * Time.deltaTime;
            else 
                desiredRot -= rotSpeed * Time.deltaTime;
                 }
        var desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, desiredRot);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, Time.deltaTime * damping);
        if (buttonPressed == true)
        {
            switch (ftlLevel)
            {
                case 1:
                    playerBox.enabled = false;
                    moveVector.z = speed * 2;
                    transform.position += moveVector * (speed * 2) * Time.deltaTime;
                    if (timeLeft < 0)
                    {
                        FTLSkill.SetActive(false);
                        playerBox.enabled = true;
                        buttonPressed = false;
                    }
                    else
                        timeLeft -= 10*Time.deltaTime;
                    return;
                case 2:
                    playerBox.enabled = false;
                    moveVector.z = speed * 2;
                    transform.position += moveVector * (speed * 2) * Time.deltaTime;
                    if (timeLeft < 0)
                    {
                        FTLSkill.SetActive(false);
                        playerBox.enabled = true;
                        buttonPressed = false;
                    }
                    else
                        timeLeft -= 7.5f*Time.deltaTime;
                    return;
                case 3:
                    playerBox.enabled = false;
                    moveVector.z = speed * 2;
                    transform.position += moveVector * (speed * 2) * Time.deltaTime;
                    if (timeLeft < 0)
                    {
                        FTLSkill.SetActive(false);
                        playerBox.enabled = true;
                        buttonPressed = false;
                    }
                    else
                        timeLeft -= 6*Time.deltaTime;
                    return;
                case 4:
                    playerBox.enabled = false;
                    moveVector.z = speed * 2;
                    transform.position += moveVector * (speed * 2) * Time.deltaTime;
                    if (timeLeft < 0)
                    {
                        FTLSkill.SetActive(false);
                        playerBox.enabled = true;
                        buttonPressed = false;
                    }
                    else
                        timeLeft -= 5*Time.deltaTime;
                    return;
                case 5:
                    playerBox.enabled = false;
                    moveVector.z = speed * 2;
                    transform.position += moveVector * (speed * 2) * Time.deltaTime;
                    if (timeLeft < 0)
                    {
                        FTLSkill.SetActive(false);
                        playerBox.enabled = true;
                        buttonPressed = false;
                    }
                    else
                        timeLeft -= 4.3f*Time.deltaTime;
                    return;
                case 6:
                    playerBox.enabled = false;
                    moveVector.z = speed * 2;
                    transform.position += moveVector * (speed * 2) * Time.deltaTime;
                    if (timeLeft < 0)
                    {
                        FTLSkill.SetActive(false);
                        playerBox.enabled = true;
                        buttonPressed = false;
                    }
                    else
                        timeLeft -= 3.75f*Time.deltaTime;
                    return;
                case 7:
                    playerBox.enabled = false;
                    moveVector.z = speed * 2;
                    transform.position += moveVector * (speed * 2) * Time.deltaTime;
                    if (timeLeft < 0)
                    {
                        FTLSkill.SetActive(false);
                        playerBox.enabled = true;
                        buttonPressed = false;
                    }
                    else
                        timeLeft -= 3.33f*Time.deltaTime;
                    return;
                case 8:
                    playerBox.enabled = false;
                    moveVector.z = speed * 2;
                    transform.position += moveVector * (speed * 2) * Time.deltaTime;
                    if (timeLeft < 0)
                    {
                        FTLSkill.SetActive(false);
                        playerBox.enabled = true;
                        buttonPressed = false;
                    }
                    else
                        timeLeft -= 3*Time.deltaTime;
                    return;
            }
        }
        else
        {
            moveVector.z = speed;
            transform.position += moveVector * speed * Time.deltaTime;
        }
    }
    public void SetSpeed(float modifier)
    {
        speed = 3.0f + modifier;
    }
    public void Death()
    {
        isDead = true;
        GetComponent<Score>().OnDeath();
    }
    public void FTLButtonPressed()
    {
        buttonPressed = true;
    }
}