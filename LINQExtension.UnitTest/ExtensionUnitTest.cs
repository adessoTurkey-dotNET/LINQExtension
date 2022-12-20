using LINQExtension.Entity;
using LINQExtension.Library;
using NUnit.Framework;
using System.Collections.Generic;

namespace LINQExtension.UnitTest
{
    public class ExtensionUnitTest
    {
        [Test]
        public void ExtensionLibrary_Where()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, };

            var result = numbers.Where(x => x > 5);

            Assert.AreEqual(result, new[] { 6 });
        }

        [Test]
        public void ExtensionLibrary_WhereFirstOrDefault()
        {
            List<User> users = new();
            var emp1 = new User() { Id = 1, Name = "Ahmet" };
            var emp2 = new User() { Id = 2, Name = "Ahmet" };
            var emp3 = new User() { Id = 3, Name = "Zehra" };
            var emp4 = new User() { Id = 4, Name = "Recep" };
            var emp5 = new User() { Id = 5, Name = "Ayşe" };
            var emp6 = new User() { Id = 6, Name = "Zehra" };
            var emp7 = new User() { Id = 7, Name = "Fatma" };
            users.Add(emp1);
            users.Add(emp2);
            users.Add(emp3);
            users.Add(emp4);
            users.Add(emp5);
            users.Add(emp6);
            users.Add(emp7);

            var result = users.WhereFirstOrDefault(x => x.Name == "Zehra");

            Assert.AreEqual(result, emp3);
        }

        [Test]
        public void ExtensionLibrary_WhereLastOrDefault()
        {
            List<User> employees = new();
            var emp1 = new User() { Id = 1, Name = "Ahmet" };
            var emp2 = new User() { Id = 2, Name = "Ahmet" };
            var emp3 = new User() { Id = 3, Name = "Zehra" };
            var emp4 = new User() { Id = 4, Name = "Recep" };
            var emp5 = new User() { Id = 5, Name = "Ayşe" };
            var emp6 = new User() { Id = 6, Name = "Zehra" };
            var emp7 = new User() { Id = 7, Name = "Fatma" };
            employees.Add(emp1);
            employees.Add(emp2);
            employees.Add(emp3);
            employees.Add(emp4);
            employees.Add(emp5);
            employees.Add(emp6);
            employees.Add(emp7);

            var result = employees.WhereLastOrDefault(x => x.Name == "Zehra");

            Assert.AreEqual(result, emp6);
        }

        [Test]
        public void ExtensionLibrary_LazyReverse()
        {
            var numbers = new int[] { 1, 2, 3, 4 };
            var reversedNumber = new int[] { 4, 3, 2, 1 };

            int index = 0;
            foreach (var item in numbers.LazyReverse())
            {
                Assert.AreEqual(item, reversedNumber[index]);
                index++;
            }
        }

        [Test]
        public void ExtensionLibrary_Take()
        {
            var numbers = new int[] { 5, 5, 3, 4, 5, 6 };

            var newNumbers = numbers.Take(2);

            Assert.AreEqual(newNumbers, new int[] { 5, 5, 3 });
        }

        [Test]
        public void ExtensionLibrary_Skip()
        {
            var numbers = new int[] { 8, 9, 6, 2, 3, 1 };

            var newNumbers = numbers.Skip(4);

            Assert.AreEqual(newNumbers, new int[] { 3, 1 });
        }

        [Test]
        public void ExtensionLibrary_Max()
        {
            var numbers = new int[] { 8, 9, 6, 2, 3, 1 };

            var newNumbers = numbers.Max();

            Assert.AreEqual(newNumbers, 9);
        }

        [Test]
        public void ExtensionLibrary_Min()
        {
            var numbers = new int[] { 8, 9, 6, 2, 3, 1 };

            var newNumbers = numbers.Min();

            Assert.AreEqual(newNumbers, 1);
        }

        [Test]
        public void ExtensionLibrary_SUM()
        {
            var numbers = new int[] { 8, 9 };

            var number = numbers.SUM();

            Assert.AreEqual(number, 17);
        }

        [Test]
        public void ExtensionLibrary_Count()
        {
            var numbers = new int[] { 8, 9, 5 };

            var number = numbers.Count();

            Assert.AreEqual(number, 3);
        }

        [Test]
        public void ExtensionLibrary_CountWıthPredicate()
        {
            List<User> users = new();
            users.Add(new User() { Id = 1, Name = "Ahmet" });
            users.Add(new User() { Id = 2, Name = "Ahmet" });
            users.Add(new User() { Id = 3, Name = "Zehra" });
            users.Add(new User() { Id = 4, Name = "Recep" });
            users.Add(new User() { Id = 5, Name = "Ayşe" });
            users.Add(new User() { Id = 6, Name = "Zehra" });
            users.Add(new User() { Id = 7, Name = "Fatma" });

            var number = users.Count(x=>x.Id>5);

            Assert.AreEqual(number, 2);
        }

        [Test]
        public void ExtensionLibrary_IndexOf()
        {
            var numbers = new int[] { 8, 9, 5 };

            var number = numbers.IndexOf(9);

            Assert.AreEqual(number, 1);
        }

        [Test]
        public void ExtensionLibrary_Concat()
        {
            var numbers = new int[] { 8, 9, 5 };
            var numbers2 = new int[] { 3, 1, 7 };

            var newNumbers = numbers.Concat(numbers2);

            Assert.AreEqual(newNumbers, new int[] { 8, 9, 5, 3, 1, 7 });
        }

        [Test]
        public void ExtensionLibrary_Union()
        {
            var numbers = new int[] { 8, 9, 5, 8 };
            var numbers2 = new int[] { 3, 1, 7, 5 };

            var newNumbers = numbers.Union(numbers2);

            Assert.AreEqual(newNumbers, new int[] { 8, 9, 5, 3, 1, 7 });
        }

        [Test]
        public void ExtensionLibrary_Except()
        {
            var numbers = new int[] { 8, 9, 5, 8 };
            var numbers2 = new int[] { 3, 1, 7, 5 };

            var newNumbers = numbers.Except(numbers2);

            Assert.AreEqual(newNumbers, new int[] { 8, 9 });
        }

        [Test]
        public void ExtensionLibrary_Average()
        {
            var numbers = new int[] { 8, 6, 4 };

            var average = numbers.Average();

            Assert.AreEqual(average, 6);
        }

        [Test]
        public void ExtensionLibrary_Intersect()
        {
            var numbers = new int[] { 8, 9, 5, 5 };
            var numbers2 = new int[] { 3, 1, 7, 5 };

            var newNumbers = numbers.Intersect(numbers2);

            Assert.AreEqual(newNumbers, new int[] { 5 });
        }

        [Test]
        public void ExtensionLibrary_First()
        {
            var numbers = new int[] { 8, 9, 5, 5 };

            var newNumbers = numbers.First();

            Assert.AreEqual(newNumbers, 8);
        }

        [Test]
        public void ExtensionLibrary_DistinctBy()
        {
            List<User> users= new List<User>();
            users.Add(new User() { Name="Ali"});
            users.Add(new User() { Name = "Ayşe" });
            users.Add(new User() { Name="Ali" });

            var obj = users.DistinctBy(x => x.Name);
            
            users.RemoveAt(users.Count - 1);
            Assert.AreEqual(obj, users);
        }

        [Test]
        public void ExtensionLibrary_JoinStrings()
        {
            var users = new string[] { "Ahmet", "Mehmet" };

            var obj = users.JoinStrings(",");

            var names = "Ahmet,Mehmet";

            Assert.AreEqual(obj, names);
        }
    }
}
