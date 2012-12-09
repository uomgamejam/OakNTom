using UnityEngine;
using System.Collections;

public class BasicHuman: MonoBehaviour {

	public enum basicHumanType { Still, Agg, Cow }
	public basicHumanType type;
	public bool isMoving = false;
	public enum actionType { None, Turn, Move, Attack }
	public actionType action = None;
	public globals.direction currentDirection = globals.direction.Top;
	public globals.direction newDirection = globals.direction.Top;
	
	private Transform thisTransform;
	
	void Awake() 
	{
		thisTransform = transform;
		OTAnimatingSprite bluh = GetComponent<OTAnimatingSprite>();
		if (bluh.frameName == "stillhuman")
			type = basicHumanType.Still;
		if (bluh.frameName == "agghuman")
			type = basicHumanType.Agg;
		if (bluh.frameName == "cowhuman")
			type = basicHumanType.Cow;
	}
	
	void Start()
    {
		
    }

	public void Update ()
	{		

	}
}
