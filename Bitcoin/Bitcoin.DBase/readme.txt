Author: Simon Childs
Copyright: Simon Childs

http://www.simonchildsdevelopment.com (Currently Under Construction!)

CrudLinq Read Me

Thank you for downloading CrunLinq - A CRUD repository for Linq to SQL
----------------------------------------------------------------------

How to use...

Once you have created your .dbml file and added data classes to it, you will be able to use the CrudLinq repository. 
All you need to do is create a repository (or bll) class and inherit from CrudLinqRepository<TModel, TDataContext>, for example: 

public class TestBll : CrudLinqRepository<SomeDataClass, SomeDataContext>

WHERE -- 'SomeDataClass' is the data class for the database table you wish to perform CRUD operations on.
	  -- 'SomeDataContext' is the DataContext class used to access your data classes.
	  
	  
You will now be able to access CRUD methods like so...

List<SomeDataClass> dataList = TestBll.Repository.GetList();
_______________________________________________________________

Thats it really! There is no configuration involved other than the above. 

Please contact me through the nuget website (http://nuget.org) or twitter (http://twitter.com/csharpsi) if you have any issues with this package

Thanks very much! :)