using UnityEngine;
using System.Collections;

public class DensityGUITextBehaviour : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		guiText.fontSize = (int)((float)guiText.fontSize * Density.Value);
		guiText.pixelOffset = new Vector2 (guiText.pixelOffset.x * Density.Value, 
		                                   guiText.pixelOffset.y * Density.Value);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
