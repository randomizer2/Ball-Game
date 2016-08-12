using System.Collections.Generic;
using UnityEngine;
using System.Collections;


public class followPath : MonoBehaviour 
{

	public enum FollowType 
	{
		moveTowards,
		Lerp
	}

	public FollowType Type = FollowType.moveTowards;
	public movingPlatform Path;
	public float speed = 1;
	public float maxDistanceToGoal = .1f;

	private IEnumerator<Transform> _currentPoint;

	public void Start()
	{
		if (Path ==null)
		{
			Debug.LogError ("Path cannot be null", gameObject);
			return;
		}
		_currentPoint = Path.GetPathEmuerator();
		_currentPoint.MoveNext();

		if (_currentPoint.Current ==null)
			return;
		transform.position = _currentPoint.Current.position;
	}

	public void Update()
	{
		if (_currentPoint == null || _currentPoint.Current == null)
			return;

		if (Type == FollowType.moveTowards)
			transform.position = Vector3.MoveTowards (transform.position, _currentPoint.Current.position, Time.deltaTime * speed);
		else if (Type == FollowType.Lerp)
			transform.position = Vector3.Lerp (transform.position, _currentPoint.Current.position, Time.deltaTime * speed);

		var distanceSquared = (transform.position - _currentPoint.Current.position).sqrMagnitude;
		if (distanceSquared< maxDistanceToGoal * maxDistanceToGoal)
			_currentPoint.MoveNext();
	}
}

