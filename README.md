# Event Scheduler Console Application

## Overview

This .NET Core Console Application is designed to maximize the total value of attended events in a city based on event schedules, locations, and priorities. The program takes into account spatial and time constraints to select the most valuable events a user can attend.

## Features

- Schedule events based on their start and end times, locations, and priorities.
- Consider travel times between locations to determine feasible event transitions.
- Use dynamic programming to maximize the total value of attended events.

## Requirements

- .NET Core SDK

## Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/yourusername/event-scheduler.git
    ```
2. Navigate to the project directory:
    ```sh
    cd event-scheduler
    ```
3.	Restore dependencies and build the project:
    ```sh
    dotnet restore
    dotnet build
    ```

## Usage
1.	Modify the event and location data in the Program.cs file as needed.
2.	Run the application:
    ```sh
    dotnet run
    ```

## Sample Input
   ```csharp
   var events = new List<Event>
   {
       new Event(1, DateTime.Parse("10:00"), DateTime.Parse("12:00"), "A", 50),
       new Event(2, DateTime.Parse("10:00"), DateTime.Parse("11:00"), "B", 30),
       new Event(3, DateTime.Parse("11:30"), DateTime.Parse("12:30"), "A", 40),
       new Event(4, DateTime.Parse("14:30"), DateTime.Parse("16:00"), "C", 70),
       new Event(5, DateTime.Parse("14:25"), DateTime.Parse("15:30"), "B", 60),
       new Event(6, DateTime.Parse("13:00"), DateTime.Parse("14:00"), "D", 80)
   };
   
   var locations = new List<Location>
   {
       new Location("A", "B", 15),
       new Location("A", "C", 20),
       new Location("A", "D", 10),
       new Location("B", "C", 5),
       new Location("B", "D", 25),
       new Location("C", "D", 25)
   };
   ```

## Sample Output
   ```sh
   Katılınabilecek Maksimum Etkinlik Sayısı: 3
   Katılınabilecek Etkinliklerin ID'leri: 1, 6, 4
   Toplam Değer: 200
   ```

## Implementation Details
### Event Class
The Event class holds information about each event, including its ID, start time, end time, location, and priority.

### LocationDistance Class
The LocationDistance class holds information about the travel time between two locations.

### Scheduler Class
The Scheduler class contains the dynamic programming algorithm to maximize the total value of attended events. It uses a 2D array to store the maximum value that can be achieved at each time step and location. The algorithm iterates through each event and location to determine the maximum value that can be achieved by attending the event at that location. It then updates the maximum value at each time step and location based on the event's value and the maximum value that can be achieved at the previous time step and location.

## License
This project is licensed under the MIT License. See the LICENSE file for details.