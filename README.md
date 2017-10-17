rentthatbike
============

## Overview
This is the main application example repository for my book "Learning AngularJS for .NET Developers" which available to order at  [www.packtpub.com/learning-angularjs-for-net-developers/book](http://bit.ly/1sUFzQj).  
There is another repository containing examples covering the concepts of the book at [github.com/popalexandruvasile/angularjs-dotnet-book](https://github.com/popalexandruvasile/angularjs-dotnet-book).  
There are two blog posts introducing this book:  
[Announcing my upcoming book "Learning AngularJS for .NET developers"](http://alexvpop.blogspot.co.uk/2014/06/announcing-learning-angularjs-dotnet.html)  
[Free sample chapter "Testing and Debugging AngularJS Applications" from my recently launched book](http://alexvpop.blogspot.com/2014/07/free-sample-chapter-testing-angularjs.html)  

You need to use Visual Studio 2013 to load the "src\RentThatBike.sln" file and run the project.
The application was built sequentially and has three main sequences: building the client side part with AngularJS, building the web service services part with ServiceStack, and the putting it all together part with AngularJS, ASP.NET MVC and ServiceStack v3.  
## Examples index
The example index page for this repository can be found on the [wiki](https://github.com/popalexandruvasile/rentthatbike/wiki).  

The application for the first AngularJS section from the chapter2-example13 branch is hosted here: [rentthatbike.azurewebsites.net](http://rentthatbike.azurewebsites.net).  
The application for the master branch is hosted here: [rentthatbike-dev.azurewebsites.net](http://rentthatbike-dev.azurewebsites.net). At the moment it is not yet on par with the AngularJS application it only has the code covered in the book in the ServiceStack and ASP.NET MVC sections.  

## ServiceStack v4
You can find a version of the application targeting ServiceStack v4 in the [ServiceStackv4](https://github.com/popalexandruvasile/rentthatbike/tree/ServiceStackV4) branch. I had to do some minor changes and used this blog post as a starter: http://camtucker.blogspot.ca/2014/01/updating-to-servicestack-v40.html?view=classic  

## Application screenshots
### "Home" view  
![Home](/docs/images/home.PNG "Home")

### "Bicycles" views
![Index](/docs/images/bicycles_index.PNG "Index")
![New](/docs/images/bicycles_new.PNG "New")
![Edit](/docs/images/bicycles_edit.PNG "Edit")

### "Customers" views:  
![Index](/docs/images/customers_index.PNG "Index")
![New](/docs/images/customers_new.PNG "New")
![Edit](/docs/images/customers_edit.PNG "Edit")

### "Rentals" views:  
![Index](/docs/images/rentals_index.PNG "Index")
![New](/docs/images/rentals_new.PNG "New")
![Edit](/docs/images/rentals_edit.PNG "Edit")

