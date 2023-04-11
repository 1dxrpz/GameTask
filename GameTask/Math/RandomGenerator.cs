namespace GameTask.Math
{
	public class RandomGenerator
	{
        string[] nouns =
        {
            "people",
            "skill",
            "community",
            "income",
            "description",
            "housing",
            "accident",
            "flight",
            "construction",
            "pizza",
            "chest",
            "argument",
            "birthday",
            "interaction",
            "bedroom",
            "freedom",
            "difficulty",
            "dirt",
            "direction",
            "personality",
            "nature",
            "vehicle",
            "inspection",
            "poem",
            "county",
            "grocery",
            "orange",
            "army",
            "poetry",
            "apple",
            "newspaper",
            "tennis",
            "consequence",
            "food",
            "two",
            "employment",
            "goal",
            "anxiety",
            "drama",
            "economics",
            "alcohol",
            "reputation",
            "writer",
            "mud",
            "drawing",
            "height",
            "speaker",
            "health",
            "outcome",
            "blood"
        };
        string[] adjectives = {
            "breakable",
            "breezy",
            "gusty",
            "helpless",
            "disastrous",
            "small",
            "wasteful",
            "efficient",
            "abandoned",
            "complex",
            "murky",
            "fluffy",
            "flowery",
            "steep",
            "violent",
            "confused",
            "scandalous",
            "naive",
            "finicky",
            "mindless",
            "curious",
            "dramatic",
            "alive",
            "obsequious",
            "confident",
            "real",
            "imperfect",
            "earsplitting",
            "overwrought",
            "uptight",
            "brawny",
            "southern",
            "terrible",
            "innocent",
            "hesitant",
            "past",
            "alluring",
            "threatening",
            "thoughtless",
            "overconfident",
            "forgetful",
            "wet",
            "draconian",
            "invincible",
            "outgoing",
            "measly",
            "psychedelic",
            "incompetent",
            "instinctive",
            "billowy"
        };
        Random random = new Random();
        public string GenerateName()
		{
            string result = "";
            
            for (int i = 0; i < 2; i++)
			{
                result += adjectives[random.Next(49)];
                result += " ";
            }
            result += nouns[random.Next(49)];
            return result;
        }
        public string GenerateNickname()
		{
            string result = "";
            if (random.Next(0, 100) <= 5)
                result += "_";
            for (int i = 0; i < random.Next(2, 5); i++)
            {
                string adj = adjectives[random.Next(49)].Substring(0, 2);
                if (random.Next(0, 100) <= 40)
                    adj = adj.ToUpper();
                result += adj;
            }
            result += nouns[random.Next(49)].Substring(0, 2);
            if (random.Next(0, 100) <= 30)
                result += random.Next(0, 200);
            if (random.Next(0, 100) <= 10)
                result += "_";
            return result;
        }
	}
}
