using UnityEngine;

public class LocationWorkDesk : Location
{

	[SerializeField]
	public float WorkValue = 0.1f;

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

        GetComponent<RandomSoundPlayer>().PlaySound();

		float workUpdate = 0.25f;

		//Debug.Log ("Before: " + workUpdate);
		actingCharacter.GetComponent<CoffeeMeter> ().CalcWork (ref workUpdate);
		actingCharacter.GetComponent<SmokeMeter> ().CalcWork (ref workUpdate);
		//Debug.Log ("After: " + workUpdate);

		if (OwnerCharacter == actingCharacter) {
			Debug.Log ("working at my desk! ");
			WorkMeterManager.GetInstance ().AddWork (OwnerCharacter, workUpdate);
		} else {
			//WorkMeterManager.GetInstance ().CanStealWork (actingCharacter, OwnerCharacter);
			float workStolen = WorkMeterManager.GetInstance ().StealWork (actingCharacter, OwnerCharacter, workUpdate * 0.5f);
			Debug.Log (string.Format("{0} stole {1} work from {2}", 
				actingCharacter.name, workStolen, OwnerCharacter.name));
		}
	}
}
