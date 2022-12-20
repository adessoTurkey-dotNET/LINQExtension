# LINQExtension
<br>

## What is LINQ

Language-Integrated Query (LINQ) is a powerful set of technologies based on the integration of query capabilities directly into the C# language. LINQ Queries are the first-class language construct in C# .NET, just like classes, methods, events. The LINQ provides a consistent query experience to query objects (LINQ to Objects), relational databases (LINQ to SQL), and XML (LINQ to XML).

LINQ (Language Integrated Query) is uniform query syntax in C# and VB.NET to retrieve data from different sources and formats. It is integrated in C# or VB, thereby eliminating the mismatch between programming languages and databases, as well as providing a single querying interface for different types of data sources.

<br>

## What is Extension Method
Extension methods enable you to "add" methods to existing types without creating a new derived type, recompiling, or otherwise modifying the original type. Extension methods are static methods, but they're called as if they were instance methods on the extended type. For client code written in C#, F# and Visual Basic, there's no apparent difference between calling an extension method and the methods defined in a type.

<br>

## What is Unit Test
Unit testing breaks the program down into the smallest bit of code, usually function-level, and ensures that the function returns the value one expects. By using a unit testing framework, the unit tests become a separate entity which can then run automated tests on the program as it is being built.

<br>
<hr>
<br>

In this project, we write our own methods without using the System.LINQ library.

        public static IEnumerable<T> Where<T>(this IEnumerable<T> list, Func<T, bool> predicate)
        {
            if (list == null)
                throw new ArgumentNullException("source");

            if (predicate == null)
                throw new ArgumentNullException("predicate");

            foreach (T item in list)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }


For example, we write the "Where" query by extending it ourselves. 
Whether this method is working correctly or not is confirmed by writing Unit Test.

        [Test]
        public void ExtensionLibrary_Where()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, };

            var result = numbers.Where(x => x > 5);

            Assert.AreEqual(result, new[] { 6 });
        }






