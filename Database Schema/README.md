# Design Document

## Functional Requirements

This Database will support:

* CRUD operations for clients, doctors, species, breeds, diagnosis, patients, cases, pharmacy inventory, prescriptions, prescribed medications, and receipts
* Tracking all clients,patients,doctors and cases activities withing the clinic
* Adding multiple patients, cases and prescriptions to a client
* Adding multiple drugs to the inventory

## Representation

Entities are captured in SQL Server tables with the following schema.

### Entities

The database includes the following entities:

#### Clients

The `Clients` table includes:


* `Id`,which specifies the unique internal ID for the client as an `INT`. This column has the `PRIMARY KEY` constraint applied.
* `FirstName`, which specifies the client's first name as `VARCHAR(50)`.
* `LastName`, which specifies the client's last name as `VARCHAR(50)`.
* `Address`,which specifies the client's address as `VARCHAR(100)`.
* `PhoneNumber`,which specifies the client'S phone number as `VARCHAR(15)`.

#### Doctors

The `Doctors` table includes:

* `Id`,which specifies the unique internal ID for the doctor as an `INT`. This column has the `PRIMARY KEY` constraint applied.
* `FirstName`, which specifies the doctor's first name as `VARCHAR(50)`.
* `LastName`, which specifies the doctor's last name as `VARCHAR(50)`.
* `Email`, which specifies the doctor's email as `VARCHAR(40)`.
* `PhoneNumber`, which specifies the doctor's phone number as `VARCHAR(15)`.
* `YearGraduated`, which specifies the doctor's year of graduation `INT`.

#### Species

The `Species` table includes:

* `Id`, which specifies the unique internal ID for a species as an `INT`. This column has the `PRIMARY KEY` constraint applied.
* `Name`, which specifies the name of the species as `VARCHAR(50)`. This column has the UNIQUE constraint applied to avoid repition.

### Diagnosis

The `Diagnosis` table includes:

* `ID`, which specifies the unique internal ID for a diagnosis as an `INT`. This column has the `PRIMARY KEY` constraint applied.
* `Name`, which specifies the name of the diagnosis as `VARCHAR(50)`. This column has the UNIQUE constraint applied to avoid repition.

### Patients

The `Patients` table includes:

* `ID`, which specifies the unique internal ID for a patients as an `INT`. This column has the `PRIMARY KEY` constraint applied.
* `ClientId`, which is the ID of the client who presented the patient as a `INT`.This column has the `FOREIGN KEY` constraint applied, referencing the `Id` column in the `Clients` table to ensure data integrity.
*  `SpeciesId`, which is the species of the patient presented as an `INT`.This column has the `FOREIGN KEY` constraint applied, referencing the `Id` column in the `Species` table to ensure data integrity.
* `Sex`,which specifies the sex of the patient as male or female represented as `TINYINT`.
* `Age`,which specifies the age of the patient `VARCHAR(50)`.

### Cases

The `Cases` table includes:

* `Id`, which specifies the unique ID for cases managed in the clinic as an `INT`.This column thus has the `PRIMARY KEY` constraint applied.
* `PatientId`, which is the ID  of the patient as a `INT`.This column thus has the `FOREIGN KEY` constraint applied, referencing the `Id` column in the `Patients` table to ensure data integrity.
* `DoctorId`, which specifies the Id of the doctor that managed the case as `INT`.This column has the `FOREIGN KEY` constraint applied, referencing the `Id` column in the `Doctors` table to ensure data integrity.
* `DiagnosisId`, which specifies the diagnosis as an `INT`.This column thus has the `FOREIGN KEY` constraint applied, referencing the `Id` column in the `Diagnosis` table to ensure data integrity.
* `CaseType`, which specifies how the case was managed as either medical or surgical represented as `TINYINT`.
* `Status`, which specifies if the case is a new case or and updated case presented as `TINYINT`.
* `Date`, which specifies the date the case was managed as `DATE`.
* `Notes`, which specifies additional notes by the doctor as `VARCHAR(1000)`.

# Inventory

The `Inventory` table includes:

* `ItemId`, which specifies the unique ID for items in the inventory as an `INT`.This column thus has the `PRIMARY KEY` constraint applied.
* `TradeName`, which specifies the trade name of the item as `VARCHAR(50)`.
* `GenericName`, which specifies the generic name of the item as `VARCHAR(50)`.
* `Category`, which specifies the category of the item as `VARCHAR(50)`.
* `Unit`, which specifies the unit of the item as `VARCHAR(30)`.
* `CostPricePerItem`, which specifies the cost per the above unit of the item as `DECIMAL(8,2)`.
* `SalePricePerItem`, which specifies the sale per the above unit of the item as `DECIMAL(8,2)`.
* `ExpirationDate`, which specifies the expiry date of the item as `DATE`.

# Prescriptions

The `Prescriptions` table includes:

* `Id`, which specifies the unique ID for a prescription in the clinic as an `INT`.This column has the `PRIMARY KEY` constraint applied.
* `CaseId`, which is the ID  of the Case linked to the prescription as `INT`.This column thus has the `FOREIGN KEY` constraint applied, referencing the `Id` column in the `Cases` table to ensure data integrity.
* `Date`, which specifies the date the prescription was made as `DATE`.

# PrescribedMeds

The `PrescribedMeds` table includes:

* `MedicationId`, which specifies the item being prescribed as `INT`. This column thus has the `FOREIGN KEY` constraint applied, referencing the `ItemId` column in the `Inventory` table to ensure data integrity.
* `PrescriptionId`, which specifies the prescription_id being referenced as `INT`. This column thus has the `FOREIGN KEY` constraint applied, referencing the `Id` column in the `Prescriptions` table to ensure data integrity.
* The two columns are the primary key of the table.
* `Quantity`, which specifies the quantity of item being prescribed as `INT`.
* `Frequency`, which specifies how often the item be used or administered as `VARCHAR(50)`.

# Reciepts

The `Receipts` table includes:

* `Dd`, which specifies the unique ID for a reciepts issued in the clinic as an `INT`.This column thus has the `PRIMARY KEY` constraint applied.
* `PrescriptionId`, which specifies the prescription_id being referenced as `INT`. This column thus has the `FOREIGN KEY` constraint applied, referencing the `Id` column in the `Prescriptions` table to ensure data integrity.
* The two column
* `Date`, which specifies the date which the receipt was issued as `DATE`.
* `TotalPrice`, which specifies the total amount in the reciept as `DECIMAL(8,2)`.