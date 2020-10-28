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

