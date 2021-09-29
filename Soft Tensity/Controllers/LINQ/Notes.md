# LINQ Learning Notes

## GroupBy
Group By groups a collection in multiple collections.
We need to indicate which is the key used to generate the groups.
Each result group, has a key, and a collection of items, the same time from where we made the groups.

Imagine we have a stuent list with id, name, and age

### QuerySintax to group by age
var groupedResult = from s in studentList
                    group s by s.Age;

we can then itearte over groups:
foreach (var ageGroup in groupedResult)
{
    Console.WriteLine("Age Group: {0}", ageGroup.Key); //Each group has a key 
             
    foreach(Student s in ageGroup) // Each group has inner collection
        Console.WriteLine("Student Name: {0}", s.StudentName);
}

As this is a Collection, we can make LINQ queries after the group by
