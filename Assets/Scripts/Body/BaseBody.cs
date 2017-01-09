using UnityEngine;

public class BaseBody : MonoBehaviour 
{
	// Called when spawn completed
	public virtual void OnInit() {}

	// Called right before destroy
	public virtual void OnDestroy() {}

	// Return this body to the spawn manager
	public void DestroyBody()
	{
		SpawnManager.Despawn(this);
	}
}