more details in the included word file
_______________________________________
###### Scenario
  - asset tracking application
  - HR db exists already (given), cannot be changed. Admin, IT, Engineering, Sales depts

###### Projects:
1. Domain (class library  – no dependencies) 
    - Asset, Asset Type, Manufacturer and Model 
2. Data (class library – dependent on Domain) 
    - AssetContext : DbContext, contains EF, CODE FIRST
3. BLL (class library – dependent on Data and Domain) 
    - manager classes
4. HRService (WebAPI – no dependencies) 
    - accesses HR db (readonly), employee number as ID
5. AssetTracking (MVC Web Application – dependent on Domain and BLL)
    - Views: main assets, new asset, asset assignment

#### TODO
- Main Assets View (index)
1.	DONE Displays all assets (assigned and unassigned) in the system by default
2.	filter the display to display only assets that are assigned 
3.	filter the display to show only assets that are not assigned
4.	filter the assets assigned to a selected employee
5.	filter the assets to show only assets of a selected asset type
6.	use buttons or links to filter
7.	filtered data is all displayed asynchronously
8.	DONE Use the Bootstrap grid system to display the links/buttons and the employee and asset type drop-down lists in one content area and the table in the other. They display in a horizontal row when the window size is large and will stack as the windows size decreases.

- New Asset View
1.	DONE The Asset Type, Manufacturer, Model and Employee are all selected from a drop-down list.
2.	DONE The ViewModel contains the Asset properties and collections of SelectListItems for the drop-down lists.
3.	DONE Selections are posted back to the controller for adding to the system. If successful, redirect back to the main home view.
4.  (Added by me) Limit dropdown list contents if a selection is made

- Assignments View
1.	A list box displays only employees who have not been assigned any assets.
2.	DONE Drop-down lists for assets of that asset type. A selection is made from each of the drop-down lists.
3.	Selections are posted back to the controller so each asset can be updated with the assignment to that employee.
4.	DONE Use the Bootstrap grid system on this form also, so each of the drop-downs is placed in column of the grid. The grid only has one row.
5. (Added by me) Limit dropdown list contents if a selection is made

- _Layout
1.	DONE A fixed navigation menu that is collapsible 
2.	Optional image of your choice
3.	DONE A simple footer with copyright for your company

- HR Service
1.	DONE The HRService project is a Web API project. 
2.  DONE Use the supplied database script to create the database in SQL Server. Use a database-first Entity Framework model. 
3.  DONE The ApiControllers will use the Entity Framework context to retrieve the data required by the rest of the application. 
4.  DONE All ApiController methods return JSON results. The data being returned is all employee based. 
5.  DONE? Use the employee number instead of the id for identifying employees. Define a controller for each entity. 
6.  There is no need to manage that database in the application. Assume the database belongs to the administration department and you are only accessing it through this Web API service.
