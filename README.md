# NewEmployeeBuddy - your first friend in the organisation.
An end-to-end RESTful service using ASP.NET WebAPI, C#, Dependency Injection using AutoFac, Generic Repository Pattern, Unit of Work, AutoMapper, NUnit and Moq.  

# Technologies Used:
1. ASP.NET WEBAPI - https://www.asp.net/web-api
2. REST - http://stackoverflow.com/questions/671118/what-exactly-is-restful-programming
3. Dependency Injection - http://stackoverflow.com/questions/130794/what-is-dependency-injection
4. Generic Repository Pattern - https://msdn.microsoft.com/en-us/library/ff649690.aspx
5. Unit of Work - http://stackoverflow.com/questions/10776121/what-is-the-unit-of-work-pattern-in-ef
6. Attribute Routing - https://www.asp.net/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2
7. Action Filters - https://msdn.microsoft.com/en-in/library/dd410209(v=vs.100).aspx
8. Unit Testing using Nunit and Moq - http://stackoverflow.com/questions/1554018/unit-test-nunit-or-visual-studio
9. AutoMapper - http://automapper.org/

#Querying URIs
<table>
<tr>
<th>Verb</th>
<th>URI</th>
<th>Action</th>
</tr>
<tr>
<td>GET</td>
<td>~/api/employee/GetAll</td>
<td>Gets the list of all Employees</td>
</tr>
<tr>
<td>GET</td>
<td>~/api/employee/GetById/1</td>
<td>Gets the Employee details passing the Employee Id</td>
</tr>
<tr>
<td>POST</td>
<td>~/api/employee/Add</td>
<td>Adds an Employee</td>
</tr>
<tr>
<td>DELETE</td>
<td>~/api/employee/Delete</td>
<td>Deletes an Employee</td>
</tr>
<tr>
<td>DELETE</td>
<td>~/api/employee/DeleteById/1</td>
<td>Deletes an Employee pasing the Employee Id</td>
</tr>
<tr>
<td>PUT</td>
<td>~/api/employee/Update</td>
<td>Updates the Employee details</td>
</tr>
</table>
