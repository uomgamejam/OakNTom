using UnityEngine;
using System.Collections;

public class globals : MonoBehaviour {

	public static int playerTurns = 0;
	
	public static int goldTurns = 10;
	
	public enum teams { Zombies = 0, Humans = 1 }
	public static int teamCount = 2;
	public static teams teamTurn = teams.Zombies;
	
	public static float tileWidth = 30;
	public static float tileHeight = 30;
	public static float tileDiag = Mathf.Sqrt(Mathf.Pow(tileWidth, 2) + Mathf.Pow(tileHeight, 2));
	
	public static float orthSize;
	public static float orthSizeX;
	public static float orthSizeY;
	public static float camRatio;
	
	public enum team { None, Zombie, Human }
	public static team activeTeam = team.None;
	public static OTAnimatingSprite activePerson;
	
	public enum direction { Left, Right, Up, Down, TopLeft, TopRight, DownLeft, DownRight }

	public void Start()
	{
		// gather information from the camera to find the screen size
		globals.camRatio = 1.333f; // 4:3 is 1.333f (800x600) 
		globals.orthSize = Camera.mainCamera.camera.orthographicSize;
		globals.orthSizeX = globals.orthSize * globals.camRatio;
	}

	public void Update() 
	{
	}
	
	public void EndTurn()
	{
		teamTurn = (teams)(((int)teamTurn + 1) % teamCount);
	}
}
