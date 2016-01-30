using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class WorkMeterManager {

	static WorkMeterManager instance;
	public static WorkMeterManager GetInstance() {
		return instance ?? (instance = new WorkMeterManager ());
	}


	public Dictionary<Character, float> AllWork;

	void Start () {
		AllWork = new Dictionary<Character, float>();
	}
	
	public void AddWork(Character character, float workValue) {
		if (AllWork.ContainsKey (character)) {
			AllWork [character] += workValue;
		} else {
			AllWork [character] = workValue;
		}

		CheckWork ();
	}

	/// <summary>
	/// Determines whether the theif can steal work from the victim.
	/// </summary>
	/// <returns>If we can steal some work <param name="workValue">.</returns>
	/// <param name="character1">Theif</param>
	/// <param name="character2">Victim</param>
	public bool CanStealWork(Character character1, Character character2, float workValue = 0.0f) {
		if (!AllWork.ContainsKey (character2)) {
			return false;
		}

		var c1Value = AllWork[character2];
		return c1Value >= workValue;
	}

	/// <summary>
	/// Steals the work.
	/// </summary>
	/// <returns>If we stole some work</returns>
	/// <param name="character1">Theif</param>
	/// <param name="character2">Victim</param>
	/// <param name="workValue">Work value to steal.</param>
	public bool StealWork(Character character1, Character character2, float workValue) {
		if (CanStealWork (character1, character2)) {
			float workStolen = (AllWork [character2] - workValue);
			AddWork (character1, workStolen);
			AllWork [character2] -= workStolen;
		}

		return false;
	}

	/// <summary>
	/// Checks if the work is at 100%.
	/// </summary>
	public bool CheckWork() {
		if (AllWork.Sum (x => x.Value) >= 100.0f) {
			var winner = AllWork.Aggregate((l, r) => l.Value < r.Value ? l : r);
			Debug.Log ("Winner: " + winner.Key.name);
		
			return true;
		}

		return false;
	}
}
