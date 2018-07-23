# Hair Salon

#### Epicodus Hair Salon part 2 (for Epicodus), 7/20/18
#### By Eddie Harris


## Description

This web app allows users to add new stylists to a list of current employees at their salon. The user can also add individual clients to a list for each stylist.

Update (7/20/18): Users can now also add specialties to the stylists.

## Specifications

- 1.) Allow users to input a new stylist and add them to a list.

   - Example input:  "Eddie Harris";
   - Example output:  Stylist(s)
                        - Eddie Harris

- 2.) Allow users to view a list of entered stylists.

- 3.) Allow user to input a new specialty to a main list.
    - Example input:  "buzz cut";
    - Example output: Specialties
                       - "buzz cut"

- 4.) Allow users to view a list of all entered specialties.

- 5.) Allow users to select an existing stylist and add a new client to their list of clients.

    - Example input: "John Smith"
    - Example output: Stylist(s)
                       - Eddie Harris
                           - Client(s)
                                - John Smith  

- 6.) Allow users to view a list of clients for each stylist.

- 7.) Allow users to select an existing stylist and add to their list of specialties. Users can only select from specialties that were previously added to the main list of specialties.

    - Example input: "buzz cut"
    - Example output: Stylist(s)
                       - Eddie Harris
                           - Specialties
                                - "buzz cut"

- 8.) Allow users to select a specialty from the main list and see all stylists with the that speciality.
    - Example input: "buzz cut"
    - Example output: Stylist(s)
                      - Eddie Harris
                      - John Smith

- 9.) Allow users to delete a stylist, including their client list and speciality list. Specialties will still exist in the main specialties list. All client information will be deleted.

- 10.) Allow users to delete a client for a stylist's client list.

- 11.) Allow users to remove a specialty from a stylist's specialties list. Specialties will still exist in the main specialties list.

- 12.) Allow users to delete a specialty permanently from the main specialty list. This will also remove the specialty from a stylists specialties list.

- 13.) Allow users to change the stylists name.
     - Example name: "Eddie Harris"
     - Example input: Change to - "Edward H"
     - Example output: New Name - "Edward H"

- 14.) Allow users to change the client name.
     - Example name: "Jimmy"
     - Example input: Change to - "Jimmy John"
     - Example output: New Name - "Jimmy John"

- 15.) Allow users to change the specialty name.
     - Example name: "buzz cut"
     - Example input: Change to - "Men's Short"
     - Example output: New Name - "Men's Short"


## Setup/Installation Requirements

* Clone this repository
* Save to Desktop
* See below for instructions for setting up the database

To create the database in MySql, enter the following commands:

- CREATE DATABASE eddie_harris;
- USE eddie_harris;
- CREATE TABLE clients (id PRIMARY KEY, name VARCHAR(255));
- CREATE TABLE stylists (id PRIMARY KEY, name VARCHAR(255));
- CREATE TABLE specialties (id PRIMARY KEY, specialty VARCHAR(255));
- CREATE TABLE stylists_clients (id PRIMARY KEY, stylist_id INT, client_id INT);
- CREATE TABLE stylists_specialties (id PRIMARY KEY, stylist_id INT, specialty_id INT);

After the database is created, select to the "Operations" tab at the top of the screen (Make sure you are in the top level of the database). In the box labeled "Copy database", enter the file name "eddie_harris_test". Select the option "Structure only" and leave the options as default. Click the go button.


Alternative option (Import pre-made database):

Open phpMyAdmin and select the "Import" tab. Click the "Choose File" button and navigate to the file "eddie_harris.sql" in the CSharp-Week-3-Project folder. Click the open button. Repeat this step and import the file "eddie_harris_test.sql".

 CSharp-Week-3-Project
   --> eddie_harris.sql
   --> eddie_harris_test.sql


## Technologies Used

C#
MySql


### License

This software is licensed under the MIT license

###Legal

Copyright (c) 2018 Eddie Harris
