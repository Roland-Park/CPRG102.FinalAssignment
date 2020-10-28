more details in the included word file
_______________________________________
Scenario
-asset tracking application
-HR db exists already (given), cannot be changed. Admin, IT, Engineering, Sales depts

Projects:
a.	Domain (class library  – no dependencies) 
  - Asset, Asset Type, Manufacturer and Model 
b.	Data (class library – dependent on Domain) 
  - AssetContext : DbContext, contains EF, CODE FIRST
c.	BLL (class library – dependent on Data and Domain) 
  - manager classes
d.	HRService (WebAPI – no dependencies) 
  - accesses HR db (readonly), employee number as ID
e.	AssetTracking (MVC Web Application – dependent on Domain and BLL)
  - Views: main assets, new asset, asset assignment

