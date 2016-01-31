using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

	public GameObject[] wayPointsRoute1;
	public GameObject[] wayPointsRoute2;
	public BossTalk bossTalk;
	public ConferenceLocation confLocation;
	private NavMeshAgent navAgent;
	// Use this for initialization

	private int activeRoute;
	private int currentWayPointTarget;
	private float wayPointSwitchDistance = 0.3f;
	private AudioSource audioS;
	public TextMesh text;
	private Vector3 textOffset;
	private float timeSinceLastWalk;
	public float bossTriggerInterval = 120;
	public float bossTriggerIntervalRand = 90;
	private float nextBossTrigger;
	private bool bossActive;

	void Start () {
		navAgent = GetComponent<NavMeshAgent> ();
		activeRoute = -1;
		currentWayPointTarget = 0;
		audioS = GetComponent<AudioSource> (); 
		text.text = "";
		textOffset = text.transform.position - transform.position;
		timeSinceLastWalk = Time.time;
		bossActive = false;

		setNextBossTrigger ();
	}

	private void setNextBossTrigger()
	{
		nextBossTrigger = Time.time + bossTriggerInterval - bossTriggerIntervalRand + Random.Range (0, bossTriggerIntervalRand);

		nextBossTrigger = Time.time + 4;
	}

	void StartBossRound()
	{
		bossActive = true;
		TriggerFirstRoute ();
	}
	void EndBossRound()
	{
		text.text = "";
		bossActive = false;
		setNextBossTrigger ();
	}


	void TriggerFirstRoute()
	{
		activeRoute = 1;
		currentWayPointTarget = 0;
		if (wayPointsRoute1.Length > 0) 
		{
			navAgent.SetDestination (wayPointsRoute1 [currentWayPointTarget].transform.position);
		}
	}

	void TriggerSecondRoute()
	{
		activeRoute = 2;
		currentWayPointTarget = 0;
		if (wayPointsRoute2.Length > 0) 
		{
			navAgent.SetDestination (wayPointsRoute2 [currentWayPointTarget].transform.position);
		}
	}

	void ShoutTowardsMeeting()
	{
		audioS.clip = bossTalk.getNextSound ();
		audioS.Play ();
		text.text = bossTalk.getNextLineWalkToMeeting ();
	}
	void ShoutAtMeeting()
	{
		audioS.clip = bossTalk.getNextSound ();
		audioS.Play ();
		text.text = bossTalk.getNextLineAtMeeting ();
	}
	void ShoutTowardsOffice()
	{
		audioS.clip = bossTalk.getNextSound ();
		audioS.Play ();
		text.text = bossTalk.getNextLineWalkToOffice ();
	}

	void EndOfRoute1()
	{
		StartCoroutine (PointlessMeeting ());

	}

	IEnumerator PointlessMeeting()
	{
		ShoutAtMeeting ();
		yield return new WaitForSeconds(2);
		ShoutAtMeeting ();
		yield return new WaitForSeconds(2);
		ShoutAtMeeting ();
		yield return new WaitForSeconds(2);
		text.text = "";
		//navAgent.Resume ();

		bool anyOneMissing = confLocation.CheckPlayersInConfRoom ();

		if (anyOneMissing) 
		{
			StartCoroutine (ShoutAtMissingPersons ());
		}
		else
		{
			TriggerSecondRoute ();
		}

	}

	IEnumerator ShoutAtMissingPersons()
	{
		navAgent.SetDestination (wayPointsRoute1 [0].transform.position);
		yield return new WaitForSeconds(2);

		audioS.clip = bossTalk.getNextSound ();
		audioS.Play ();
		text.text = "You lazy bastards!!";
		yield return new WaitForSeconds(2);
		audioS.clip = bossTalk.getNextSound ();
		audioS.Play ();
		text.text = "You have to listen to my important information!";
		yield return new WaitForSeconds(2);

		TriggerSecondRoute ();
	}

	// Update is called once per frame
	void Update () {

		if (Time.time > nextBossTrigger && !bossActive) 
		{
			StartBossRound ();
		}

		text.transform.position = transform.position + textOffset;

		if (activeRoute == 1) 
		{
			//Debug.Log ("dist="+navAgent.remainingDistance);
			if (navAgent.remainingDistance < wayPointSwitchDistance && wayPointsRoute1.Length>1) 
			{
				ShoutTowardsMeeting ();
				Debug.Log ("reached waypoint number "+currentWayPointTarget);
				currentWayPointTarget ++;
				if (currentWayPointTarget >= wayPointsRoute1.Length) {
					currentWayPointTarget = 0;
					activeRoute = -1;
					//navAgent.Stop ();
					EndOfRoute1 ();

				} 
				else 
				{
					navAgent.SetDestination (wayPointsRoute1 [currentWayPointTarget].transform.position);
				}
			} 
		}

		if (activeRoute == 2) 
		{
			if (navAgent.remainingDistance < wayPointSwitchDistance && wayPointsRoute2.Length>1) 
			{
				ShoutTowardsOffice ();
				currentWayPointTarget ++;
				if (currentWayPointTarget >= wayPointsRoute2.Length) {
					currentWayPointTarget = 0;
					activeRoute = -1;
					//navAgent.Stop ();
					text.text = "";
					EndBossRound ();
				} 
				else 
				{
					navAgent.SetDestination (wayPointsRoute2 [currentWayPointTarget].transform.position);
				}
			} 
		}
	}


}
