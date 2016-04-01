using UnityEngine;
using System.Collections;

public class ReplaySystem : MonoBehaviour
{
	private int recordedFrames = -1;
	private const int bufferFrames = 1000;
	private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];

	private Rigidbody rigidBody;

	private bool isRecording = true;
	private Vector3 actualPosition;
	private Quaternion actualRotation;

	private GameManager gameManager;

	// Use this for initialization
	void Start ()
	{
		rigidBody = GetComponent <Rigidbody> ();
		gameManager = GameObject.FindObjectOfType <GameManager> ();
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (gameManager.recording) {
			if (isRecording == false) {
				ResetActualState ();
			}

			recordedFrames++;
			Record ();
		} else {
			if (isRecording == true) {
				SaveActualState ();
			}

			PlayBack ();
		}

	}

	void PlayBack ()
	{
		
		isRecording = false;

		rigidBody.isKinematic = true;
		int frameNumber = (Time.frameCount % bufferFrames);
		if (recordedFrames < frameNumber) {
			frameNumber = Time.frameCount % recordedFrames;
		}

		Debug.Log ("Replaying Frame: " + frameNumber);

		transform.position = keyFrames [frameNumber].position;
		transform.rotation = keyFrames [frameNumber].rotation;
	}

	void Record ()
	{
		isRecording = true;

		int frameNumber = (Time.frameCount % bufferFrames);
		if (frameNumber > recordedFrames) {
			frameNumber = recordedFrames + 1;
		}

		Debug.Log ("Writing Frame: " + frameNumber);

		rigidBody.isKinematic = false;
		float time = Time.time;
		keyFrames [frameNumber] = new MyKeyFrame (time, transform.position, transform.rotation);
	}

	void SaveActualState ()
	{

		actualPosition = transform.position;
		actualRotation = transform.rotation;
	}

	void ResetActualState ()
	{

		transform.position = actualPosition;
		transform.rotation = actualRotation;
	}
}

/// <summary>
/// A Structure for storing frame state
/// </summary>
public struct MyKeyFrame
{

	public float frameTime;
	public Vector3 position;
	public Quaternion rotation;

	public MyKeyFrame (float frameTime, Vector3 position, Quaternion rotation)
	{
		this.position = position;
		this.frameTime = frameTime;
		this.rotation = rotation;
	}
}
