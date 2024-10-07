using System;
using System.Collections.Generic;
using System.IO;

class TDL
{
    static string filePath = "tasks.txt";
    static List<string> tasks = new List<string>();

    static void Main(string[] args)
    {
        //Loads items from their tasks file
        LoadTasksFromFile();

        //Main program, continues until the user chooses to exit
        bool running = true;
        while (running)
        {
            //Shows all possible options to the user
            Console.Clear();
            Console.WriteLine("Welcome to your To-Do List");
            Console.WriteLine("1 - Add a task to my To-Do List");
            Console.WriteLine("2 - Remove an item from my To-Do List");
            Console.WriteLine("3 - Show me my To-Do List");
            Console.WriteLine("4 - Save and Exit");

            //User selecting an option
            Console.Write("\nPlease select an option (1-4): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":  //Adding a new task
                    AddTask();
                    break;

                case "2":  //Removing a task that already exists
                    RemoveTask();
                    break;

                case "3":  //Showing all tasks on the To-Do List
                    DisplayTasks();
                    break;

                case "4": //Saving tasks to the tasks file
                    SaveTasksToFile();
                    running = false;
                    break;

                default:  //If the user enters an invalid input, they're prompted to try again
                    Console.WriteLine("Invalid option. Please select a valid option (1-4).");
                    break;
            }
        }
    }

//-------------------------------------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------------------------------------

    //Adding a new task
    static void AddTask()
    {
        Console.Write("Enter the task: ");
        string task = Console.ReadLine();
        tasks.Add(task);

        Console.WriteLine("The task has been Successfully added!, Press any key to continue ...");
        Console.ReadKey();  //Checks if the user presses a key before continuing
    }

//-------------------------------------------------------------------------------------------------------------------------------------------

    //Removing a task from the list by number
    static void RemoveTask()
    {
        if (tasks.Count == 0)  //Checks if the list is empty, and if it is then the console writeline statement will be displayed to the user
        {
            Console.WriteLine("There aren't any tasks in the list.");
        }

        else
        {
            DisplayTasks();  //Shows the list of tasks
            Console.Write("Enter the task number to remove: ");
            int taskNumber;
            
            if (int.TryParse(Console.ReadLine(), out taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
            {
                tasks.RemoveAt(taskNumber - 1);
                Console.WriteLine("The task has been Successfully removed.");
            }
            else
            {
                Console.WriteLine("You've entered an invalid task number.");
            }
        }

        Console.WriteLine("Press any key to continue ...");
        Console.ReadKey();
    }

//-------------------------------------------------------------------------------------------------------------------------------------------

    //Showing all tasks
    static void DisplayTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("There aren't any tasks in the list.");
        }
        else
        {
            Console.WriteLine("\nYour Tasks:  ");
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }

        Console.WriteLine("\nPress any key to continue ...");
        Console.ReadKey();
    }

//-------------------------------------------------------------------------------------------------------------------------------------------

    //Saving tasks to the tasks file
    static void SaveTasksToFile()
    {
        File.WriteAllLines(filePath, tasks);
        Console.WriteLine("Your Tasks have been saved, Goodbye.");
    }

//-------------------------------------------------------------------------------------------------------------------------------------------

    //Loading tasks from the tasks file
    static void LoadTasksFromFile()
    {
        if (File.Exists(filePath))  //Checking if the file exists
        {
            tasks = new List<string>(File.ReadAllLines(filePath));  //Load tasks from the file onto the list
        }
    }
}
