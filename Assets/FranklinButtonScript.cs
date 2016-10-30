using UnityEngine;
using System.Collections;

public class FranklinButtonScript : MonoBehaviour {

	private int depressDownSpeed = 1;
	private int depressUpSpeed = 1;
	private bool isDepressing;


	// Use this for initialization
	void Start () {
		isDepressing = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter(Collision collision){
		if (!isDepressing) {
			Depress ();
		}
	}

	//moves the button in the -y and disables collisions
	void Depress() {
		isDepressing = true;
		StartCoroutine (MoveOverSpeed (this, this.transform - new Vector3 (0, 1), depressDownSpeed));
		StartCoroutine (MoveOverSpeed (this, this.transform + new Vector3 (0, 1), depressUpSpeed)); 
		isDepressing = false;
	}



	//from internet
	public IEnumerator MoveOverSpeed (GameObject objectToMove, Vector3 end, float speed){
		// speed should be 1 unit per second
		while (objectToMove.transform.position != end)
		{
			objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, end, speed * Time.deltaTime);
			yield return new WaitForEndOfFrame ();
		}
	}

	//from internet
	public IEnumerator MoveOverSeconds (GameObject objectToMove, Vector3 end, float seconds)
	{
		float elapsedTime = 0;
		Vector3 startingPos = objectToMove.transform.position;
		while (elapsedTime < seconds)
		{
			transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
			elapsedTime += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		transform.position = end;
	}
}
