using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererAI : MonoBehaviour {
	private Vector3 start,end;
	public static bool ballGoesUp = true;
	public bool hard = false;
	private float yAxisınterval = 3.0f;
	private float xAxisınterval = 2.0f;
	public float lineSize;

	// Use this for initialization
	void Start () {
		ballGoesUp = true;
		Debug.Log (Screen.height);
	}
	
	// Update is called once per frame
	void Update () {
		if(!(menuController.isMultiplayer)){
		if (!hard) { //if easy or medium
			lineSize = 0.1f;
			yAxisınterval = 3.0f;
			xAxisınterval = 2.0f;
			if (gameObject.transform.position.y > 4 && ballGoesUp) {
				float startX = Random.Range (1.3f, xAxisınterval);
				start.x = gameObject.transform.position.x - startX;
				float endX = Random.Range (1.3f, xAxisınterval);
				end.x = gameObject.transform.position.x + endX;
				float startY = Random.Range (1.7f, yAxisınterval);
				start.y = gameObject.transform.position.y + startY;
				float endY = Random.Range (1.7f, yAxisınterval);
				end.y = gameObject.transform.position.y + endY;
				drawLine (start, end, Color.black, Color.black, 1.0f);
				ballGoesUp = false;
			}
		} else { //if hard
			yAxisınterval = 0.9f;
			xAxisınterval = 0.8f;
			lineSize = 0.05f;
			if (gameObject.transform.position.y > 2.3f && ballGoesUp) {
				float startX = Random.Range (0.3f, xAxisınterval);
				start.x = gameObject.transform.position.x - startX;
				float endX = Random.Range (0.3f, xAxisınterval);
				end.x = gameObject.transform.position.x + endX;
				float startY = Random.Range (0.3f, yAxisınterval);
				start.y = gameObject.transform.position.y + startY;
				float endY = Random.Range (0.3f, yAxisınterval);
				end.y = gameObject.transform.position.y + endY;
				drawLine (start, end, Color.black, Color.black, 1.0f);
				ballGoesUp = false;
			}
		}
	}
	}

	void drawLine(Vector3 start, Vector3 end, Color colStart,Color colEnd, float duration ){
		GameObject myLine = new GameObject ();
		myLine.transform.position = start;
		myLine.AddComponent<LineRenderer> ();
		LineRenderer lr = myLine.GetComponent<LineRenderer> ();
		lr.material = new Material(Shader.Find("Sprites/Default"));
		lr.SetColors (colStart,colEnd);
		lr.SetWidth (lineSize, lineSize);
		lr.SetPosition (0, start);
		lr.SetPosition (1, end);
		GameObject.Destroy (myLine, duration);
		GameObject obj = new GameObject("SubCollider");
		obj.transform.position = (start + end) / 2;
		obj.transform.right = (start - end).normalized;

		BoxCollider2D boxCollider = obj.AddComponent<BoxCollider2D>();
		boxCollider.size = new Vector3((end - start).magnitude, lineSize, lineSize);

		obj.transform.parent = myLine.transform;
		Destroy (obj,duration);
	}
}
