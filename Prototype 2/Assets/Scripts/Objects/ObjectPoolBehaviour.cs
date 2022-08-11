using System.Collections.Generic;
using UnityEngine;

namespace Game.Objects
{
	[AddComponentMenu("Game/Objetos/Pool de Objetos")]
	public class ObjectPoolBehaviour : MonoBehaviour
	{
		[SerializeField]
		private int _capacity;
		[SerializeField]
		private PoolableBehaviour _object;
		[Space]
		[SerializeField]
		private PoolableUnityEvent _onReleaseAction;

		private readonly List<PoolableBehaviour> pool = new();

		public int Avaliable => pool.Count;
		public int Count => Avaliable + InUse;
		public int InUse { get; private set; }
		public PoolableUnityEvent OnReleaseAction => _onReleaseAction;

		public GameObject Get()
		{
			PoolableBehaviour obj = GetObject();

			if (!obj)
				return null;

			return obj.gameObject;
		}

		public T Get<T>() where T : MonoBehaviour
		{
			PoolableBehaviour obj = GetObject();
			T result = obj.GetComponent<T>();
			return result;
		}

		public void Release(PoolableBehaviour obj)
		{
			if (pool.Contains(obj))
				return;

			InUse--;
			pool.Add(obj);
			_onReleaseAction.Invoke(obj);
		}

		private void Awake()
		{
			var objs = GetComponentsInChildren<PoolableBehaviour>(true);

			foreach (PoolableBehaviour obj in objs)
			{
				obj.SetPool(this);
				if (obj.isActiveAndEnabled)
				{
					InUse++;
					continue;
				}

				pool.Add(obj);
			}
		}

		private PoolableBehaviour Create()
		{
			PoolableBehaviour obj = Instantiate(_object, transform);
			obj.name = string.Format("{0} ({1:00})",
				_object.name,
				Count);
			obj.SetPool(this);
			return obj;
		}

		private PoolableBehaviour GetObject()
		{
			PoolableBehaviour obj = null;

			if (Avaliable > 0)
			{
				obj = pool[^1];
				_ = pool.Remove(obj);
			}
			else if (Count < _capacity)
				obj = Create();

			if (obj)
				InUse++;

			return obj;
		}
	}
}