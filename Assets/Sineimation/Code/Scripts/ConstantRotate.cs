using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotate : MonoBehaviour
{
	public float speed = 1f;
	public Vector3 rotation = Vector3.zero;

	private void Update ()
	{
		transform.localEulerAngles += rotation * speed * Time.deltaTime;
	} 
}
