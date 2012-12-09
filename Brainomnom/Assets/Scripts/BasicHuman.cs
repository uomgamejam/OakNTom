using UnityEngine;
using System.Collections;

public class BasicHuman: MonoBehaviour {

	public enum basicHumanType { Still, Agg, Cow }
	public basicHumanType type;
	public bool isMoving = false;
	
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
