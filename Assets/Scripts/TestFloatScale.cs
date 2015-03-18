using UnityEngine;
using System.Collections;

public class TestFloatScale : MonoBehaviour {

	public TBFloatScale floatScale;
	public TBFloatScale floatScal2;


	void Update()
	{
		floatScale.Scale(Input.mousePosition.x);
	}
}
