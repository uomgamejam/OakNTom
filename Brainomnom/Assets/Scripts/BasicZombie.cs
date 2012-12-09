using UnityEngine;
using System.Collections;

public class BasicZombie: MonoBehaviour {

	public bool isMoving = false;
	public bool isActive = false;
	public enum actionType { None, Turn, Move, Attack }
	public actionType action = actionType.None;
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

	public void Update()
	{
		float left = transform.position.x;
		float top = transform.position.y;
		
		// If the mouse is held down anywhere onscreen and it's zombies' turn.
		if (Input.GetMouseButtonDown(0) && globals.teamTurn == globals.teams.Zombies)
		{
			// Check if mouseclick is within 3 by 3 grid surrounding this zombie's tile.
			Rect tempRect = new Rect(left - globals.tileWidth, top + globals.tileHeight, globals.tileWidth * 3, globals.tileHeight * 3);
			if (tempRect.Contains(Input.mousePosition))
			{
				// Check if the centre tile is clicked.
				tempRect = new Rect(left, top, globals.tileWidth, globals.tileHeight);
				if	(tempRect.Contains(Input.mousePosition))
				{
					action = actionType.None;
					if (!isActive)
					{
						if (globals.activePerson != null)
							if (globals.activePerson.GetComponent<BasicZombie>() != null)
								globals.activePerson.GetComponent<BasicZombie>().isActive = false;
							else if (globals.activePerson.GetComponent<BasicHuman>() != null)
								globals.activePerson.GetComponent<BasicHuman>().isActive = false;
						globals.activePerson = GetComponent<OTAnimatingSprite>();
						isActive = true;
					}
				}
				else if (isActive)
				{	
					tempRect = new Rect(left-globals.tileWidth, top + globals.tileHeight, globals.tileWidth, globals.tileHeight);
					Rect tempRect1 = new Rect(left, top + globals.tileHeight, globals.tileWidth, globals.tileHeight);
					Rect tempRect2 = new Rect(left + globals.tileWidth, top + globals.tileHeight, globals.tileWidth, globals.tileHeight);
					Rect tempRect3 = new Rect(left + globals.tileWidth, top, globals.tileWidth, globals.tileHeight);
					Rect tempRect4 = new Rect(left + globals.tileWidth, top - globals.tileHeight, globals.tileWidth, globals.tileHeight);
					Rect tempRect5 = new Rect(left, top-globals.tileHeight, globals.tileWidth, globals.tileHeight);
					Rect tempRect6 = new Rect(left - globals.tileWidth, top - globals.tileHeight, globals.tileWidth, globals.tileHeight);
					Rect tempRect7 = new Rect(left - globals.tileWidth, top + globals.tileHeight, globals.tileWidth, globals.tileHeight);
 					// Check if mouseclick is in 8 adjacent tiles.
					if (tempRect.Contains(Input.mousePosition))
						if (currentDirection == globals.direction.TopLeft)
							action = actionType.Move;
						else
						{
							action = actionType.Turn;
						  	newDirection = globals.direction.TopLeft;
						}
					else if	(tempRect1.Contains(Input.mousePosition))
						if (currentDirection == globals.direction.Top)
							action = actionType.Move;
						else
						{
							action = actionType.Turn;
						  	newDirection = globals.direction.Top;
						}
					else if	(tempRect2.Contains(Input.mousePosition))
						if (currentDirection == globals.direction.TopRight)
							action = actionType.Move;
						else
						{
							action = actionType.Turn;
						  	newDirection = globals.direction.TopRight;
						}
					else if	(tempRect3.Contains(Input.mousePosition))
						if (currentDirection == globals.direction.Right)
							action = actionType.Move;
						else
						{
							action = actionType.Turn;
						  	newDirection = globals.direction.Right;
						}
					else if	(tempRect4.Contains(Input.mousePosition))
						if (currentDirection == globals.direction.BottomRight)
							action = actionType.Move;
						else
						{
							action = actionType.Turn;
						  	newDirection = globals.direction.BottomRight;
						}
					else if	(tempRect5.Contains(Input.mousePosition))
						if (currentDirection == globals.direction.Bottom)
							action = actionType.Move;
						else
						{
							action = actionType.Turn;
						  	newDirection = globals.direction.Bottom;
						}
					else if	(tempRect6.Contains(Input.mousePosition))
						if (currentDirection == globals.direction.BottomLeft)
							action = actionType.Move;
						else
						{
							action = actionType.Turn;
						  	newDirection = globals.direction.BottomLeft;
						}
					else if (tempRect7.Contains(Input.mousePosition))
						if (currentDirection == globals.direction.Left)
							action = actionType.Move;
						else
						{
							action = actionType.Turn;
						  	newDirection = globals.direction.Left;
						}
				}
			}
		}
	} // Update
	
