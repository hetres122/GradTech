# GradTech API Documentation

## Table of Contents
- [AdditionalOptionController](#additionaloptioncontroller)
- [AuthController](#authcontroller)
- [ReservationController](#reservationcontroller)
- [UnitController](#unitcontroller)
- [Database Triggers, Stored Procedures, and Functions](#database-triggers-stored-procedures-and-functions)

---

## AdditionalOptionController

Controller for managing additional options in the system. Accessible only by users with the `Admin` role.

### Routes

- **[GET] /api/additionaloption**  
  Retrieves a list of all additional options.  
  **Response**: `200 OK`, List of additional options.

- **[GET] /api/additionaloption/{additionalOptionId}**  
  Retrieves a specific additional option by its ID.  
  **Parameters**:  
  - `additionalOptionId` (long): ID of the additional option.  
  **Response**: `200 OK`, Additional option details.

- **[POST] /api/additionaloption**  
  Adds a new additional option.  
  **Body**: `AddAdditionalOptionDto`  
  **Response**: `200 OK`, Newly created additional option.

- **[PUT] /api/additionaloption**  
  Updates an existing additional option.  
  **Body**: `EditAdditionalOptionDto`  
  **Response**: `200 OK`, Updated additional option.

- **[DELETE] /api/additionaloption/{additionalOptionId}**  
  Deletes an additional option by its ID.  
  **Parameters**:  
  - `additionalOptionId` (long): ID of the additional option.  
  **Response**: `200 OK`, Deleted additional option.

- **[POST] /api/additionaloption/{additionalOptionId}/{reservationId}**  
  Adds an additional option to a specific reservation.  
  **Parameters**:  
  - `additionalOptionId` (long): ID of the additional option.  
  - `reservationId` (long): ID of the reservation.  
  **Response**: `200 OK`, Confirmation of addition.

- **[DELETE] /api/additionaloption/{additionalOptionId}/{reservationId}**  
  Removes an additional option from a reservation.  
  **Parameters**:  
  - `additionalOptionId` (long): ID of the additional option.  
  - `reservationId` (long): ID of the reservation.  
  **Response**: `200 OK`, Confirmation of removal.

- **[GET] /reservation/{reservationId}**  
  Retrieves all additional options associated with a specific reservation.  
  **Parameters**:  
  - `reservationId` (long): ID of the reservation.  
  **Response**: `200 OK`, List of additional options for the reservation.

---

## AuthController

Handles user authentication-related operations.

### Routes

- **[POST] /logout**  
  Logs out the user if they are authenticated.  
  **Body**: Empty object `{}`  
  **Response**: `200 OK`, Confirmation of logout; `401 Unauthorized` if user is not authenticated.

- **[GET] /check-auth**  
  Checks if the user is authenticated.  
  **Response**: `200 OK`, `{ isAuthenticated: true }` if authenticated; `401 Unauthorized` if not authenticated.

---

## ReservationController

Controller for managing reservations.

### Routes

- **[GET] /api/reservation**  
  Retrieves all reservations for the authenticated user.  
  **Response**: `200 OK`, List of reservations.

- **[POST] /api/reservation**  
  Adds a new reservation for the authenticated user.  
  **Body**: `AddReservationRequestDto`  
  **Response**: `200 OK`, Newly created reservation.

- **[PUT] /api/reservation**  
  Updates an existing reservation for the authenticated user.  
  **Body**: `EditReservationRequestDto`  
  **Response**: `200 OK`, Updated reservation.

- **[DELETE] /api/reservation/{reservationId}**  
  Deletes a reservation by its ID.  
  **Parameters**:  
  - `reservationId` (long): ID of the reservation.  
  **Response**: `200 OK`, Confirmation of deletion.

---

## UnitController

Controller for managing units, accessible only to users with the `Admin` role.

### Routes

- **[GET] /api/unit**  
  Retrieves a list of all units.  
  **Response**: `200 OK`, List of units.

- **[GET] /api/unit/{unitId}**  
  Retrieves details of a specific unit by its ID.  
  **Parameters**:  
  - `unitId` (long): ID of the unit.  
  **Response**: `200 OK`, Unit details.

- **[POST] /api/unit**  
  Adds a new unit.  
  **Body**: `AddUnitRequestDto`  
  **Response**: `200 OK`, Newly created unit.

- **[PUT] /api/unit**  
  Updates an existing unit.  
  **Body**: `EditUnitRequestDto`  
  **Response**: `200 OK`, Updated unit.

- **[DELETE] /api/unit**  
  Deletes a unit by its ID.  
  **Parameters**:  
  - `unitId` (long): ID of the unit.  
  **Response**: `200 OK`, Confirmation of deletion.

- **[GET] /api/unit/available**  
  Retrieves available units for a specified date range.  
  **Parameters**:  
  - `startDate` (DateTime): Start of the availability range.  
  - `endDate` (DateTime): End of the availability range.  
  **Response**: `200 OK`, List of available units for the specified period.

---

## Database Triggers, Stored Procedures, and Functions

### Triggers

#### SyncUsersOnInsertUpdate

Synchronizes user data between the `AuthServiceDb` database and the `GradTech` application database whenever a user record is inserted or updated in `AuthServiceDb`.

- **Trigger Creation**:
    ```sql
    CREATE TRIGGER SyncUsersOnInsertUpdate
    ON AuthServiceDb.dbo.AspNetUsers
    AFTER INSERT, UPDATE
    AS
    BEGIN
        -- Call the stored procedure to synchronize data
        EXEC SyncAspNetUsersToApplicationUsers;
    END;
    ```

---

### Stored Procedures

#### SyncAspNetUsersToApplicationUsers

Synchronizes user data from `AuthServiceDb.dbo.AspNetUsers` with `GradTech.dbo.ApplicationUser`. Updates matching records, inserts new records, or deletes records in `ApplicationUser` when they no longer exist in `AspNetUsers`.

- **Procedure Creation**:
    ```sql
    CREATE PROCEDURE SyncAspNetUsersToApplicationUsers
    AS
    BEGIN
        MERGE INTO GradTech.dbo.ApplicationUser AS Target
        USING AuthServiceDb.dbo.AspNetUsers AS Source
        ON Target.Id = Source.Id
        WHEN MATCHED THEN
            UPDATE SET
                Target.Id = Source.Id,
                Target.UserName = Source.UserName,
                Target.NormalizedUserName = Source.NormalizedUserName,
                Target.Email = Source.Email,
                Target.EmailConfirmed = Source.EmailConfirmed,
                Target.PasswordHash = Source.PasswordHash,
                Target.SecurityStamp = Source.SecurityStamp,
                Target.ConcurrencyStamp = Source.ConcurrencyStamp,
                Target.PhoneNumber = Source.PhoneNumber,
                Target.PhoneNumberConfirmed = Source.PhoneNumberConfirmed,
                Target.TwoFactorEnabled = Source.TwoFactorEnabled,
                Target.LockoutEnd = Source.LockoutEnd,
                Target.LockoutEnabled = Source.LockoutEnabled,
                Target.AccessFailedCount = Source.AccessFailedCount
        WHEN NOT MATCHED BY Target THEN
            INSERT (Id, UserName, NormalizedUserName, Email, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount)
            VALUES (Source.Id, Source.UserName, Source.NormalizedUserName, Source.Email, Source.EmailConfirmed, Source.PasswordHash, Source.SecurityStamp, Source.ConcurrencyStamp, Source.PhoneNumber, Source.PhoneNumberConfirmed, Source.TwoFactorEnabled, Source.LockoutEnd, Source.LockoutEnabled, Source.AccessFailedCount)
        WHEN NOT MATCHED BY Source THEN
            DELETE;
    END;
    ```

---

### Functions

#### CalculateTotalAmount

Calculates the total amount for a unit based on its daily rate and a specified date range.

- **Function Creation**:
    ```sql
    CREATE FUNCTION dbo.CalculateTotalAmount
    (
        @UnitId INT,
        @StartDate DATE,
        @EndDate DATE
    )
    RETURNS DECIMAL
    AS
    BEGIN
        DECLARE @TotalAmount DECIMAL;
        DECLARE @Days INT = DATEDIFF(DAY, @StartDate, @EndDate);
        DECLARE @DailyRate DECIMAL;
        
        SELECT @DailyRate = DailyRate FROM Unit WHERE UnitId = @UnitId;
        SET @TotalAmount = @DailyRate * @Days;
        
        RETURN @TotalAmount;
    END;
    ```

---

### SQL Query

Retrieves available units by filtering out units already reserved in a specified date range.

- **Query**:
    ```sql
    SELECT u.UnitId, u.Make, u.Model, u.Year, u.DailyRate, u.IsAvailable 
    FROM Unit u 
    WHERE u.IsAvailable = 1 
    AND u.UnitId NOT IN (
        SELECT r.UnitId 
        FROM Reservations r 
        WHERE r.StartDate < {1} AND r.EndDate > {0}
    );
    ```
