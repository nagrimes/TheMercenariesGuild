using UnityEngine;
using System.Collections;

public class CameraManager: MonoBehaviour {

	private Vector3 startPosition;
	private Vector3 endPosition;
	private Quaternion startRotation;
	private Quaternion endRotation;
	private Vector3 target;
	private Vector3 targetCameraOffset;
	private bool cameraMoveEnabled = false;
	public float lerpTransitionSpeed = 1f;
	public float lerpRotationSpeed = 1f;
	public GameObject cameraOrigin;
	public Vector3 cameraOriginOffset;


	// Use this for initialization
	void Start () {
		target = transform.position;
	}

	// Update is called once per frame
	void Update () {
		if (cameraMoveEnabled) {
			SmoothLookAt ();
			SmoothMoveTowards ();
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			SetOriginalPerspective ();
		}
	}

	void SmoothMoveTowards(){
		transform.position = Vector3.Lerp (transform.position, target + targetCameraOffset, Time.deltaTime * lerpTransitionSpeed);
	}
	void SmoothLookAt(){
			//this function gets called during Update

			//target is the end position (Vector3) of where you want the camera to stop
			//trans.position is the current position of the camera
		Vector3 relativePlayerPosition = target - transform.position;			

			//this creates a rotation that face the direction the camera is moving
		Quaternion lookAtRotation = Quaternion.LookRotation(relativePlayerPosition, Vector3.up);

			//this lerps the camera rotation to lookAtRotation
		transform.rotation = Quaternion.Lerp(transform.rotation, lookAtRotation, Time.deltaTime * lerpRotationSpeed);

	}

	void SetOriginalPerspective(){
		target = cameraOrigin.transform.position;
		targetCameraOffset = cameraOriginOffset;
		cameraMoveEnabled = true;
	}

	//THE FOLLOWING FUNCTIONS ARE RESERVED FOR OUTSIDE SCRIPTS ACTING UPON THIS SCRIPT

	//Sets the new target and initiates camera movement.
	public void SetNewPerspective(Vector3 target, Vector3 targetCameraOffset){
		this.target = target;
		this.targetCameraOffset = targetCameraOffset;
		cameraMoveEnabled = true;
	}
}