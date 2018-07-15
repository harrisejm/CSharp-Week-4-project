# Hair Salon

#### Epicodus Word Counter (for Epicodus), 7/13/18
#### By Eddie Harris


## Description

This web app allows the user to add new stylists to a list of current employees at their salon. The user can also add individual clients to a list for each stylist.

## Specifications

- 1.) Allow user to input a new stylist's information and add it to a list.

   - Example input:  "Eddie Harris";
   - Example output:  Stylist(s)
                        - Eddie Harris


- 2.) Allows user to view a list of entered stylists.

- 3.) Allow user to select an existing stylist and enter/or add to a list of clients.

   - Example input: "John Smith"
   - Example output: Stylist(s)
                       - Eddie Harris
                           - Client(s)
                                - John Smith  

- 4.) Allows user to view a list of entered stylists with a list of clients.



## Setup/Installation Requirements

* Clone this repository
* Save to Desktop
* See below for instructions for setting up the database

To create the database in MySql, enter the following commands:

 - CREATE DATABASE eddie_harris;
 - USE eddie_harris;
 - CREATE TABLE clients (id PRIMARY KEY, name VARCHAR(255), stylist_id INT, stylist_Name VARCHAR(255));
 - CREATE TABLE stylists (id PRIMARY KEY, name VARCHAR(255));

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
