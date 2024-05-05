namespace ITIWebApi.Models
{

    /*
     
     day2 

     - loading relative data => leZy(most used) - eager - explicit

     - seralization: c# obj(strong) => json (losely (less info))
       deseralization: json (losly) =>c# obj(strong)

    -circular exception "infinit loop"(leZy) --> 3 handlers
    1-expection (defult)
    2- (ignore) 
    3-let it loop maybe it wont be infinit
    4-newtonSoftJson package

    -DTO( Data Transfer Object) solve circular exception

    -[consumes("application/json")]


////// http file
      
@ITIWebApi_HostAddress=https://localhost:7003/api
  

###
GET {{ITIWebApi_HostAddress}}/students


###

GET {{ITIWebApi_HostAddress}}/Account
Authorization: Bearer eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiYWRtaW4iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9tb2JpbGVwaG9uZSI6IjAxMDMyMjY2MzA2IiwiZXhwIjoxNzE0OTc4NTA5fQ.RpNQt1PgOIW2_I3lTqO9IHq-Y0Wy6rNsixYeY9FX-Qc

###

DELETE {{ITIWebApi_HostAddress}}/students/1
###
POST {{ITIWebApi_HostAddress}}/account/login
Content-Type: application/json

{
  "userName": "admin",
  "password": "123"
}
###



     */
}
