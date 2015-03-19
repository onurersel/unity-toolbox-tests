using UnityEngine;
using System.Collections.Generic;


[RequireComponent(typeof(TBFactory))]
public class TestFactory : MonoBehaviour {

	private List<string> m_list;
	public TBFactory factory1;
	public TBFactory factory2;

	void Start()
	{
		m_list = new List<string>();

		IterateWithFactoryAndHardness(factory1, 0f);
		IntegrationTest.Assert(m_list.Count == 1);
		IntegrationTest.Assert(m_list[0].Equals("pf_factoryTest1(Clone)"));
		m_list.Clear();

		IterateWithFactoryAndHardness(factory1, 1f);
		IntegrationTest.Assert(m_list.Count == 3);
		m_list.Clear();

		IterateWithFactoryAndHardness(factory1, .6f);
		IntegrationTest.Assert(m_list.Count == 2);
		m_list.Clear();


		IntegrationTest.Assert(factory2.Request(0f) == null);
		IntegrationTest.Assert(factory2.Request(.5f) != null);
		IntegrationTest.Assert(factory2.Request(1f) != null);

	}

	private void IterateWithFactoryAndHardness(TBFactory factory, float hardness)
	{
		factory.hardness = hardness;
		string[] splitChars = {" "};
		for(int i = 0; i < 100; ++i)
		{
			var o = factory.Request();
			string[] s = o.name.Split(splitChars, System.StringSplitOptions.None);
			
			bool isInList = false;
			foreach(string n in m_list)
			{
				if(n.Equals(s[0]))
				{
					isInList = true;
					break;
				}
			}
			
			if(isInList == false)
			{
				m_list.Add(s[0]);
			}
		}
	}
}
