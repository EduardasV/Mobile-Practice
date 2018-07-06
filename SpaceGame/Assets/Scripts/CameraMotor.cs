using UnityEngine;
using System.Collections;

public class CameraMotor : MonoBehaviour 
{
	//main camera
    private Transform lookAt;
	private Vector3 startOffset;
	private Vector3 moveVector;
	//beginning camera
	private float transition = 0.0f;
	private float animationDuration = 3.0f;
	private Vector3 animationOffset = new Vector3(0, 4, 5);

    
	// Use this for initialization
	void Start () 
    {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
		startOffset = transform.position - lookAt.position;
	}
	void Update () 
    {
		moveVector = lookAt.position + startOffset;
		moveVector.x = 0;
		moveVector.y = Mathf.Clamp(moveVector.y, 2, 7);

		if (transition > 3.0f)
		{
			transform.position = moveVector;
		}
		else
		{
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
            transition += Time.deltaTime * 1 / animationDuration;
            transform.LookAt(lookAt.position + Vector3.up);
		}
	}
}
