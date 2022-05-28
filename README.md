# Advanced Programming exercise 2:
Submitting:

Tomer Eligayev, id: 208668129

Ofek Koren, id: 207105933

## **About the project**	
- The project was developed with React framework (for the client side) and MVC architecture (for the server side and ranks part).
The npm libraries which were installed in this project ware React-Router-v6 and signalIR (`npm i --save @microsoft/signalr.`)
- You can download the project using the commang `git clone https://github.com/TOMER-77/AP2-EX2.git`
- To examine the server side you should enter the [ChatApplciation](https://github.com/TOMER-77/ap2-ex2/tree/main/ChatApplciation "ChatApplciation")  directory, and read the README instructions file inside the directory.
- The project consists of 3 sun-projects and runs on 3 different ports:
- - 3000 for the client side.
-  - 5170 for the server side.
-  - 5189 for the rankings.
- **Each project must run on the port stated above**
- To run all the 3 sub-projects in parallel:
-  - Go to the *clientSide* folder and in the cmd run the `npm start` command.
-   - Go to the *ChatApplciation* folder, open in visual studio the solution on the project. In the solution explorer of visual studio right click on the solution,click on properties,choose the option "Multiple startup projects" and choose both "ChatWebApi" (for server side) and "ChatWebApp" (for Ranks).
- When running the 3 sun-projects together you can check the whole project. The server supports conversations between users and you can navigate from the login and sign up screens to the ranks page and in the other way around.
- To examine each project alone to to [clientSide](https://github.com/TOMER-77/ap2-ex2/tree/main/clientSide "clientSide") directory or the [ChatApplciation](https://github.com/TOMER-77/ap2-ex2/tree/main/ChatApplciation "ChatApplciation")  directory and read the instructions in the README text.
- In the day of submittion we encountered a problem with our git repository so we had to switch to a new one. For this reason there is no commit history in this repository. If it is needed, contact with one of us and we will provide you with a link to the old repository with the full commits history.

**It is important for us to mention that we assumed that username is a global identifier for a user or contact (as we were asked in the first exercise). Therefore, while trying to add a new contact, if the user already has a contact with the same username (but might be from a different server), the action will be failed.**
