
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
![App Screenshot](https://raw.githubusercontent.com/Rquaicoo/Shoprite-Inventory/main/Shoprite%20Ghana%20Limited/shoprite-screenshots/Screenshot%202022-09-05%20121307.png?token=GHSAT0AAAAAABXQYSNZTNWUFM4LC3X72JTMYYV7BSQ)

* Sales
![App Screenshot](https://raw.githubusercontent.com/Rquaicoo/Shoprite-Inventory/main/Shoprite%20Ghana%20Limited/shoprite-screenshots/Screenshot%202022-09-05%20121357.png?token=GHSAT0AAAAAABXQYSNZATAKT5WGJFX54PVEYYV7CMA)

* User management
![App Screenshot](https://raw.githubusercontent.com/Rquaicoo/Shoprite-Inventory/main/Shoprite%20Ghana%20Limited/shoprite-screenshots/Screenshot%202022-09-05%20121431.png?token=GHSAT0AAAAAABXQYSNZIDBYFQQBMKITGA72YYV7DGA)

* Product management
![App Screenshot](https://raw.githubusercontent.com/Rquaicoo/Shoprite-Inventory/main/Shoprite%20Ghana%20Limited/shoprite-screenshots/Screenshot%202022-09-05%20121529.png?token=GHSAT0AAAAAABXQYSNYYRTQHJUCFGH5GEBSYYV7D5Q)

* Sales report
![App Screenshot](https://raw.githubusercontent.com/Rquaicoo/Shoprite-Inventory/main/Shoprite%20Ghana%20Limited/shoprite-screenshots/Screenshot%202022-09-05%20121613.png?token=GHSAT0AAAAAABXQYSNYFZY3AAPOY4MDJRDGYYV7EOQ)


### Attendant dashboard
* Till
![App Screenshot](https://raw.githubusercontent.com/Rquaicoo/Shoprite-Inventory/main/Shoprite%20Ghana%20Limited/shoprite-screenshots/Screenshot%202022-09-05%20121736.png?token=GHSAT0AAAAAABXQYSNZEWHHNKELGT3CKQSCYYV7JJA)

* Sale
![App Screenshot](https://raw.githubusercontent.com/Rquaicoo/Shoprite-Inventory/main/Shoprite%20Ghana%20Limited/shoprite-screenshots/Screenshot%202022-09-05%20121835.png?token=GHSAT0AAAAAABXQYSNYSHEZZE7AXYBSDHIYYYV7IAQ)

* Daily report
![App Screenshot](https://raw.githubusercontent.com/Rquaicoo/Shoprite-Inventory/main/Shoprite%20Ghana%20Limited/shoprite-screenshots/Screenshot%202022-09-05%20121952.png?token=GHSAT0AAAAAABXQYSNZX53YJUO3JIPINMEOYYV7I2Q)
