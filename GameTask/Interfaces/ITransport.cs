using GameTask.Math;

namespace GameTask.Interfaces
{
	public interface ITransport
	{
		public bool IsFull { get; }
		public IPassanger GetDriver();
		public List<IPassanger> GetPassangers();
		public bool AddPassanger(IPassanger passanger);
		public bool RemovePassanger();
		public string Name { get; }
		public Position Position { get; }
	}
}
