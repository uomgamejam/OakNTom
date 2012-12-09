using UnityEngine;
using System.Collections;

public class BasicZombie: MonoBehaviour {

	public bool isMoving = false;
	public enum actionType { None, Turn, Move, Attack }
	public actionType action = None;
	public globals.direction currentDirection = globals.direction.Top;
	public globals.direction newDirection = globals.direction.Top;
	
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
