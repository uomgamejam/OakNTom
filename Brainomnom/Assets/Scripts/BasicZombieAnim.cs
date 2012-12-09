using UnityEngine;
using System.Collections;

public class BasicZombieAnims : MonoBehaviour {

	OTAnimatingSprite mySprite;
	public enum basicZombieAnim { None, Still, Move }
	basicZombieAnim currentAnim = basicZombieAnim.None;
	BasicZombie mainZombieScript;
	
	// Use this for initialization
	void Start() 
	{
		mySprite = GetComponent<OTAnimatingSprite>();
		mainZombieScript = GetComponent<BasicZombie>();
	}
	
	void Update() 
	{
		// Are we moving
		if (!mainZombieScript.isMoving && currentAnim != basicZombieAnim.Still)
		{
			currentAnim = basicZombieAnim.Still;
			mySprite.Play("still");
		}
		if (mainZombieScript.isMoving && currentAnim != basicZombieAnim.Move)
		{
			currentAnim = basicZombieAnim.Move;
			mySprite.Play("move");
		}
	}
}
