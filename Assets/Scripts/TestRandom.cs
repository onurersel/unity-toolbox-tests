using UnityEngine;
using System.Collections.Generic;

public class TestRandom : MonoBehaviour {

	private List<int> m_list;

	void Start()
	{

		m_list = new List<int>();

		for(int i = 0; i < 1000; ++i)
		{
			if(TBRandom.safeValue == 1f)
			{
				IntegrationTest.Fail();
			}
		}


		var side = 6;
		IterateForDices(side);
		IntegrationTest.Assert(m_list.Count == side);
		for(int i = 0; i < side;  ++i)
			IntegrationTest.Assert(m_list[i] == i);

	}

	private void IterateForDices(int side)
	{
		m_list.Clear();


		for(int i = 0; i < 1000; ++i)
		{
			var r = TBRandom.Dice(side);

			bool isInList = false;
			foreach(int l in m_list)
			{
				if(l == r)
				{
					isInList = true;
					break;
				}
			}

			if(isInList == false)
			{
				m_list.Add(r);
			}
		}

		m_list.Sort();

	}

}
