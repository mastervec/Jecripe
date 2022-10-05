using UnityEngine;
using System.Collections;

/// <summary>
/// Enable/Disable all mesh renderers this game object has. Attach this script
/// to the parent of the GameObject you want to enable/disable 
/// </summary>
public class DisableAllMeshRenderers : MonoBehaviour 
{	
	public bool enableAll = false; // Enables the MeshRenderer if <true> or disables them if <false>.
	
	/// <summary>
	/// Loop through all meshRenderer components and enable/disable all of them.
	/// </summary>
	void Start() 
	{
		Component[] meshArray = GetComponentsInChildren<MeshRenderer>();
		foreach (MeshRenderer mesh in meshArray)
			mesh.GetComponent<Renderer>().enabled = enableAll;
	}
	
	#if UNITY_EDITOR
	/// <summary>
	/// This Update should only run when playing inside the Editor.
	/// </summary>
	void Update()
	{
		Component[] meshArray = GetComponentsInChildren<MeshRenderer>();
		foreach (MeshRenderer mesh in meshArray)
			mesh.GetComponent<Renderer>().enabled = enableAll;
	}
	#endif
}
