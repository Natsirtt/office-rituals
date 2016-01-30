using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GlobalWorkMeterGUI : MonoBehaviour {

	void onGUI() {
		GUIDrawRect (new Rect (0, 0, 500, 20), Color.white);
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
