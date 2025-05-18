using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingSys
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AvailableSeats { get; set; }

        public Movie(int id, string title, int availableSeats)
        {
            Id = id;
            Title = title;
            AvailableSeats = availableSeats;
        }
    }

    public class Booking
    {
        public int BookingId { get; set; }
        public string MovieTitle { get; set; }
        public int SeatsBooked { get; set; }

        public Booking(int bookingId, string movieTitle, int seatsBooked)
        {
            BookingId = bookingId;
            MovieTitle = movieTitle;
            SeatsBooked = seatsBooked;
        }
    }

    internal class Movie_BookingSys
    {
        static List<Movie> movies = new List<Movie>();
        static List<Booking> bookings = new List<Booking>();
        static int bookingCounter = 1;

        static void Main(string[] args)
        {
            InitializeMovies();

            while (true)
            {
                Console.WriteLine("============================================");
                Console.WriteLine("||   Welcome to the Movie Booking System  ||");
                Console.WriteLine("============================================");
                Console.WriteLine("1. List Movies");
                Console.WriteLine("2. Book Tickets");
                Console.WriteLine("3. View Bookings");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ListMovies();
                        break;
                    case "2":
                        BookTickets();
                        break;
                    case "3":
                        ViewBookings();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void InitializeMovies()
        {
            movies.Add(new Movie(1, "Bramhayugam", 50));
            movies.Add(new Movie(2, "Sanju", 30));
            movies.Add(new Movie(3, "Baghi", 20));
            movies.Add(new Movie(4, "Chava", 30));
            movies.Add(new Movie(5, "Pushpa", 10));
            movies.Add(new Movie(6, "Inception", 5));
        }

        static void ListMovies()
        {
            Console.WriteLine("============================================");
            Console.WriteLine("||          Available Movies:             ||");
            Console.WriteLine("============================================");
            foreach (var movie in movies)
            {
                Console.WriteLine($"ID: {movie.Id},     ||    Title: {movie.Title},               Available Seats: {movie.AvailableSeats}");

            }
        }

        static void BookTickets()
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("|    Enter Movie ID to book:      |");
            Console.WriteLine("-----------------------------------");
            int movieId = int.Parse(Console.ReadLine());
            var movie = movies.Find(m => m.Id == movieId);

            if (movie == null)
            {
                Console.WriteLine("Movie not found.");
                return;
            }

            Console.Write("Enter number of seats to book: ");
            int seats = int.Parse(Console.ReadLine());

            if (seats > movie.AvailableSeats)
            {
                Console.WriteLine("Not enough seats available.");
                return;
            }

            movie.AvailableSeats -= seats;
            bookings.Add(new Booking(bookingCounter++, movie.Title, seats));

            Console.WriteLine("********************************************");
            Console.WriteLine("**                                        **");
            Console.WriteLine("**         Booking successful!            **");
            Console.WriteLine("**                                        **");
            Console.WriteLine("********************************************");
        }

        static void ViewBookings()
        {
            Console.WriteLine("=======================================================");
            Console.WriteLine("||         Your Bookings:                            ||");
            
            foreach (var booking in bookings)
            {
                Console.WriteLine($"||    Booking ID: {booking.BookingId}, Movie: {booking.MovieTitle}, Seats: {booking.SeatsBooked}      ||");
            }
            Console.WriteLine("=======================================================");
        }
    }
}

    

