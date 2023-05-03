
using System;
using System.Collections.Generic;



namespace Note_APPASS
{
    class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }

    class Program
    {
        static List<Note> notes = new List<Note>();

        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Enter your choice:");
                Console.WriteLine("1. Create Note");
                Console.WriteLine("2. View Note");
                Console.WriteLine("3. View All Notes");
                Console.WriteLine("4. Update Note");
                Console.WriteLine("5. Delete Note");
                Console.WriteLine("6. Exit");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            CreateNote();
                            break;
                        case 2:
                            ViewNote();
                            break;
                        case 3:
                            ViewAllNotes();
                            break;
                        case 4:
                            UpdateNote();
                            break;
                        case 5:
                            DeleteNote();
                            break;

                        default:
                            Console.WriteLine("Wrong Choice Entered!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong Choice Entered!");
                }
            }
        }

        static void CreateNote()
        {
            Console.Write("Enter title: ");
            string title = Console.ReadLine();

            Console.Write("Enter description: ");
            string description = Console.ReadLine();

            Note note = new Note
            {
                Id = notes.Count + 1,
                Title = title,
                Description = description,
                Date = DateTime.Now
            };
            notes.Add(note);
            Console.WriteLine("Note created successfully.");
        }

        static void ViewNote()
        {
            Console.Write("Enter id of the note: ");
            int id;
            if (int.TryParse(Console.ReadLine(), out id))
            {
                Note note = notes.Find(n => n.Id == id);
                if (note != null)
                {
                    Console.WriteLine($"id: {note.Id}\nTitle: {note.Title}\nDescription: {note.Description}\nDate: {note.Date}");
                }
                else
                {
                    Console.WriteLine("Note not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid id entered.");
            }
        }

        static void ViewAllNotes()
        {
            Console.WriteLine("id\tTitle\tDescription\tDate");
            foreach (Note note in notes)
            {
                Console.WriteLine($"{note.Id}\t{note.Title}\t{note.Description}\t\t{note.Date.ToShortDateString()}");
            }
            Console.WriteLine($"Total Notes: {notes.Count}");
        }

        static void UpdateNote()
        {
            Console.Write("Enter id of the note: ");
            int id;
            if (int.TryParse(Console.ReadLine(), out id))
            {
                Note note = notes.Find(n => n.Id == id);
                if (note != null)
                {
                    Console.Write("Enter new title: ");
                    note.Title = Console.ReadLine();

                    Console.Write("Enter new description: ");
                    note.Description = Console.ReadLine();

                    note.Date = DateTime.Now;
                    Console.WriteLine("Note updated successfully.");
                }
                else
                {
                    Console.WriteLine("Note not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid id entered.");
            }
        }

        static void DeleteNote()
        {
            Console.WriteLine("Enter the id of the note to delete:");
            int id = int.Parse(Console.ReadLine());

            Note note = notes.Find(n => n.Id == id); // Find note by id

            if (note != null)
            {
                notes.Remove(note); // Remove note from list
                Console.WriteLine("Note deleted successfully.");
            }
            else
            {
                Console.WriteLine("Note with id {0} not found.", id);
            }
        }
    }
}