using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
	public GameObject obj;

	public GameObject parent;

	List<GameObject> ls = new List<GameObject>();
	NewObjectPools nop = new NewObjectPools();
	public void OnEnable()
	{
		
		for(int i = 0; i< 8;i++)
		{
			var tempObj =  nop.RequestCacheGameObject(obj);
			ls.Add(tempObj);
			tempObj.transform.SetParent(parent.transform);
		}
	}

	private void Update()
	{
		float time = 0;
		time +=  Time.time;

		if(time > 5)
		{
			for(int i = 0; i< ls.Count;i++)
			{
				nop.ReturnCacheGameObject(ls[i]);
			}
			ls.Clear();
		}

		if(time > 10)
		{
			for (int i = 0; i < 8; i++)
			{
				var tempObj = nop.RequestCacheGameObject(obj);
				ls.Add(tempObj);
				tempObj.transform.SetParent(parent.transform);
			}
		}

	}


	

}
