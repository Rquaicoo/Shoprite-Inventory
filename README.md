
# Shoprite Inventory

A desktop based inventory app for Shoprite Ghana Limited. 
The application extends different functionalities to users based on their roles.


## Installation

Install Shoprite Inventory with git

```bash
  https://github.com/Rquaicoo/Shoprite-Inventory
  cd Shoprite-Inventory
```
    
## Tools for develoment

**Client:** WPF, C#

**Database:** MySQL

**IDE:** Visual Studio 2022


## Usage
The first screen show after the app is run is the login screen. After login, the user is directed to the application dashboard.
The content shown on the dashboard depends on the role of the user who logged in.


The application extends the follwing features to administrators:
* Viewing sale history
* Managing users (create users, reset passwords, remove users, update user information)
* Manging product categories (create, update, delete, view)
* Managing products (create, update, delete, view)
* Managing stock (create, update, delete, view)
* Setting reorder level for products
* Viewing report of sales history
* All passwords are hashed with MD5
#### The following features are also extended to users who are attendants:
* Opening a till
* Making a sale (Involves scanning a barcode to obtain product information. The inforation can also be entered manaually)
* Viewing the daily report on the dashboard

#### A user has to relogin once the application is closed.

#### Assumptions made in the app include:
* A barcode scanner is already connected to the computer using the app.
* Only one till can be active at a goal.

## Demo

Insert gif or link to demo


## Screenshots

### Administration dashboard

* Login
![App Screenshot](https://user-images.githubusercontent.com/66787443/188567595-35c309cb-2c55-404c-855a-9cb7913497a8.png)

* Sales
![App Screenshot](https://user-images.githubusercontent.com/66787443/188567606-fcf81eee-913a-47da-883b-b964221ff6bf.png)

* User management
![App Screenshot](https://user-images.githubusercontent.com/66787443/188567609-1a46436c-006e-4a2c-88f6-6be68a84cf4b.png)

* Product management
![App Screenshot](https://user-images.githubusercontent.com/66787443/188567612-5e5bd4dc-ca52-4b7f-8f8d-b5dccc5bd8b4.png)

* Sales report
![App Screenshot](https://user-images.githubusercontent.com/66787443/188567614-26041870-d70c-4c3f-b1e6-a6e05a499600.png)


### Attendant dashboard
* Till
![App Screenshot](https://user-images.githubusercontent.com/66787443/188567617-aa6e478a-3294-473b-82ae-ca2600d6d99e.png)

* Sale
![App Screenshot](https://user-images.githubusercontent.com/66787443/188567621-1aec7104-7932-4083-acad-f7627998a703.png)

* Daily report
![App Screenshot](https://user-images.githubusercontent.com/66787443/188567627-4fdbf63a-b8c0-42eb-9828-5bbdd6e290e7.png)
