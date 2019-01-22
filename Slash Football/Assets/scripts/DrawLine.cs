using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class DrawLine : MonoBehaviour  {
	private LineRenderer line;
	private bool isMousePressed;

	private GameObject lineObject;
	private float p1limit = Screen.width/3.5f;  // player 1 line length
	private float p2limit = Screen.width/3.5f;  // player 2 line length 
	private List<Vector3> pointsList;
	private Vector3 mousePos;
	private Vector3 startPos, endPos;
	public float lineSize = 0.08f;
	public LineTextureMode tm = LineTextureMode.Stretch;


	void Update () {
		//Debug.Log (Vector3.Distance (startPos, endPos));
		// If mouse button down, remove old line and set its color to green
		if(Input.GetMouseButtonDown(0)){
			startPos = Input.mousePosition;
			isMousePressed = true;
			newLine();
		}
		else if(Input.GetMouseButtonUp(0)){
			isMousePressed = false;
		}
		// Drawing line when mouse is moving(presses)
		if(isMousePressed){
			mousePos   = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mousePos.z = 0;
			endPos = Input.mousePosition;
			if(Input.mousePosition.y > 166) { //player 1
				if (Vector3.Distance (startPos, endPos) > p1limit) // Make it different for p1 and p2 and change it to a variable
					isMousePressed = false;}
			else  	{						// player 2
				if (Vector3.Distance (startPos, endPos) > p2limit) // Make it different for p1 and p2 and change it to a variable
					isMousePressed = false;}
			
			if(!pointsList.Contains(mousePos)){
				pointsList.Add(mousePos);
				line.SetVertexCount(pointsList.Count);
				line.SetPosition(pointsList.Count - 1, (Vector3)pointsList[pointsList.Count - 1]);
                Vector3 point1 = new Vector3();
                Vector3 point2 = new Vector3();
                try
                {
                    point1 = pointsList[pointsList.Count - 2];
                    point2 = pointsList[pointsList.Count - 1];
                }
                catch (Exception e) {

                }

				GameObject obj = new GameObject("Collider");
				obj.transform.position = (point1 + point2) / 2;
				obj.transform.right = (point2 - point1).normalized;

				BoxCollider2D boxCollider = obj.AddComponent<BoxCollider2D>();
				boxCollider.size = new Vector3((point2 - point1).magnitude, lineSize, lineSize);

				obj.transform.parent = lineObject.transform;
				Destroy (obj,1.0f);
			}
		}
	}

	void newLine(){
		
		lineObject = new GameObject();
		lineObject.name = "Line";
		lineObject.transform.parent = gameObject.transform;
		line = lineObject.AddComponent<LineRenderer>();
		//line.textureMode = tm;  // check how its used on google
		line.material =  new Material(Shader.Find("Sprites/Default"));
		line.SetVertexCount(400);
		line.numCornerVertices = 400;
		line.numCapVertices = 50;
		line.positionCount = 100;
		line.SetWidth(lineSize, lineSize);
        //line.loop = true;
        //if(Input.mousePosition.y > Screen.height/2)  //player 1
        //	line.SetColors(Color.red, Color.yellow);
        //else  							// player 2
        //	line.SetColors(Color.blue, Color.green);
        line.SetColors(Color.black,Color.black);
		line.useWorldSpace = true;
		pointsList = new List<Vector3>();
		Destroy (line,1.0f);
	}
}