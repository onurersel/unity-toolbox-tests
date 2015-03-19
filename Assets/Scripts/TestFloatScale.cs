using UnityEngine;
using System.Collections;

public class TestFloatScale : MonoBehaviour {

	public TBFloatScale floatScale;

	void Start()
	{

		floatScale.inputMin = 2f;
		floatScale.inputMax = 8f;
		floatScale.outputMin = -4f;
		floatScale.outputMax = 10f;

		IntegrationTest.Assert(floatScale.Scale(2f) == -4f);
		IntegrationTest.Assert(floatScale.Scale(8f) == 10f);
		IntegrationTest.Assert(floatScale.Scale(5f) == 3f);
		IntegrationTest.Assert(floatScale.Scale(-1f) == -11f);
		IntegrationTest.Assert(floatScale.Scale(14f) == 24f);

		floatScale.limit = true;

		IntegrationTest.Assert(floatScale.Scale(-1f) == -4f);
		IntegrationTest.Assert(floatScale.Scale(14f) == 10f);

	}
}
