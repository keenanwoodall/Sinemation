using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mathx;

public class TrigPosition : MonoBehaviour
{
	public Vector3 offset = Vector3.zero;
	public Vector3 
		a = new Vector3 (0f, 0f, 0f),
		b = new Vector3 (0f, 1f, 0f);

	public float animationOffset = 0f;

	public Trig trig;

	private void Update ()
	{
		float t = trig.Solve (Time.time, animationOffset);
		t = (t + 1f) / 2f;

		transform.localPosition = offset + Vector3.Lerp (a, b, t);
	} 
}