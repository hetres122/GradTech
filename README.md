# GradTech API Documentation

## Table of Contents
- [AdditionalOptionController](#additionaloptioncontroller)
- [AuthController](#authcontroller)
- [ReservationController](#reservationcontroller)
- [UnitController](#unitcontroller)

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

## Models

### AdditionalOption

- **AddAdditionalOptionDto**  
  Model for adding a new additional option.

- **EditAdditionalOptionDto**  
  Model for editing an existing additional option.

### Reservation

- **AddReservationRequestDto**  
  Model for adding a new reservation.

- **EditReservationRequestDto**  
  Model for editing an existing reservation.

### Unit

- **AddUnitRequestDto**  
  Model for adding a new unit.

- **EditUnitRequestDto**  
  Model for editing an existing unit.

---

This documentation provides a comprehensive overview of all API endpoints, request parameters, response formats, and role-based access requirements.
