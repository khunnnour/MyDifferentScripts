using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* *
 * NOT COMPLETELY MINE
 * https://answers.unity.com/questions/29741/mouse-look-script.html
 * https://forum.unity.com/threads/mouse-look-script.233903/
 * */

public class LookScript : MonoBehaviour
{
	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;

	[Range(0f, 100f)]
	public float sensitivity = 10.0f;

	[Header("Look Bounds")]
	public float minXRot = -360f;
	public float maxXRot = 360f;
	public float minYRot = -60f;
	public float maxYRot = 60f;

	float rot_X, rot_Y;

	// Start is called before the first frame update
	void Start()
	{
		// Locks cursor in center of screen
		Cursor.lockState = CursorLockMode.Locked;

		// Get initial rotation
		Vector3 euler = transform.rotation.eulerAngles;
		
		// Set initial rotation
		rot_X = euler.x;
		rot_Y = euler.y;
	}

	// Update is called once per frame
	void Update()
	{
		// Only update required axis
		if (axes == RotationAxes.MouseXAndY)
		{
			UpdateXRotation();
			UpdateYRotation();
		}
		else if (axes == RotationAxes.MouseX)
			UpdateXRotation();
		else
			UpdateYRotation();

		// Set new rotation
		transform.rotation = Quaternion.Euler(rot_Y, rot_X, 0.0f);
	}

	void UpdateXRotation()
	{
		// Update x rotation
		rot_X += Input.GetAxis("Mouse X") * (sensitivity * Time.deltaTime);
		
		// Wrap rotation
		if (rot_X < minXRot)
			rot_X += maxXRot;
		else if (rot_X > maxXRot)
			rot_X -= maxXRot;
	}

	void UpdateYRotation()
	{
		// Update y rotation
		rot_Y -= Input.GetAxis("Mouse Y") * (sensitivity * Time.deltaTime);
		
		// Clamp rotation
		if (rot_Y < minYRot)
			rot_Y = minYRot;
		else if (rot_Y > maxYRot)
			rot_Y = maxYRot;
	}
}