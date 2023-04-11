using GameTask.Interfaces;
using GameTask.Math;

namespace GameTask.Entitity
{
	public class Player : IPassanger
	{
		private string _nickname;
		public Player(string nickname, Position position)
		{
			_nickname = nickname;
			Position = position;
		}
		public Position Position { get; set; }

		public string Nickname => _nickname;
	}
}
