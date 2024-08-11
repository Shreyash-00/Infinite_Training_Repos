using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Server=ICS-LT-JN27893;Database=project01;Trusted_Connection=True;";

        Console.WriteLine();
        Console.WriteLine("(--------------------------------WELCOME TO RAIL RESERVATION------------------------------------)");
        Console.WriteLine();


        Console.WriteLine("Are you an Admin or User? (Enter 'Admin' or 'User'):");
        string userType = Console.ReadLine().Trim().ToLower();

        if (userType == "user")
        {
            Console.WriteLine("Enter Username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter UserPassword:");
            string userPassword = Console.ReadLine();

            int userId = AuthenticateUser(connectionString, username, userPassword);
            if (userId != -1)
            {
                UserMenu(connectionString, userId);
            }
            else
            {
                Console.WriteLine("Invalid username or UserPassword.");
                Console.ReadLine();
                
            }
        }
        else if (userType == "admin")
        {
            Console.WriteLine("Enter Admin Username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter Admin Password:");
            string userPassword = Console.ReadLine();

            if (AuthenticateAdmin(connectionString, username, userPassword))
            {
                AdminMenu(connectionString);
            }
            else
            {
                Console.WriteLine("Invalid admin username or password.");
                Console.ReadLine();
             
            }
        }
        else
        {
            Console.WriteLine("Invalid option selected.");
            Console.ReadLine();
        }
    }

    static int AuthenticateUser(string connectionString, string username, string userPassword)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT UserID FROM Users_new_2 WHERE Username = @Username AND UserPassword = @UserPassword", conn);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@UserPassword", userPassword);

            object result = cmd.ExecuteScalar();
            return result != null ? (int)result : -1;
        }
    }


    static bool AuthenticateAdmin(string connectionString, string username, string userPassword)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Admin WHERE Username = @Username AND UserPassword = @UserPassword", conn);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@UserPassword", userPassword);

            int adminCount = (int)cmd.ExecuteScalar();
            return adminCount > 0;
        }
    }

    static void UserMenu(string connectionString, int userId)
    {
        while (true)
        {
            Console.WriteLine("Select an option: 1. Booking 2. Cancellation 3. Booking Details 4. Exit");
            int option = Convert.ToInt32(Console.ReadLine());

            if (option == 1)
            {
                HandleBooking(connectionString, userId);
            }
            else if (option == 2)
            {
                HandleCancellation(connectionString, userId);
            }
            else if (option == 3)
            {
                ShowBookingDetails(connectionString, userId);
            }
            else if (option == 4)
            {
                Console.WriteLine("Exiting...");
                break;
            }
            else
            {
                Console.WriteLine("Invalid option selected.");
            }
        }
    }



    static void AdminMenu(string connectionString)
    {
        while (true)
        {
            Console.WriteLine("Select an option: 1. Add New Train with Existing Stations 2. Add Existing Train to New Stations 3. Add NEw Train and New Stations");
            int option = Convert.ToInt32(Console.ReadLine());

            if (option == 1)
            {
                AddNewTrainWithExistingStations(connectionString);
            }
            else if (option == 2)
            {
                AddExistingTrainToNewStations(connectionString);
            }
            else if (option == 3)
            {
                AddTrain(connectionString);
            }
            else if (option == 4)
            {
                Console.WriteLine("Exiting...");
                break;
            }
            else
            {
                Console.WriteLine("Invalid option selected.");
            }
        }
    }




    static void AddNewTrainWithExistingStations(string connectionString)
    {
        try
        {
            Console.WriteLine("Enter Train Number:");
            if (!int.TryParse(Console.ReadLine(), out int trainNo))
            {
                Console.WriteLine("Invalid Train Number. Please enter a valid integer.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Check if train number already exists
                SqlCommand checkTrainCmd = new SqlCommand("SELECT COUNT(*) FROM Trains_new WHERE tno = @TrainNo", conn);
                checkTrainCmd.Parameters.AddWithValue("@TrainNo", trainNo);
                int trainCount = (int)checkTrainCmd.ExecuteScalar();

                if (trainCount > 0)
                {
                    Console.WriteLine("The train number already exists. Please provide a new train number.");
                    return;
                }

                // Input train details
                Console.WriteLine("Enter Train Name:");
                string trainName = Console.ReadLine();
                if (string.IsNullOrEmpty(trainName))
                {
                    Console.WriteLine("Train Name cannot be empty.");
                    return;
                }

                Console.WriteLine("Enter Train Type (Express/Superfast):");
                string trainType = Console.ReadLine();
                if (string.IsNullOrEmpty(trainType))
                {
                    Console.WriteLine("Train Type cannot be empty.");
                    return;
                }

                Console.WriteLine("Enter Train Status (active/inactive):");
                string trainStatus = Console.ReadLine();
                if (string.IsNullOrEmpty(trainStatus))
                {
                    Console.WriteLine("Train Status cannot be empty.");
                    return;
                }

                Console.WriteLine("Enter Class of Travel:");
                string classOfTravel = Console.ReadLine();
                if (string.IsNullOrEmpty(classOfTravel))
                {
                    Console.WriteLine("Class of Travel cannot be empty.");
                    return;
                }

                Console.WriteLine("Enter Distance:");
                if (!int.TryParse(Console.ReadLine(), out int distance))
                {
                    Console.WriteLine("Invalid Distance. Please enter a valid integer.");
                    return;
                }

                Console.WriteLine("Enter Price:");
                if (!decimal.TryParse(Console.ReadLine(), out decimal price))
                {
                    Console.WriteLine("Invalid Price. Please enter a valid decimal number.");
                    return;
                }

                Console.WriteLine("Enter Availability:");
                if (!int.TryParse(Console.ReadLine(), out int availability))
                {
                    Console.WriteLine("Invalid Availability. Please enter a valid integer.");
                    return;
                }

                // Input existing source station details
                Console.WriteLine("Enter Source Station ID:");
                if (!int.TryParse(Console.ReadLine(), out int sourceStationId))
                {
                    Console.WriteLine("Invalid Source Station ID. Please enter a valid integer.");
                    return;
                }

                // Check if source station exists
                SqlCommand checkSourceCmd = new SqlCommand("SELECT COUNT(*) FROM Stations_new WHERE station_id = @StationID", conn);
                checkSourceCmd.Parameters.AddWithValue("@StationID", sourceStationId);
                int sourceStationCount = (int)checkSourceCmd.ExecuteScalar();

                if (sourceStationCount == 0)
                {
                    Console.WriteLine("The source station ID does not exist. Please provide an existing station ID.");
                    return;
                }

                // Input existing destination station details
                Console.WriteLine("Enter Destination Station ID:");
                if (!int.TryParse(Console.ReadLine(), out int destinationStationId))
                {
                    Console.WriteLine("Invalid Destination Station ID. Please enter a valid integer.");
                    return;
                }

                // Check if destination station exists
                SqlCommand checkDestinationCmd = new SqlCommand("SELECT COUNT(*) FROM Stations_new WHERE station_id = @StationID", conn);
                checkDestinationCmd.Parameters.AddWithValue("@StationID", destinationStationId);
                int destinationStationCount = (int)checkDestinationCmd.ExecuteScalar();

                if (destinationStationCount == 0)
                {
                    Console.WriteLine("The destination station ID does not exist. Please provide an existing station ID.");
                    return;
                }

                // If all checks pass, proceed to add the train
                SqlCommand cmd = new SqlCommand("AddNewTrainWithExistingStations", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TrainNo", trainNo);
                cmd.Parameters.AddWithValue("@TrainName", trainName);
                cmd.Parameters.AddWithValue("@TrainType", trainType);
                cmd.Parameters.AddWithValue("@TrainStatus", trainStatus);
                cmd.Parameters.AddWithValue("@ClassOfTravel", classOfTravel);
                cmd.Parameters.AddWithValue("@Distance", distance);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@Availability", availability);
                cmd.Parameters.AddWithValue("@SourceStationID", sourceStationId);
                cmd.Parameters.AddWithValue("@DestinationStationID", destinationStationId);

                cmd.ExecuteNonQuery();
                Console.WriteLine("New train added using existing stations successfully!");
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine("A database error occurred: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }


    static void AddExistingTrainToNewStations(string connectionString)
    {
        try
        {
            Console.WriteLine("Enter Train Number:");
            int trainNo = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Check train exist
                SqlCommand checkTrainCmd = new SqlCommand("SELECT COUNT(*) FROM Trains_new WHERE tno = @TrainNo", conn);
                checkTrainCmd.Parameters.AddWithValue("@TrainNo", trainNo);
                int trainCount = (int)checkTrainCmd.ExecuteScalar();

                if (trainCount == 0)
                {
                    Console.WriteLine("The train number does not exist. Please select from existing train numbers.");
                    return;
                }

                // Input new source station details
                Console.WriteLine("Enter Source Station ID:");
                int sourceStationId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Source Station Name:");
                string sourceStationName = Console.ReadLine();

                // Check if the source station already exists
                SqlCommand checkSourceStationCmd = new SqlCommand("SELECT COUNT(*) FROM Stations_new WHERE station_id = @SourceStationID OR station_name = @SourceStationName", conn);
                checkSourceStationCmd.Parameters.AddWithValue("@SourceStationID", sourceStationId);
                checkSourceStationCmd.Parameters.AddWithValue("@SourceStationName", sourceStationName);
                int sourceStationCount = (int)checkSourceStationCmd.ExecuteScalar();

                if (sourceStationCount > 0)
                {
                    Console.WriteLine("The source station already exists. Please enter a new station ID and name.");
                    return;
                }

                // Input new destination station details
                Console.WriteLine("Enter Destination Station ID:");
                int destinationStationId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Destination Station Name:");
                string destinationStationName = Console.ReadLine();

                // Check if the destination station already exists
                SqlCommand checkDestinationStationCmd = new SqlCommand("SELECT COUNT(*) FROM Stations_new WHERE station_id = @DestinationStationID OR station_name = @DestinationStationName", conn);
                checkDestinationStationCmd.Parameters.AddWithValue("@DestinationStationID", destinationStationId);
                checkDestinationStationCmd.Parameters.AddWithValue("@DestinationStationName", destinationStationName);
                int destinationStationCount = (int)checkDestinationStationCmd.ExecuteScalar();

                if (destinationStationCount > 0)
                {
                    Console.WriteLine("The destination station already exists. Please enter a new station ID and name.");
                    return;
                }

                // If all checks pass, proceed to add the train to new stations
                SqlCommand cmd = new SqlCommand("AddExistingTrainToNewStations", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TrainNo", trainNo);
                cmd.Parameters.AddWithValue("@SourceStationID", sourceStationId);
                cmd.Parameters.AddWithValue("@SourceStationName", sourceStationName);
                cmd.Parameters.AddWithValue("@DestinationStationID", destinationStationId);
                cmd.Parameters.AddWithValue("@DestinationStationName", destinationStationName);

                cmd.ExecuteNonQuery();
                Console.WriteLine("Existing train added to new stations successfully!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }









    static void AddTrain(string connectionString)
    {
        Console.WriteLine("Enter Train Number:");
        int trainNo = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Train Name:");
        string trainName = Console.ReadLine();
        Console.WriteLine("Enter Train Type (Express/Superfast):");
        string trainType = Console.ReadLine();
        Console.WriteLine("Enter Train Status (active/inactive):");
        string trainStatus = Console.ReadLine();
        Console.WriteLine("Enter Class of Travel:");
        string classOfTravel = Console.ReadLine();
        Console.WriteLine("Enter Distance:");
        int distance = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Price:");
        decimal price = Convert.ToDecimal(Console.ReadLine());
        Console.WriteLine("Enter Availability:");
        int availability = Convert.ToInt32(Console.ReadLine());

        // Input source station details
        Console.WriteLine("Enter Source Station ID:");
        int sourceStationId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Source Station Name:");
        string sourceStationName = Console.ReadLine();

        // Input destination station details
        Console.WriteLine("Enter Destination Station ID:");
        int destinationStationId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Destination Station Name:");
        string destinationStationName = Console.ReadLine();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("AddTrain", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@TrainNo", trainNo);
            cmd.Parameters.AddWithValue("@TrainName", trainName);
            cmd.Parameters.AddWithValue("@TrainType", trainType);
            cmd.Parameters.AddWithValue("@TrainStatus", trainStatus);
            cmd.Parameters.AddWithValue("@ClassOfTravel", classOfTravel);
            cmd.Parameters.AddWithValue("@Distance", distance);
            cmd.Parameters.AddWithValue("@Price", price);
            cmd.Parameters.AddWithValue("@Availability", availability);
            cmd.Parameters.AddWithValue("@SourceStationID", sourceStationId);
            cmd.Parameters.AddWithValue("@SourceStationName", sourceStationName);
            cmd.Parameters.AddWithValue("@DestinationStationID", destinationStationId);
            cmd.Parameters.AddWithValue("@DestinationStationName", destinationStationName);

            cmd.ExecuteNonQuery();
            Console.WriteLine("Train added successfully!");
        }
    }

    static void HandleBooking(string connectionString, int userId)
    {
        while (true)
        {
            Console.WriteLine("Enter Source Station:");
            string sourceStation = Console.ReadLine();
            Console.WriteLine("Enter Destination Station:");
            string destinationStation = Console.ReadLine();

            bool trainsAvailable = GetTrainOptions(connectionString, sourceStation, destinationStation);

            if (!trainsAvailable)
            {
                Console.WriteLine("No trains available between these stations.");
                Console.WriteLine("Would you like to try again? (yes/no)");
                string response = Console.ReadLine();
                if (response.Trim().ToLower() != "yes")
                {
                    break;
                }
            }
            else
            {
                Console.WriteLine("Enter Price ID to book:");
                int selectedPriceId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter number of seats to book (1 to 3):");
                int seatsToBook = Convert.ToInt32(Console.ReadLine());

                if (seatsToBook < 1 || seatsToBook > 3)
                {
                    Console.WriteLine("You can only book between 1 to 3 tickets per user.");
                }
                else
                {
                    BookTicket(connectionString, userId, selectedPriceId, seatsToBook);
                    ShowBookingDetails(connectionString, userId);
                }
            }
        }
    }

    static void HandleCancellation(string connectionString, int userId)
    {
        Console.WriteLine("Enter Booking ID to cancel:");
        int bookingID = Convert.ToInt32(Console.ReadLine());
        CancelBooking(connectionString, userId, bookingID);
    }

    static bool GetTrainOptions(string connectionString, string source, string destination)
    {
        bool trainsFound = false;

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("FindTrains", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SourceStationName", source);
            cmd.Parameters.AddWithValue("@DestinationStationName", destination);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                Console.WriteLine("Available trains:");
                bool hasResults = false;
                while (reader.Read())
                {
                    hasResults = true;
                    trainsFound = true;
                    int trainNo = reader.GetInt32(0);
                    string trainName = reader.GetString(1);
                    string trainType = reader.GetString(2);
                    int priceId = reader.GetInt32(3);
                    string classOfTravel = reader.GetString(4);
                    int distance = reader.GetInt32(5);
                    decimal price = reader.GetDecimal(6);
                    int availability = reader.GetInt32(7);

                    Console.WriteLine($"Train No: {trainNo}, Train Name: {trainName}, Type: {trainType}, Price ID: {priceId}, Class: {classOfTravel}, Distance: {distance}, Price: {price}, Availability: {availability}");
                }

                while (reader.NextResult())
                {
                    Console.WriteLine("Additional trains:");
                    while (reader.Read())
                    {
                        hasResults = true;
                        trainsFound = true;
                        int trainNo = reader.GetInt32(0);
                        string trainName = reader.GetString(1);
                        string trainType = reader.GetString(2);
                        int priceId = reader.GetInt32(3);
                        string classOfTravel = reader.GetString(4);
                        int distance = reader.GetInt32(5);
                        decimal price = reader.GetDecimal(6);
                        int availability = reader.GetInt32(7);

                        Console.WriteLine($"Train No: {trainNo}, Train Name: {trainName}, Type: {trainType}, Price ID: {priceId}, Class: {classOfTravel}, Distance: {distance}, Price: {price}, Availability: {availability}");
                    }
                }
            }
        }

        return trainsFound;
    }

    static void BookTicket(string connectionString, int userId, int priceId, int seatsToBook)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("BookTicket", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", userId);
            cmd.Parameters.AddWithValue("@PriceID", priceId);
            cmd.Parameters.AddWithValue("@SeatsToBook", seatsToBook);

            // Execute the BookTicket procedure
            cmd.ExecuteNonQuery();
            Console.WriteLine("Enter 'exit' to return to menu or press enter to view details");
            string input = Console.ReadLine();
            if (input.ToLower() == "exit")
            {
                return;
            }
        }
    }

    static void ShowBookingDetails(string connectionString, int userId)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT [BookingID], [PriceID], [SeatsBooked], [BookingTimestamp], [TrainNo], [TrainName], [SourceStation], [DestinationStation], [Distance] FROM Booking_new WHERE UserID = @UserID", conn);
            cmd.Parameters.AddWithValue("@UserID", userId);

           

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                Console.WriteLine("Booking Details:");
                Console.WriteLine(new string ('-',50));

                while (reader.Read())
                {
                    int bookingId = reader.GetInt32(reader.GetOrdinal("BookingID"));
                    int priceId = reader.GetInt32(reader.GetOrdinal("PriceID"));
                    int seatsBooked = reader.GetInt32(reader.GetOrdinal("SeatsBooked"));
                    DateTime bookingTimestamp = reader.GetDateTime(reader.GetOrdinal("BookingTimestamp"));
                    int trainNo = reader.GetInt32(reader.GetOrdinal("TrainNo"));
                    string trainName = reader.GetString(reader.GetOrdinal("TrainName"));
                    string sourceStation = reader.GetString(reader.GetOrdinal("SourceStation"));
                    string destinationStation = reader.GetString(reader.GetOrdinal("DestinationStation"));
                    int distance = reader.GetInt32(reader.GetOrdinal("Distance"));

                    //Console.WriteLine($"Booking ID: {bookingId}, Price ID: {priceId}, Seats Booked: {seatsBooked}, Timestamp: {bookingTimestamp}, Train No: {trainNo}, Train Name: {trainName}, Source: {sourceStation}, Destination: {destinationStation}, Distance: {distance}");

                    Console.WriteLine("--------------------------------------New Booking Details-------------------------------------------------");

                    Console.WriteLine($"Booking ID: {bookingId}");
                    Console.WriteLine($"Price ID: {priceId}");
                    Console.WriteLine($"Seats Booked: {seatsBooked}");
                    Console.WriteLine($"Timestamp: {bookingTimestamp}");
                    Console.WriteLine($"Train No: {trainNo}");
                    Console.WriteLine($" Train Name: {trainName}");
                    Console.WriteLine($"Source: {sourceStation}");
                    Console.WriteLine($"Destination: {destinationStation}");
                    Console.WriteLine($"Distance: { distance}");
                  
                




                }
                if (!reader.HasRows)
                {
                    Console.WriteLine("No bookings found.");
                }
            }

            Console.WriteLine("Enter 'exit' to return to menu or press enter to view details");
            string input = Console.ReadLine();
            if (input.ToLower() == "exit")
            {
                return;
            }


        }
    }
    static void CancelBooking(string connectionString, int userId, int bookingID)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("CancelBooking", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BookingID", bookingID);
            cmd.Parameters.AddWithValue("@UserID", userId);

            // Execute the CancelBooking procedure
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("Booking cancelled and availability updated.");
            }
            else
            {
                Console.WriteLine("Cancellation failed or booking not found.");
            }
        }
    }
}