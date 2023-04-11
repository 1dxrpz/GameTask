using GameTask.Entitity;
using GameTask.Interfaces;
using GameTask.Math;

const int CARS_COUNT = 200;
const int PLAYERS_COUNT = 1000;

// простенький генератор рандомных ников и названий автомобилей
RandomGenerator generator = new RandomGenerator();

// Если бы этот код был в проде, то можно было бы добавить новый тип entity который
// может садиться в машину, но при этом не являлся бы игроком (например NPC)

List<IPassanger> players = new List<IPassanger>();
List<ITransport> cars = new List<ITransport>();

Random random = new Random();

for (int i = 0; i < CARS_COUNT; i++)
{
	ITransport _car = new Car(
		generator.GenerateName(),
		new Position(random.Next(0, 100), random.Next(0, 100))
		);
	cars.Add(_car);
}

Thread thread = new Thread(MakePlayerSeatCar);
thread.Start();

for (int i = 0; i < PLAYERS_COUNT; i++)
{
	IPassanger _player = new Player(
		generator.GenerateNickname(),
		new Position(random.Next(0, 100), random.Next(0, 100))
		);
	players.Add(_player);
}

void MakePlayerSeatCar()
{
	int CurrentPlayer = 0;
	// пока не осталось пустых машин
	while (cars.Any(_car => !_car.IsFull))
	{
		if (CurrentPlayer < players.Count)
		{
			Thread.Sleep(0);
			var player = players[CurrentPlayer];
			// Добавление в первую не пустую машину
			var _car = cars.First(v => !v.IsFull);
			_car.AddPassanger(player);
			player.Position.Set(_car.Position);
			CurrentPlayer++;
		}
	}
}

thread.Join();
Result();

ITransport GetRandomCar()
{
	return cars[random.Next(CARS_COUNT)];
}

void Result()
{
	ITransport _car;
	Console.WriteLine("5 Random cars information: ");
	Console.WriteLine();
	for (int i = 0; i < 5; i++)
	{
		_car = GetRandomCar();
		Console.Write($"{_car.Name} {_car.Position} - ");
		Console.Write($" Driver: {_car.GetDriver().Nickname}");
		Console.Write($" Passangers:");
		foreach (var passanger in _car.GetPassangers())
			Console.Write($" {passanger.Nickname} {passanger.Position}");
		Console.WriteLine();
	}

	_car = GetRandomCar();
	
	var nearestPlayers = players.Where(p => p.Position.Distance(_car.Position) < 15).ToList();

	Console.WriteLine($"\nCars in radius of 15 from {_car.Position}");
	nearestPlayers.ForEach(player => Console.WriteLine($"{player.Nickname} {player.Position}"));
}