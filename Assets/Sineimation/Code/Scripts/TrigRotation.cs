using UnityEngine;
using Mathx;

public class TrigRotation : MonoBehaviour
{
	public Vector3
		a = new Vector3 (0f, 0f, -45f),
		b = new Vector3 (0f, 0f, 45f);

	public bool useCurve = false;
	public AnimationCurve curve = new AnimationCurve ();

	public float animationOffset = 0f;

	public Trig trig;

	private void Update ()
	{
		// Get the current time on a sin wave.
		float t = trig.Solve (Time.time, animationOffset);
		// Remap t, between 0 and 1 instead of -1 and 1.
		t = (t + 1f) / 2f;

		if (useCurve)
			t = curve.Evaluate (t);

		transform.localEulerAngles = Vector3.Lerp (b, a, t);
	} 
}