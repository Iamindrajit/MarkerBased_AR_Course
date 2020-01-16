using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RaycastHitHandler : MonoBehaviour
{

	public abstract void HandleInteract();
	public abstract void HandleLook();

	public abstract void HandleUnlook();


}
