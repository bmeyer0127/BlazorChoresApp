namespace BlazorChoresApp.Data;

public class SeedDb
{
  private readonly string[] _names = new[] {
    "Brett",
    "Kylie",
    "Kaleb",
    "Alyssa",
    "Bear",
    "Ashe",
    "Alyvia",
    "Oli",
    "Justin",
    "Mary"
  };

  private readonly string[] _choreNames = new[] {
    "Laundry",
    "Fold clothes",
    "Clean bathroom",
    "Vacuum",
    "Eat a fat shit",
    "Dishes",
    "Clean kitchen",
    "Take a walk",
    "Declutter",
    "Litter box"
  };

  private string RandomListItem(string[] list)
  {
    int index = Random.Shared.Next(list.Length - 1);
    return list[index];
  }

  private Person MakePerson(string name)
  {
    var person = new Person
    {
      Name = name
    };

    return person;
  }

  private Chore MakeChore()
  {
    var chore = new Chore
    {
      ChoreName = RandomListItem(_choreNames),
      CompletionStatus = RandomListItem(Chore.CompletionStatusOptions),
      PersonId = Random.Shared.Next(_names.Length - 1)
    };

    return chore;
  }

  public async Task SeedDatabaseWithContactCountOfAsync(ChoresContext context, int totalCount)
  {
    // Seed Person table
    var personList = new List<Person>();
    foreach (var person in _names)
    {
      personList.Add(MakePerson(person));
    }
    context.Persons.AddRange(personList);
    // await context.SaveChangesAsync();

    // Seed Chore table
    var count = 0;
    var currentCycle = 0;
    while (count < totalCount)
    {
      var choreList = new List<Chore>();
      while (currentCycle <= 15 && count <= totalCount)
      {
        choreList.Add(MakeChore());
      }
      if (choreList.Count > 0)
      {
        context.Chores?.AddRange(choreList);
        await context.SaveChangesAsync();
      }
      currentCycle = 0;
    }
  }
}