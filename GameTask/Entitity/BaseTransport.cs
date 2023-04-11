using GameTask.Interfaces;
using GameTask.Math;
using System.Collections.Generic;

namespace GameTask.Entitity
{
	public class BaseTransport : ITransport
	{
		// Если этот код был бы в проде, то используя базовый класс можно будет добавлять
		// новые виды транспорта с теми же методами

		List<IPassanger> _passangers;
		int _capacity;
		string _name;

		public string Name => _name;
		public Position Position { get; set; }
		public bool IsFull => _passangers.Count >= _capacity;

		public BaseTransport(int capacity, string name)
		{
			_passangers = new List<IPassanger>();
			_capacity = capacity;
			_name = name;
		}

		// Возвращает водителя, первое вхождение в список
		public IPassanger GetDriver() => _passangers[0];

		// Возвращает лист из пассажиров, все остальные вхождения
		public List<IPassanger> GetPassangers()
		{
			List<IPassanger> result = new List<IPassanger>();
			for (int i = 1; i < _passangers.Count; i++)
				result.Add(_passangers[i]);
			return result;
		}

		// По сути пассажиры в транспорте добавляются по принципу стека
		// Этот и следущие методы возвращают информацию о том, можно ли добавить / высадить пассажира
		public bool AddPassanger(IPassanger passanger)
		{
			if (IsFull) return false;

			_passangers.Add(passanger);

			return true;
		}

		public bool RemovePassanger()
		{
			if (_passangers.Count == 0) return false;

			_passangers.RemoveAt(_passangers.Count - 1);

			return true;
		}
	}
}
