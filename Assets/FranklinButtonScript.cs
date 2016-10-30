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

	//moves the button in the -y, then moves it back
	IEnumerator Depress() {
		isDepressing = true;
		yield return StartCoroutine (MoveOverSpeed (this.gameObject, new Vector3 (this.transform.position.x, this.transform.position.y - 1, this.transform.position.z), depressDownSpeed));
		yield return StartCoroutine (MoveOverSpeed (this.gameObject, new Vector3 (this.transform.position.x, this.transform.position.y + 1, this.transform.position.z), depressUpSpeed)); 
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
