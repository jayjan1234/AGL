# AGL
This is a test code for a Developer Position in AGL. I use React Redux for the front end. There are 5 projects in the solutions:

JayJanuar => presentation layer

JayJanuar.Core => service and DTO layer

JayJanuar.Repo => Repository and Data Layer

JayJanuar.UnitTest => for unit testing

JayJanuar.Model => to store the model of the objects


I use Unity for Dependency Injection, Xunit and moq for unit testing. 
I put unit of work in there in case if the code needs to be scaled with update and insert functionalities. 
I do not use Idisposable since I believe that it's not necessary to dispose httpclient.
