using UnityEngine;
using System.Collections;

public class BasicZombie: MonoBehaviour {

	public bool isMoving = false;
	
	private Transform thisTransform;
	
	void Awake() 
	{
		thisTransform = transform;
	}
	
	void Start()
    {
		
    }

	public void Update ()
	{		

	}
}
