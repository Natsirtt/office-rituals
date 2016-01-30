using System.Collections.Generic;
using UnityEngine;

public class CharactersBindingManager : MonoBehaviour
{
    private List<int> bindedIds;

    void Awake()
    {
        bindedIds = new List<int>();
    }

	void Update () {
        // id 0 is keyboard ;)
	    for (int i = 0; i <= 11; i++)
	    {
	        if (bindedIds.Contains(i))
	        {
	            continue;
	        }
	        if (i == 0)
	        {
	            if (Input.GetKeyDown(KeyCode.Space))
	            {
	                var newCharacter = CharactersManager.Instance.CreateCharacter();
	                newCharacter.AddComponent<KeyboardController>();
                    bindedIds.Add(i);
	            }
	        }
            else if (Input.GetButtonDown(XBoxController.SecondaryActionPressedDescriptor(i)))
	        {
	            var newCharacter = CharactersManager.Instance.CreateCharacter();
	            var controller = newCharacter.AddComponent<XBoxController>();
	            controller.joystickId = i;
                bindedIds.Add(i);
	        }
	    }
	}
}
