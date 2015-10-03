using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrainingBuilding: StaticUnit
{
	private class UnitOnQueue
	{
		public int id;
		private float _timeToComplete;

		public UnitOnQueue (int id, float timeToComplete)
		{
			this.id = id;
			this._timeToComplete = timeToComplete;
		}

		public bool ReduceTimeToComplete (float time)
		{
			_timeToComplete -= time;
			return _timeToComplete < 0;
		}
	}

	private List<UnitOnQueue> _unitsOnQueue;
	public int trainableUnitsAtOnce, maxNumberOfUnitsOnQueue;
	private bool _isRunningTrainingCoroutine;

	public void AddUnitToTrainingQueue (int id, float timeToComplete)
	{
		UnitOnQueue unit = new UnitOnQueue (id, timeToComplete);
		if (_unitsOnQueue.Count + 1 < maxNumberOfUnitsOnQueue)
		{
			_unitsOnQueue.Add (unit);
			if (!_isRunningTrainingCoroutine)
			{
				StartCoroutine (Train ());
			}
		}
	}

	public IEnumerator Train ()
	{
		_isRunningTrainingCoroutine = true;
		while (_isRunningTrainingCoroutine)
		{
			List<int> unitsDoneAtNextFrame = new List<int>();
			for (int i = 0; i < Mathf.Min (trainableUnitsAtOnce, _unitsOnQueue.Count); i++)
			{
				UnitOnQueue current = _unitsOnQueue[i];
				if (current.ReduceTimeToComplete (0.1f))
				{
					// is done
					unitsDoneAtNextFrame.Add (i);
				}
			}
			foreach (int i in unitsDoneAtNextFrame)
			{
				_unitsOnQueue.RemoveAt (i);
			}
			yield return new WaitForSeconds(0.1f);
			if (_unitsOnQueue.Count == 0)
			{
				_isRunningTrainingCoroutine = false;
			}
		}
	}
}
