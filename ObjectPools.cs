using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPools : MonoBehaviour
{
	[SerializeField]
	private GameObject _prefab;

	private Queue<GameObject> _pooledInstanceQueue = new Queue<GameObject>();

	public GameObject GetIntance()
	{
		if(_pooledInstanceQueue.Count > 0)
		{
			GameObject instanceToReuse = _pooledInstanceQueue.Dequeue();
			instanceToReuse.SetActive(true);
			return instanceToReuse;
		}
		return Instantiate(_prefab);
	}

	public void ReturnInstance(GameObject gameObjectToPool)
	{
		_pooledInstanceQueue.Enqueue(gameObjectToPool);
	
		gameObjectToPool.transform.SetParent(gameObject.transform);
		//gameObjectToPool.SetActive(false);
	}
	
}
