using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections;

public class GlobalWorkMeterGUI : MonoBehaviour {

	void OnGUI() {

		GUIDrawRect (new Rect (0, 0, Screen.width, 20), Color.white);

		float x = 0;

		var workInst = WorkMeterManager.GetInstance ();
		for (int i = 0; i < workInst.AllWork.Keys.Count; i++) {

			Color color = new Color (Random.Range (0.0f, 1.0f), Random.Range (0.0f, 1.0f), Random.Range (0.0f, 1.0f));

			Character key = (Character)workInst.AllWork.Keys.ElementAt(i);
			float value = workInst.GetWork(key);

			float width = value * Screen.width;
			GUIDrawRect (new Rect (x, 0, width, 20), color);
			x += width;
		}
	}

	private static Texture2D _staticRectTexture;
	private static GUIStyle _staticRectStyle;

	// Note that this function is only meant to be called from OnGUI() functions.
	public static void GUIDrawRect( Rect position, Color color )
	{
		if( _staticRectTexture == null )
			_staticRectTexture = new Texture2D( 1, 1 );

		if( _staticRectStyle == null )
			_staticRectStyle = new GUIStyle();

		_staticRectTexture.SetPixel( 0, 0, color );
		_staticRectTexture.Apply();

		_staticRectStyle.normal.background = _staticRectTexture;

		GUI.Box( position, GUIContent.none, _staticRectStyle );
	}
}
