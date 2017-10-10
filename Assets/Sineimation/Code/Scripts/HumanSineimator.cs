using UnityEngine;
using Mathx;

public class HumanSineimator : MonoBehaviour
{
	public float speed = 10f;
	[Range (0f, 1f)]
	public float stride = 1f;

	[Header ("Advanced")]
	public float maxSideSway = 5f;
	public float
		minTorseBend = -1f,
		maxTorsoBend = 1f,
		maxTorsoTwist = 15f,
		maxBounce = 0.5f,
		maxHeadBob = 10f,
		maxEyeBounce = 0.1f,
		minHipAngle = -45f,
		maxHipAngle = 90f,
		maxCalfAngle = 90f,
		maxArmAngle = 90f,
		minForearmAngle = 90f,
		maxForearmAngle = 95f,
		maxFootAngle = 20f;

	[Header ("References")]
	public TrigRotation humanRotation;
	public TrigPosition humanPosition;

	public TrigPosition 
		eye1, 
		eye2;

	public TrigRotation
		body,
		head,
		nose,
		hip1, hip2,
		calf1, calf2,
		arm1, arm2,
		forearm1, forearm2,
		foot1, foot2;


	private void Start ()
	{
		humanPosition.offset = humanPosition.transform.localPosition;
		humanPosition.animationOffset = 1f;
		humanPosition.trig.trigType = TrigType.Cos;

		humanRotation.animationOffset = 0f;
		humanRotation.trig.trigType = TrigType.Sin;

		body.animationOffset = 0f;
		body.trig.trigType = TrigType.Sin;

		head.animationOffset = 0f;
		head.trig.trigType = TrigType.Sin;

		eye1.offset = eye1.transform.localPosition;
		eye1.animationOffset = 0f;
		eye1.trig.trigType = TrigType.Sin;

		eye2.offset = eye2.transform.localPosition;

		eye2.animationOffset = 0f;
		eye2.trig.trigType = TrigType.Sin;

		nose.animationOffset = 0f;
		nose.trig.trigType = TrigType.Sin;

		hip1.animationOffset = 1f;
		hip1.trig.trigType = TrigType.Cos;

		hip2.animationOffset = 0f;
		hip2.trig.trigType = TrigType.Sin;

		calf1.animationOffset = 0f;
		calf1.trig.trigType = TrigType.Sin;

		calf2.animationOffset = 1f;
		calf2.trig.trigType = TrigType.Cos;

		arm1.animationOffset = 0f;
		arm1.trig.trigType = TrigType.Sin;

		arm2.animationOffset = 1f;
		arm2.trig.trigType = TrigType.Cos;

		forearm1.animationOffset = 0f;
		forearm1.trig.trigType = TrigType.Sin;

		forearm2.animationOffset = 1f;
		forearm2.trig.trigType = TrigType.Cos;

		foot1.animationOffset = 1f;
		foot2.trig.trigType = TrigType.Sin;

		foot2.animationOffset = 0f;
		foot2.trig.trigType = TrigType.Cos;
	}

	private void OnValidate ()
	{
		if (!Application.isPlaying)
			return;

		RefreshBodyParts ();
	} 

	public void RefreshBodyParts ()
	{
		humanRotation.trig.frequency = body.trig.frequency = head.trig.frequency = hip1.trig.frequency = hip2.trig.frequency = calf1.trig.frequency = calf2.trig.frequency = arm1.trig.frequency = arm2.trig.frequency = forearm1.trig.frequency = forearm2.trig.frequency = foot1.trig.frequency = foot2.trig.frequency = speed;
		humanPosition.trig.frequency = eye1.trig.frequency = eye2.trig.frequency = nose.trig.frequency = speed * 2f;

		humanRotation.a = new Vector3 (-maxSideSway, 0f, 0f) * stride;
		humanRotation.b = new Vector3 (maxSideSway, 0f, 0f) * stride;

		humanPosition.a = Vector3.zero;
		humanPosition.b = new Vector3 (0f, maxBounce, 0f) * stride;

		body.a = new Vector3 (0f, -maxTorsoTwist, minTorseBend) * stride;
		body.b = new Vector3 (0f, maxTorsoTwist, maxTorsoBend) * stride;

		head.a = new Vector3 (0f, 0f, -maxHeadBob) * stride;
		head.b = new Vector3 (0f, 0f, maxHeadBob) * stride;

		eye1.a = new Vector3 (0f, maxEyeBounce, 0f) * stride;
		eye1.b = Vector3.zero;

		eye2.a = new Vector3 (0f, maxEyeBounce, 0f) * stride;
		eye2.b = Vector3.zero;

		nose.a = new Vector3 (0f, 0f, 10f) * stride;
		nose.b = new Vector3 (0f, 0f, -15f) * stride;

		hip1.a = new Vector3 (0f, 0f, minHipAngle) * stride;
		hip1.b = new Vector3 (0f, 0f, maxHipAngle) * stride;

		hip2.a = new Vector3 (0f, 0f, minHipAngle) * stride;
		hip2.b = new Vector3 (0f, 0f, maxHipAngle) * stride;

		calf1.a = Vector3.zero;
		calf1.b = new Vector3 (0f, 0f, -maxCalfAngle) * stride;

		calf2.a = Vector3.zero;
		calf2.b = new Vector3 (0f, 0f, -maxCalfAngle) * stride;

		arm1.a = new Vector3 (0f, 0f, -maxArmAngle) * stride;
		arm1.b = new Vector3 (0f, 0f, maxArmAngle) * stride;

		arm2.a = new Vector3 (0f, 0f, -maxArmAngle) * stride;
		arm2.b = new Vector3 (0f, 0f, maxArmAngle) * stride;

		forearm1.a = new Vector3 (0f, 0f, minForearmAngle) * stride;
		forearm1.b = new Vector3 (0f, 0f, maxForearmAngle) * stride;

		forearm2.a = new Vector3 (0f, 0f, minForearmAngle) * stride;
		forearm2.b = new Vector3 (0f, 0f, maxForearmAngle) * stride;

		foot1.a = new Vector3 (0f, 0f, maxFootAngle) * stride;
		foot1.b = new Vector3 (0f, 0f, -maxFootAngle) * stride;

		foot2.a = new Vector3 (0f, 0f, maxFootAngle) * stride;
		foot2.b = new Vector3 (0f, 0f, -maxFootAngle) * stride;
	}
}
