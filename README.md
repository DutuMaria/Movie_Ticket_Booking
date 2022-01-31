# Movie ticket booking system 

### __Database__:


##### __Entity-Relationship Diagram__
![](/MovieTicketBooking_Frontend/src/assets/diagrama.png)

##### __Entities__
- User (inherited from Microsoft Asp Net Core Identity)
- Role (inherited from Microsoft Asp Net Core Identity)
- UserRole (inherited from Microsoft Asp Net Core Identity)
- Movie
- Screening
- Booking
- Payment
- Hall
- Seat
- Ticket
    

##### __Relationships__
- One to one
    - Booking and Payment
- One to many
    - Movie and Screening
    - Screening and Booking
    - Hall and Screening
    - Hall and Seat
- Many to many
    - Booking and Seat => Ticket

### __Functionalities__:

- For users
    - [x] Creating an account (Register Form)
    - [x] Login (Login Form)
    - [x] See information about a movie 
    - If user is logged in:
        - [x] Booking movies
        - [x] Deleting your bookings
        - [x] Viewing ypur bookings
- For admins
    - [x] Adding/Updating/Deleting a movie
    - [x] Viewing all users
    - [x] Updating a booking



