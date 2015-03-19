using UnityEngine;
using System.Collections;

public class TestExtensions : MonoBehaviour {


	void Start()
	{

		var r1 = new Rect(1,2,3,4);
		var r2 = new Rect(5,6,7,8);
		var r3 = new Rect(1,3,21,2);

		IntegrationTest.Assert(Rect.Equals(r1.Add(r2), new Rect(6,8,10,12)));
		IntegrationTest.Assert(Rect.Equals(r1.Subtract(r2), new Rect(-4,-4,-4,-4)));
		IntegrationTest.Assert(Rect.Equals(r1.Multiply(r2), new Rect(5,12,21,32)));
		IntegrationTest.Assert(Rect.Equals(r3.Divide(r2), new Rect(0.2f,0.5f,3f,0.25f)));
	}

}
