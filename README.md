### This Web Application was developed using C#, ASP.Net framework, HTML/CSS and SQL Server.

### By: Marko Kushta
---
This is a Web Application that is supposed to function as a way for Guests to access the main uses of our UNYT page, without getting lost. 
It also allows Students/Professors to add Students, and Admins to add Professors.

The Web Application has passed these tests:

- Hacking (Password Bruteforcing) *Passed
- Overloading *Passed
- Functional Testing *Passed to a certain extent

	- All functions defined worked as intented, however there are cases when bugs have occurred
		  most have been fixed however, I still expect random stuff to show up as this was my first experience 
          with a Web Application

- Integration Testing 
---
## Main Features

The Guests are able to Contact UNYT, Learn more about our Programs be they Bachelor's, Master's, or PhD ones, as well as allow Guests to become students at UNYT.

When you LogIn you are propted to type the email you registered with and the password.
If you want to look at the students and professors, you need to login.



- Non-registered users can't access Students or Professors.
- Students can access the Details of other Students/Professors but they cannot add, remove, or edit.

- Professors can access Details, and can Edit/Delete/Create a new Student, but they cannot add, remove or edit other Professors details.

	You can access a Professor account with Professor priviledges by using these credentials:

		professorAcc@unyt.edu.al
		Professor1/

- Admins can access everything, aswell as Add/Delete/Edit all details.

	You can access an Admin account with Admin priviledges by using these credentials:

		admin@unyt.edu.al
		Admin1/

- As a User with an account you are also able to change your password, and manage your external logins.
- When you register a new Account the StudentID needs to be an Integer
- The password:

	1. Passwords must have at least one non letter or digit character
	2. Passwords must have at least one uppercase ('A'-'Z')
