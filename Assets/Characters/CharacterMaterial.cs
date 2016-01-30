using UnityEngine;
using System.Collections.Generic;

public class CharacterMaterial : MonoBehaviour {
	public int TextureIndex = 0;

	private int last_texture_index_ = -1;

	private Renderer renderer_ = null;

	static List<Texture> s_textures_ = new List<Texture>();
	static CharacterMaterial() {
		for(var i=0;i<4; ++i) {
			LoadTexture(string.Format("character-diffuse-{0}", i+1));
		}

		if( s_textures_.Count == 0) {
			throw new KeyNotFoundException("No textures found, check console log for more info");
		}
	}

	private static void LoadTexture(string path) {
		var texture = Resources.Load<Texture>(path);
		if( texture == null ) {
			Debug.Log(string.Format("Unable to load texture {0}", path));
			return;
		}
		s_textures_.Add(texture);
	}

	private void UpdateTextures() {
		if( this.TextureIndex == this.last_texture_index_ ) return;
		this.last_texture_index_ = this.TextureIndex;

		var count = s_textures_.Count;
		if( this.TextureIndex <0 || this.TextureIndex >= count ) {
			throw new KeyNotFoundException(string.Format(
					"{0} was a invalid index, should be between 0 and {1}", this.TextureIndex, count));
		}

		if( this.renderer_ == null ) return;
			this.renderer_.material.mainTexture = s_textures_[this.TextureIndex];
	}

	// Use this for initialization
	void Start () {
		this.renderer_ = GetComponent<Renderer>();
		this.UpdateTextures();
	}
	
	// Update is called once per frame
	void Update () {
		this.UpdateTextures();
	}
}