	public void Move()
	{
		float width = globals.tileWidth;
		float height = globals.tileHeight;
		Vector3 vecPos;
		switch (currentDirection)
		{
		case globals.direction.Left:
			vecPos = new Vector3(transform.position.x - width, transform.position.y, transform.position.z);
			iTween.MoveTo(gameObject, vecPos, 2);
			break;
		case globals.direction.Right:
			vecPos = new Vector3(transform.position.x + width, transform.position.y, transform.position.z);
			iTween.MoveTo(gameObject, vecPos, 2);
			break;	
		case globals.direction.Top:
			vecPos = new Vector3(transform.position.x, transform.position.y + height, transform.position.z);
			iTween.MoveTo(gameObject, vecPos, 2);
			break;
		case globals.direction.Bottom:
			vecPos = new Vector3(transform.position.x, transform.position.y - height, transform.position.z);
			iTween.MoveTo(gameObject, vecPos, 2);
			break;	
		case globals.direction.TopLeft:
			vecPos = new Vector3(transform.position.x - width, transform.position.y + height, 
									 transform.position.z);
			iTween.MoveTo(gameObject, vecPos, 2);
	
			break;
		case globals.direction.TopRight:
			vecPos = new Vector3(transform.position.x + width, transform.position.y + height, 
									 transform.position.z);
			iTween.MoveTo(gameObject, vecPos, 2);
			break;	
		case globals.direction.BottomLeft:
			vecPos = new Vector3(transform.position.x - width, transform.position.y - height, 
									 transform.position.z);
			iTween.MoveTo(gameObject, vecPos, 2);
			break;
		case globals.direction.BottomRight:
			vecPos = new Vector3(transform.position.x + width, transform.position.y - height, 
									 transform.position.z);
			iTween.MoveTo(gameObject, vecPos, 2);
			break;
		}
	} // Move
	
	public bool ValidMove(globals.direction direction)
	{
		float width = globals.tileWidth;
		float height = globals.tileHeight;
		Vector3 vecPos;
		switch (direction)
		{
		case globals.direction.Left:
			vecPos = new Vector3(transform.position.x - width, transform.position.y, transform.position.z);
			break;
		case globals.direction.Right:
			vecPos = new Vector3(transform.position.x + width, transform.position.y, transform.position.z);
			break;	
		case globals.direction.Top:
			vecPos = new Vector3(transform.position.x, transform.position.y + height, transform.position.z);
			break;
		case globals.direction.Bottom:
			vecPos = new Vector3(transform.position.x, transform.position.y - height, transform.position.z);
			break;	
		case globals.direction.TopLeft:
			vecPos = new Vector3(transform.position.x - width, transform.position.y + height, 
									 transform.position.z);
	
			break;
		case globals.direction.TopRight:
			vecPos = new Vector3(transform.position.x + width, transform.position.y + height, 
									 transform.position.z);
			break;	
		case globals.direction.BottomLeft:
			vecPos = new Vector3(transform.position.x - width, transform.position.y - height, 
									 transform.position.z);
			break;
		case globals.direction.BottomRight:
			vecPos = new Vector3(transform.position.x + width, transform.position.y - height, 
									 transform.position.z);
			break;
		default:
			vecPos = new Vector3(transform.position.x + width, transform.position.y - height, 
									 transform.position.z);
			break;
		}
		
		Collider[] objects = Physics.OverlapSphere(vecPos, (Mathf.Min(width, height) / 3));
		if (objects.Length == 0)
			return false;
		if (objects.Length == 1)
		{
			OTSprite sprite = objects[0].GetComponent<OTSprite>();
			if (sprite.tag.Equals("ground"))
				return true;
			else
				return false;
		}
		if (objects.Length == 2)
		{
			OTSprite[] sprites = objects[0].GetComponents<OTSprite>();
			if (sprites[0].tag.Equals("zombie") || sprites[1].tag.Equals("zombie"))
				return false;
			else
				return true;
		}
		return true;
	} // ValidMove
}
