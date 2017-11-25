# StudentEnrollment:
This application is written in response to problem 2.1 RESTful Web API to address student enrollment

## Technology:
It's a .Net Core WEB API app compatible with VS 2017.

## Design Pattern:
It follows Repository pattern.

## How to Run: 
* Make sure VS 2017 is isntalled.
* Install [MongoDB](https://docs.mongodb.com/v3.2/tutorial/install-mongodb-on-windows/).
* From [MongoHelpers](https://github.com/banerjeea/StudentEnrollment/tree/master/MongoHelpers) folder, run StartMongoServer.bat. This starts up the server.It assumes your installation location is 

  `C:\Program Files\MongoDB\Server\3.4\bin`
* Start StartMongoShell.bat then run below commands to create admin user for the app to access your DB;

  `use admin`
  
  `db.createUser( { user: "admin", pwd: "abc123!", roles: [ { role: "root", db: "admin" } ] } )`
  
* You may need to restart StartMongoServer.bat.  
* When Mongo is running successfully, you can run the app from Visul Studio 2017. Import these [Postman requests](https://github.com/banerjeea/StudentEnrollment/tree/master/PostmanRequests).
* Add at least one Subject, Theatre and Student first before you try to add a Lecture or try to Enroll.

## Improvements Needed:
* Due to time constraints, I couldn't implement a check on student's enrollment hours to stop them from enrolling when it's over 10 hours/week. Here is what I would hav done;

   Add `public int WeeklyEnrolledHours { get; set; }` to [Student.cs](https://github.com/banerjeea/StudentEnrollment/blob/master/StudentEnrollment/StudentEnrollment/Models/Student.cs)

   Update this field each time a student register. The value would be a multiplication of below fields from [Lecture.cs](https://github.com/banerjeea/StudentEnrollment/blob/master/StudentEnrollment/StudentEnrollment/Models/Lecture.cs) object;

  `public int Duration { get; set; }` X `public int NoOfLecWeekly { get; set; }` per lecture. 

  Run a check during [enrollment](https://github.com/banerjeea/StudentEnrollment/blob/master/StudentEnrollment/StudentEnrollment/Repositories/Enrollment/Enrollment.cs#L35)
