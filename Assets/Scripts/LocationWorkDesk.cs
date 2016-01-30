using UnityEngine;

public class LocationWorkDesk : Location
{

    [SerializeField]
    private int OwnerCharacterId = -1;
	private Character OwnerCharacter;

	// Use this for initialization
	void Start ()
	{
	    if (OwnerCharacterId == -1)
	    {
	        return;
	    }
	    if (CharactersManager.Instance.characters.Count <= OwnerCharacterId)
	    {
	        OwnerCharacterId = -1;
	    }
	    else
	    {
	        OwnerCharacter = CharactersManager.Instance.characters[OwnerCharacterId];
	    }
	}
	
	public override void LocationAction(Character actingCharacter)
	{
		Debug.Log ("Add Work! ");
	    if (OwnerCharacterId == -1)
	    {
	        return;
	    }
		//Do work
		float workUpdate = 0.1f;

		//if (actingCharacter != OwnerCharacter) {
		//	workUpdate = - workUpdate;
		//}

		if (OwnerCharacter == actingCharacter) {
			Debug.Log ("working at my desk! ");
			WorkMeterManager.GetInstance ().AddWork (OwnerCharacter, workUpdate);
		} else {
			//WorkMeterManager.GetInstance ().CanStealWork (actingCharacter, OwnerCharacter);
			float workStolen = WorkMeterManager.GetInstance ().StealWork (actingCharacter, OwnerCharacter, workUpdate);
			Debug.Log (string.Format("{0} stole {1} work from {2}", 
				actingCharacter.name, workStolen, OwnerCharacter.name));
		}
	}
}
