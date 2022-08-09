using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapStayInside : MonoBehaviour
{
    public Transform MinimapCam;
	public float MinimapSize;
	Vector3 TempV3;

	void Update () {
		TempV3 = transform.parent.transform.position;   /// dh position el enemy 1 3ndo
		TempV3.z = transform.position.z;                /// by5ly el y bta3to = bta3t el minimap Icon
		transform.position = TempV3;                    /// by5ly el icon = bta3 el enemy
	}

	void LateUpdate () {
		// Center of Minimap
		Vector3 centerPosition = MinimapCam.transform.localPosition;

		// Just to keep a distance between Minimap camera and this Object (So that camera don't clip it out)
		centerPosition.z -= 0.5f;

		// Distance from the gameObject to Minimap
		float Distance = Vector3.Distance(transform.position, centerPosition);

		// If the Distance is less than MinimapSize, it is within the Minimap view and we don't need to do anything
		// But if the Distance is greater than the MinimapSize, then do this
		if (Distance > MinimapSize)
		{
			// Gameobject - Minimap
			Vector3 fromOriginToObject = transform.position - centerPosition;

			// Multiply by MinimapSize and Divide by Distance
			fromOriginToObject *= MinimapSize / Distance;

			// Minimap + above calculation
			transform.position = centerPosition + fromOriginToObject;
		}
	}
}
