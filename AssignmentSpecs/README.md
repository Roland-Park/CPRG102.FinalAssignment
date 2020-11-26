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
    - DONE Display all assets
    - Filter assets (async) using buttons or links above table:
        - assets that are assigned
        - assets that are not assigned
        - assets assigned to an employee
        - by asset type (laptop, tablet, etc)
- New Asset View
    - DONE Drop-down lists contained in view model as ICollection(SelectListItem)
        - asset type
        - manufacturer
        - Model
        - Employee
    - Redirect to Index
    - Limit dropdown list contents if a selection is made
- Assignments View
    - List box displays employees with no assets
    - A drop-down list for each asset showing asset type
    - Selection posted back to controller