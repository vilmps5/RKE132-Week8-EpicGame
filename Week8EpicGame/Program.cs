//string[] heroes = { "harry Potter", "Luke Skywalker", "Lara Croft", "Scooby-Doo" };
//string[] villains = { "voldemort", "Darth Vader", "Dracula", "Joker", "Sauron" };
//string[] weapon = { "magic wand", "plastic fork", "banana", "wooden sword", "Lego brick" };

string folderPath = @"C:\Users\Z620\source\repos\data";
string heroFile = "heroes.txt";
string villainFile = "villains.txt";
string weaponFile = "weapon.txt";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath,heroFile));
string[] villains = File.ReadAllLines(Path.Combine(folderPath, villainFile));
string[] weapon = File.ReadAllLines(Path.Combine(folderPath, weaponFile));

string hero = GetRandomValueFromArray(heroes);
string heroWeapon = GetRandomValueFromArray(weapon);
int heroHP = GetCharacterHP(hero);
int heroStrikeStrength = heroHP;

string villain = GetRandomValueFromArray(villains);
string villainWeapon = GetRandomValueFromArray(weapon);
int villainHP = GetCharacterHP(villain);
int villainStrikeStrength = villainHP;

Console.WriteLine($"Today {villain} ({villainHP}HP) with {villainWeapon} tries to take over the world!");
Console.WriteLine($"Your hero {hero} ({heroHP}HP) saves the day with {heroWeapon}!");

while(heroHP > 0 && villainHP > 0)
{
    heroHP = heroHP - Hit(villain, villainStrikeStrength);
    villainHP = villainHP - Hit(hero, heroStrikeStrength);
}

Console.WriteLine($"Hero {hero} {heroHP}HP");
Console.WriteLine($"Villain {villain} {villainHP}HP");

if (heroHP > 0)
{
    Console.WriteLine($"{hero} saves the day!");
}
else if(villainHP > 0)
{
    Console.WriteLine($"Dark side wins!");
}
else
{
    Console.WriteLine("Draw!");
}

static string GetRandomValueFromArray(string[] someArray)
{
    Random rnd = new Random();
    int randomIndex = rnd.Next(0, someArray.Length);
    string randomStringFromArray = someArray[randomIndex];
    return randomStringFromArray;
}

static int GetCharacterHP(string characterName)
{
    if (characterName.Length < 10)
    {
        return 10;
    }
    else
    {
        {
            return characterName.Length;
        }
    }
}

static int Hit(string characterName, int characterHP)
{
    Random rnd = new Random();
    int strike = rnd.Next(0, characterHP);

    if(strike == 0)
    {
        Console.WriteLine($"{characterName} missed the target!");
        
    }
    else if( strike == characterHP -1) 
    {
         Console.WriteLine($"{characterName} made a critical hit!");
    }
    else
    {
        Console.WriteLine($"{characterName} hit {strike}!");
    }
    return strike;
}