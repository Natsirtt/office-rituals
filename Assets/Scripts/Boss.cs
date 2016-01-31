using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

	public GameObject[] wayPointsRoute1;
	public GameObject[] wayPointsRoute2;
	private NavMeshAgent navAgent;
	// Use this for initialization

	private int activeRoute;
	private int currentWayPointTarget;
	private float wayPointSwitchDistance = 0.3f;

	void Start () {
		navAgent = GetComponent<NavMeshAgent> ();
		activeRoute = -1;
		TriggerFirstRoute ();
	}


	void StartBossRound()
	{
		TriggerFirstRoute ();
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

	void Shout()
	{
		StartCoroutine (PointlessMeeting (3));
	}

	IEnumerator PointlessMeeting(float time)
	{
		yield return new WaitForSeconds(time);
		navAgent.Resume ();
		activeRoute = 2;
		currentWayPointTarget = 0;
		if (wayPointsRoute2.Length > 0) 
		{
			navAgent.SetDestination (wayPointsRoute2 [currentWayPointTarget].transform.position);
		}
	}

	// Update is called once per frame
	void Update () {
		if (activeRoute == 1) 
		{
			Debug.Log ("dist="+navAgent.remainingDistance);
			if (navAgent.remainingDistance < wayPointSwitchDistance && wayPointsRoute1.Length>1) 
			{
				Debug.Log ("reached waypoint number "+currentWayPointTarget);
				currentWayPointTarget ++;
				if (currentWayPointTarget >= wayPointsRoute1.Length) {
					currentWayPointTarget = 0;
					activeRoute = -1;
					navAgent.Stop ();
					Shout ();

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
				currentWayPointTarget ++;
				if (currentWayPointTarget >= wayPointsRoute2.Length) {
					currentWayPointTarget = 0;
					activeRoute = -1;
					navAgent.Stop ();
				} 
				else 
				{
					navAgent.SetDestination (wayPointsRoute2 [currentWayPointTarget].transform.position);
				}
			} 
		}
	}


}
