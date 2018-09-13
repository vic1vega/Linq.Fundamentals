using LinqToObjects.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LinqToObjects
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Data data;

        public MainWindow()
        {
            InitializeComponent();

        }

        private void btnInit_Click(object sender, RoutedEventArgs e)
        {
            data = new Data();

            // Struktura LINQ
            var listOfEmployees = data.Employees
                .Where((s) => s.FirstName == "Dawid")
                .Select(s => s.FullName);


        }

        private void btnSortEmployeesAsc_Click(object sender, RoutedEventArgs e)
        {
            var notSortedEmployees = data.Employees;
            notSortedEmployees.ForEach(w => Console.WriteLine(w.FullName));

            var sortedEmployees = data.Employees.OrderBy(s => s.FirstName).ThenBy(s => s.LastName);
            sortedEmployees.ToList().ForEach(w => Console.WriteLine(w.FullName));
        }

        private void btnSortEmployeesDesc_Click(object sender, RoutedEventArgs e)
        {
            var sortedEmployees = data.Employees.OrderByDescending(s => s.FirstName).ThenByDescending(s => s.LastName);
            sortedEmployees.ToList().ForEach(w => Console.WriteLine(w.FullName));
        }

        private void btnDisplayByName_Click(object sender, RoutedEventArgs e)
        {
            string filter = txtEmployeeName.Text;

            var filteredEmployees = data.Employees
                .Where(s => s.FirstName.StartsWith("M") && s.LastName == filter)
                .Select(s => new { s.FirstName, s.LastName });

            filteredEmployees.ToList().ForEach(w => Console.WriteLine(w.LastName));
        }

        private void btnGroupByName_Click(object sender, RoutedEventArgs e)
        {
            var groupedObjects = data.Employees.GroupBy(s => new { s.LastName, s.FirstName })
                .Where(s => s.Any(t=> t.FirstName == "Dawid"));

            groupedObjects.ToList().ForEach(s =>
            {
                Console.WriteLine(s.Key);
                s.ToList().ForEach(w => Console.WriteLine("     " + w.FirstName));
            }); 
        }

        private void btnJobs_Click(object sender, RoutedEventArgs e)
        {
            var allJobs = data.Employees.SelectMany(s => s.Jobs);
            allJobs.ToList().ForEach(w => Console.WriteLine(w.Title));
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Console.Clear();
        }

        private void btnConcatenation1_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<int> firstArray = Enumerable.Range(0, 5);
            IEnumerable<int> secondArray = Enumerable.Range(3, 6);

            IEnumerable<int> concat = firstArray.Concat(secondArray);


            Console.WriteLine("Pierwsza kolekcja");
            Console.Write(String.Join(",", firstArray));
            Console.WriteLine();


            Console.WriteLine("Druga kolekcja");
            Console.Write(String.Join(",", secondArray));
            Console.WriteLine();


            Console.WriteLine("Wynik łączenia");
            Console.Write(String.Join(",", concat));
            Console.WriteLine();

        }

        private void btnExcept_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<int> firstArray = Enumerable.Range(0, 5);
            IEnumerable<int> secondArray = Enumerable.Range(3, 6);

            IEnumerable<int> exept = firstArray.Except(secondArray);


            Console.WriteLine("Pierwsza kolekcja");
            Console.Write(String.Join(",", firstArray));
            Console.WriteLine();

            Console.WriteLine("Druga kolekcja");
            Console.Write(String.Join(",", secondArray));
            Console.WriteLine();


            Console.WriteLine("Wynik różnicy");
            Console.Write(String.Join(",", exept));
            Console.WriteLine();

        }

        private void btnUnion_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<int> firstArray = Enumerable.Range(0, 5);
            IEnumerable<int> secondArray = Enumerable.Range(3, 6);

            IEnumerable<int> union = firstArray.Union(secondArray);


            Console.WriteLine("Pierwsza kolekcja");
            Console.Write(String.Join(",", firstArray));
            Console.WriteLine();

            Console.WriteLine("Druga kolekcja");
            Console.Write(String.Join(",", secondArray));
            Console.WriteLine();


            Console.WriteLine("Wynik łączenia");
            Console.Write(String.Join(",", union));
            Console.WriteLine();

        }

        private void btnIntersect_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<int> firstArray = Enumerable.Range(0, 5);
            IEnumerable<int> secondArray = Enumerable.Range(3, 6);

            IEnumerable<int> intersect = firstArray.Intersect(secondArray);


            Console.WriteLine("Pierwsza kolekcja");
            Console.Write(String.Join(",", firstArray));
            Console.WriteLine();


            Console.WriteLine("Druga kolekcja");
            Console.Write(String.Join(",", secondArray));
            Console.WriteLine();



            Console.WriteLine("Wynik łączenia");
            Console.Write(String.Join(",", intersect));
            Console.WriteLine();

        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            // Inne testy
            //Random rand = new Random();

            //var employeeToTest = data.Employees.ElementAt(rand.Next(0, data.Employees.Count()));

            //if (data.Employees.Contains(employeeToTest))
            //{
            //    Console.WriteLine("Obiekt istnieje w kolekcji pracowników");
            //}
            //else
            //{
            //    Console.WriteLine("Obiekt nie istnieje w kolekcji pracowników");
            //}

            var firstElement = data.Employees
                .Where(s => s.FirstName == "Mariola")
                .OrderByDescending(s => s.LastName)
                .FirstOrDefault();

            firstElement = data.Employees
                .Where(s => s.FirstName == "Mariola")
                .OrderByDescending(s => s.LastName)
                .LastOrDefault();

            firstElement = data.Employees
                .Where(s => s.FirstName == "Mariola" && s.LastName == "Kowalski")
                .SingleOrDefault();

            firstElement = data.Employees
                .Where(s => s.FirstName == "Mariola")
                .OrderByDescending(s => s.LastName)
                .First();

            firstElement = data.Employees
                .Where(s => s.FirstName == "Mariola")
                .OrderByDescending(s => s.LastName)
                .Last();

            firstElement = data.Employees
                .Where(s => s.FirstName == "Mariola" && s.LastName == "Kowalski")
                .Single();

            Console.WriteLine(firstElement.FullName);
        }
    }
}
