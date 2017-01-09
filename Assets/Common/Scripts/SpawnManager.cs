using UnityEngine;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
	public static SpawnManager _instance;

	List<BaseBody> _bodies = new List<BaseBody>();

	void Awake()
	{
		_instance = this;
		_instance._bodies.Clear();
	}

	public static BaseBody Spawn(BaseBody body, Vector3 pos, Quaternion rot)
	{
		BaseBody spawnedBody = Instantiate(body, pos, rot);
		_instance._bodies.Add(spawnedBody);

		spawnedBody.OnInit();
		return spawnedBody;
	}

	public static void Despawn(BaseBody body)
	{
		_instance._bodies.Remove(body);
		body.OnDestroy();
		Destroy(body.gameObject);
	}
}
