using UnityEngine;
using System.Collections;
using ThinksquirrelSoftware.Thinkscroller;

/// <summary>
/// Example script - instantiates a prefab based on display density.
/// A more advanced version of this script would swap textures instead.
/// </summary>
[AddComponentMenu("Thinkscroller Example Project/HiDPI Example")]
public class HiDpiExample : MonoBehaviour {
	
	public bool forceEditorHiDpi = false;
	public float dpiThreshold = 200f;
	public float fallbackDpi = 160f;
	public GameObject lowDpiPrefab;
	public GameObject hiDpiPrefab;
	
	void Awake()
	{
		float dpi = Screen.dpi == 0 ? fallbackDpi : Screen.dpi;

		GameObject obj = null;;
		if (((Application.isEditor && forceEditorHiDpi) || dpi >= dpiThreshold) && hiDpiPrefab)
			obj = Object.Instantiate(hiDpiPrefab) as GameObject;
		else if (lowDpiPrefab)
			obj = Object.Instantiate(lowDpiPrefab) as GameObject;

		if( obj != null ) 
		{
			obj.transform.position = transform.position;
			GameObject pc = GameObject.Find( "Parallax Camera" ) as GameObject;
			obj.GetComponent<Parallax>().SetParallaxCamera( pc.GetComponent<Camera>() );
		}
	}
}
