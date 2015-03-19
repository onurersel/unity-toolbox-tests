using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(TBPool))]
public class TestPool : MonoBehaviour {

	private TBPool m_pool;

	void Awake()
	{
		m_pool = GetComponent<TBPool>();
	}

	void Start()
	{

		var t1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		t1.name = "t1_name";
		var t2 = GameObject.CreatePrimitive(PrimitiveType.Capsule);
		t2.name = "t2_name";


		IntegrationTest.Assert(m_pool.templateCount == 0);
		IntegrationTest.Assert(m_pool.requestedObjects.Count == 0);
		var o1t1 = m_pool.RequestWithTemplate(t1);
		IntegrationTest.Assert(m_pool.templateCount == 1);
		IntegrationTest.Assert(m_pool.requestedObjects.Count == 1);
		var o2t1 = m_pool.RequestWithTemplate(t1);
		IntegrationTest.Assert(m_pool.templateCount == 1);
		IntegrationTest.Assert(m_pool.requestedObjects.Count == 2);
		IntegrationTest.Assert(o1t1.transform.parent == null);
		IntegrationTest.Assert(o2t1.transform.parent == null);


		m_pool.container = this.transform;
		var o1t2 = m_pool.RequestWithTemplate(t2);
		IntegrationTest.Assert(m_pool.templateCount == 2);
		IntegrationTest.Assert(m_pool.requestedObjects.Count == 3);
		IntegrationTest.Assert(o1t2.transform.parent == this.transform);


		IntegrationTest.Assert(m_pool.GetTemplateName(0) == "t1_name");
		IntegrationTest.Assert(m_pool.GetTemplateName(1) == "t2_name");
		IntegrationTest.Assert(m_pool.templateCount == 2);
		IntegrationTest.Assert(m_pool.GetTemplateRecycledCount(0) == 0);
		IntegrationTest.Assert(m_pool.GetTemplateRecycledCount(1) == 0);
		IntegrationTest.Assert(m_pool.GetTemplateRequestedCount(0) == 2);
		IntegrationTest.Assert(m_pool.GetTemplateRequestedCount(1) == 1);


		m_pool.Recycle(o2t1);
		IntegrationTest.Assert(m_pool.requestedObjects.Count == 2);
		IntegrationTest.Assert(m_pool.GetTemplateRecycledCount(0) == 1);
		IntegrationTest.Assert(m_pool.GetTemplateRequestedCount(0) == 1);


		var o3t1 = m_pool.RequestWithTemplate(t1);
		IntegrationTest.Assert(o3t1 == o2t1);
		IntegrationTest.Assert(m_pool.GetTemplateRecycledCount(0) == 0);
		IntegrationTest.Assert(m_pool.GetTemplateRequestedCount(0) == 2);
		IntegrationTest.Assert(m_pool.requestedObjects.Count == 3);
	}

}
