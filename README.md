
# Gym Management System Using Windows Form and MSSQL DATABASE
![image](https://github.com/user-attachments/assets/dd304166-263d-48d6-a424-9b66b21d38b1)

- This project is a basic user role based platform for both admin and member which includes CRUD operations (Create, Read, Update, Delete) application developed using C# with Windows Forms as the user interface. It allows users to manage records in a database by performing the four basic operations on data: adding new records, retrieving/displaying records, updating existing records, and deleting records.Besides the admin can manage the data and view certain information provided by the user interfaces.  

## Demo

https://www.youtube.com/watch?v=qSwMRk2LA6c


## Features

**Create:** Add new records to the database through an input form.

**Read:** Display existing records in a table or list.

**Update:** Modify details of existing records.

**Delete:** Remove records from the system.

**Filter:** Filtering data based on certain filtering options 

**Count:** Counting the number of user in the system based on roles 

**Generating data:** Generating certain data like payment slip, exporting in the excel sheet. 

**Tracking Records:** Tracking the users information.  

**Schema Diagram:**

![image](https://github.com/user-attachments/assets/962dea1f-c07a-4fbc-af26-391920826430)

## Prerequisites
Visual Studio 2022 or later 

SQL Server (Express or any version) 

SQL Server Management Studio (SSMS)

## Tools and Technologies
**Programming Language:** C#

**User Interface:** Windows Forms (WinForms)

**Database:** Microsoft SQL Server

**IDE:** Visual Studio

## Necessary Installations

**Programming Language:** C#
- Download Visual Studio and install (2022 reccomended)

**Database:** SQL Server
- Download SQL Server Mangement Studio and install (latest version)

**Framework:** Windows Forms
- Download and install necesarry packages from NuGet packages.

**UI Components:**
- Download and install guna2.winform package from NuGet packages.
## Database Setup
**1. Database Setup**
- Open the .sql file located in folder.

- Copy the queries from the .sql file and execute them in your new database to set up the schema and initial data.

- Use Ctrl+F to search for connectionString within the project files.

```private readonly string connectionString = "Server=(localdb)\\login;Database=FinanceTracker;Trusted_Connection=True;";```
- Update this to:

```private readonly string connectionString = "Server=<YOUR DATABASE SERVER/SOURCE>;Database=<DATABASENAME>;Trusted_Connection=True;";```

 

**2.Create Table(Sample)
```
GO

/****** Object:  Table [dbo].[admin]    Script Date: 9/25/2024 11:11:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[admin](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userRole] [varchar](250) NOT NULL,
	[admin_name] [varchar](250) NOT NULL,
	[pass] [varchar](250) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[admin_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
```
**Create a C# Windows Forms Application:**

- Open Visual Studio.

**Create a New Project:**

- Select C# > Windows Forms App (.NET Framework).

- Choose a project name and location.

**Design Your Form:**

- Add text boxes for Variables.

- Add buttons for different features.

- Add a DataGridView to display records.

**Add SQL Server Connection:**

To connect your application to the SQL Server database, you need to configure a connection string.

**Install SQL Server NuGet Package (optional if not already available):**

- In Solution Explorer, right-click on the project and select Manage NuGet Packages.

- Search for System.Data.SqlClient and install it.

**Set up the Connection String in your C# code:**

In your code-behind file (e.g., Form1.cs), define the connection string:

- string connectionString = "Data Source=YOUR_SERVER_NAME;Initial Catalog=StudentDB;Integrated Security=True;";

- Replace- (YOUR_SERVER_NAME) with the actual name of your SQL Server (you can find this in SSMS).


**3. C# Code Implementation**

Sample Add New Operation

```try
{
    String EquipName = guna2Textequipname.Text;
    String Description = guna2Textdescription.Text;
    String MUsed = guna2Textmusclesused.Text;
    String DDate = guna2DateTimePickerdelivery.Text;
    Int64 cost = Int64.Parse(guna2Textcost.Text);


    SqlConnection con = new SqlConnection();
    con.ConnectionString = "Data Source=DESKTOP-CBUAB5J;Initial Catalog=GYM;Persist Security Info=True;User ID=sa;Password=nafis99;Encrypt=False";
    SqlCommand cmd = new SqlCommand();
    cmd.Connection = con;

    cmd.CommandText = "insert into Equipment (EquipName,EDescription,MUsed,DDate,Cost) values ('" + EquipName + "','" + Description + "', '" + MUsed + "', '" + DDate + "', '" + cost + "')";
    SqlDataAdapter DA = new SqlDataAdapter();
    DA.SelectCommand = cmd;
    DataSet DS = new DataSet();
    DA.Fill(DS);

    MessageBox.Show("data saved ", "Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);
}
```
**4. Event Handling**

- Implement event handlers for each button (e.g., Create, Edit, Delete).

- When a button is clicked, the corresponding CRUD operation will be executed (e.g., creating a new record or deleting an existing one).
## Project Workflow
***1. User Interface (Windows Forms)***

**Main Form:** Contains buttons for Create, Edit, Read, Update, Delete, and Refresh operations, along with a DataGridView to display records.

**Add/Edit Form:** A separate form to enter or modify record details.

**Message Boxes:** Used for confirming actions such as deletion or record creation.

***2. Database Operations***

**Create:** Add a new record by submitting a form.

**Read:** Fetch and display records from the database in the DataGridView.

**Update:** Edit an existing record by selecting it and submitting the modified data.

**Delete:** Remove a record by selecting it and confirming deletion.
## User Flow
1.When the application is opened, existing records are displayed in the DataGridView.

2.Users can:

- Add new records by clicking the **"Add"** button and submitting the form.

- Edit existing records by selecting a row and clicking the **"Update"** button.

- Delete records by selecting a row and confirming deletion.

- Refresh the displayed data to reflect the latest updates from the database. 

- Can view or generate payments. 

- Can view or generate feedback.

- Can view or generate diet plan.


## Challenges and Consideration
**Data Validation:** Ensure proper input validation for fields.

**Error Handling:** Implement error handling for database connection failures or invalid inputs.

- Proper use of try and cache statements to ensure smooth viewing of error and to make further improvements efficiently.
## Further Enhancement
- Generate Payment slip as notepad file.

- Export Payment records as excel file.
## How to Run the Project
**Clone the Repository:** Clone this repository to your local machine.

``` https://github.com/nafis3303/Gym_Management_system_file-master.git ```

 **Set Up the Database:** Configure your SQL Server or SQLite database and update the connection according to the script.sql file.

**Update String:** Update database connection String and connect with Database.

**Install package:** Make sure to install necesarry package according to readme.

**Build the Project:** Open the project basic_crud_app.csproj in Visual Studio and build the solution.

**Run the Application:** Once built, run the application and manage records through the Windows Forms interface.
## Screenshots

![Picture1](https://github.com/user-attachments/assets/03708ddd-bbea-4f3a-9f6b-36e966e9b9c5)
![Picture2](https://github.com/user-attachments/assets/ac90080b-93ef-4979-aeca-ff9431b4044d)
![Picture3](https://github.com/user-attachments/assets/1560e2b7-4bf6-4878-8451-c2f7fa10ca42)
![Picture4](https://github.com/user-attachments/assets/02e9bb1c-d091-4d89-ac06-a747b4642efe)
![image2](https://github.com/user-attachments/assets/ced924d6-38b8-4712-8f3b-505a3212a634)




