using UnityEngine;
using System.Collections;

public class BasicHumanAnims : MonoBehaviour {

	OTAnimatingSprite mySprite;
	public enum basicHumanAnim { None, StillStill, StillAgg, MoveAgg, StillCow, MoveCow }
	basicHumanAnim currentAnim = basicHumanAnim.None;
	BasicHuman mainHumanScript;
	
	// Use this for initialization
	void Start() 
	{
		mySprite = GetComponent<OTAnimatingSprite>();
		mainHumanScript = GetComponent<BasicHuman>();
	}
	
	void Update() 
	{
		// What type are we and are we moving
		if (mainHumanScript.type == BasicHuman.basicHumanType.Still && currentAnim != basicHumanAnim.StillStill)
		{
			currentAnim = basicHumanAnim.StillStill;
			mySprite.Play("stillhuman_still");
		}
		if (mainHumanScript.type == BasicHuman.basicHumanType.Agg && !mainHumanScript.isMoving && currentAnim != basicHumanAnim.StillAgg)
		{
			currentAnim = basicHumanAnim.StillAgg;
			mySprite.Play("agghuman_still");
		}
		if (mainHumanScript.type == BasicHuman.basicHumanType.Agg && mainHumanScript.isMoving && currentAnim != basicHumanAnim.MoveAgg)
		{
			currentAnim = basicHumanAnim.MoveAgg;
			mySprite.Play("agghuman_move");
		}
		if (mainHumanScript.type == BasicHuman.basicHumanType.Cow && !mainHumanScript.isMoving && currentAnim != basicHumanAnim.StillCow)
		{
			currentAnim = basicHumanAnim.StillCow;
			mySprite.Play("cowhuman_still");
		}
		if (mainHumanScript.type == BasicHuman.basicHumanType.Cow && mainHumanScript.isMoving && currentAnim != basicHumanAnim.MoveCow)
		{
			currentAnim = basicHumanAnim.MoveCow;
			mySprite.Play("cowhuman_move");
		}
	}
}
