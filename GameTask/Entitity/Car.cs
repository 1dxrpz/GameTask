using GameTask.Math;

namespace GameTask.Entitity
{
	public class Car : BaseTransport
	{
		// Наследую от BaseTransport и передаю максимальное кол-во мест в этом транспорте
		public Car(string name, Position position)
			:base(4, name)
		{
			Position = position;
		}
	}
}
