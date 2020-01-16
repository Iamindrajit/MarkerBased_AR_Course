using UnityEngine;
//using Vuforia;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class RayCastFromCamera : MonoBehaviour
{

	private GameObject focusObj = null;
	private float focusx;
	private float focusy;
	private float focusz;

	public float sightDistance;

	public GameObject lastObject;



	private bool IsPointerOverUIObject()
	{
		PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
		eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		List<RaycastResult> results = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
		return results.Count > 0;
	}


	void FixedUpdate()
	{
		if(IsPointerOverUIObject())
		{
			return;
		}


		RaycastHit hit;
		if (Physics.Raycast(gameObject.transform.position, transform.forward, out hit, sightDistance))
		{
			 //Debug.Log(hit.transform.name);


			if (hit.transform.gameObject.GetComponent<RaycastHitHandler>())
			{
				// GetComponent<MenuOpener>().OpenMenu();
				hit.transform.gameObject.GetComponent<RaycastHitHandler>().HandleLook();
				lastObject = hit.transform.gameObject;
				//pointerLine.SetActive(true);

				if (Input.GetButton("Fire1"))
				{
					Debug.Log("got fire 1");
					if (hit.transform.gameObject.GetComponent<RaycastHitHandler>())
					{
						
						hit.transform.gameObject.GetComponent<RaycastHitHandler>().HandleInteract();
					}
						
				}
			}


			else
			{
				//  GetComponent<MenuOpener>().CloseMenu();
				//objectInfo.text = "";
				//pointerLine.SetActive(false);
			}


		}
		else
		{
			if(lastObject != null)
				lastObject.GetComponent<RaycastHitHandler>().HandleUnlook();
			//objectInfo.text = "";
			//pointerLine.SetActive(false);
		}
	}


}
