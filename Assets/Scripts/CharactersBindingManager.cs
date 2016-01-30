using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class CharactersBindingManager : MonoBehaviour
{
	public Text text;
	public GameObject SpawnLocation;

    private List<int> bindedIds;

    void Awake()
    {
        bindedIds = new List<int>();
    }

	void Update () {

		if (bindedIds.Count >= 4) {
			Debug.Log ("Max Players?");
			// Start? Or on next press, so they can still try the controlls
			return;
		} 

		text.enabled = bindedIds.Count > 0;

        // id 0 is keyboard ;)
	    for (int i = 0; i <= 11; i++)
	    {
	        if (bindedIds.Contains(i))
	        {
	            if (i == 0)
	            {
	                if (Input.GetKeyDown(KeyCode.Space))
	                {
						LoadNextScene ();
	                }
	            }
	            else
	            {
	                if (Input.GetButtonDown(XBoxController.SecondaryActionPressedDescriptor(i)))
					{
						LoadNextScene ();
	                }
	            }
	            continue;
	        }

	        if (i == 0)
	        {
	            if (Input.GetKeyDown(KeyCode.Space))
				{
	                var newCharacter = CharactersManager.Instance.CreateCharacter();
	                newCharacter.AddComponent<KeyboardController>();
					newCharacter.transform.position = SpawnLocation.transform.position;
					//newCharacter.transfrom.Rotate(0, Mathf.Deg2Rad(180), 0);
                    bindedIds.Add(i);
	            }
	        }
            else if (Input.GetButtonDown(XBoxController.SecondaryActionPressedDescriptor(i)))
	        {
				var newCharacter = CharactersManager.Instance.CreateCharacter();
				newCharacter.transform.position = SpawnLocation.transform.position;
	            var controller = newCharacter.AddComponent<XBoxController>();
	            controller.joystickId = i;
                bindedIds.Add(i);
	        }
	    }
	}

	void LoadNextScene() {
		Application.LoadLevel("officeScene");
	}
}
