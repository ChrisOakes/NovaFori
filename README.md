

How long did it take to code your solution?

	It took me three hours to code the solution, which included downloading Git (I normally use TFS and TFVC) and comitting it to a public repo.

• How do you build and run your solution?

	You can build/run the application through Visual Studio IDE. I developed the solution in Visual Studio 2019.

• What technical and functional assumptions did you make when implementing your
solution?

	As I do not actively make use of a JavaScript framework like Vue, React or Angular in coding front end solutions, I thought the best way to still make use of 
	JavaScript (to develop the front-end) would be by using jQuery and Ajax. This was in thinking that this test was a lithmus test and my current ability called to leverage 
	my knowledge and experience of Razor pages. I thus decided to develop the application as an ASP .Net Core Web app that hosted a RESTful API which would be consumed with 
	POST calls and would use JavaScript to populate DOM elements which I would then append to the page. 

• Briefly explain your technical design and why do you think is the best approach to this
problem.
	The required object to represent the To Do List item is in the models folder. A list was constructed out of this object that would be passed between the front and back ends in order
	to facilitate data retention. The object contained the Description (string), Created (datetime), Updated (datetime) and Complete (boolean) properties. 

	An interface called IToDoList was created with the service ToDoList implementing the interface's methods. The two main methods within the Interface, AddToDoItem and ToggleToDoItem, 
	added a new item and toggled the appropriate item based off the incoming index variable to Complete (boolean) true/false respectively. Both methods returned the updated ToDoList list object
	to be displayed on the front end again. 

	xUnit was used in a separate project, NovaFori_Test, that makes use of integration testing methodologies to test the appropriate methods. The test project had the main solution as a reference. 
	These methods in the interface were developed and tested before starting the construction of the front end so that TDD would be followed.

	As stated above, the solution is an ASP .Net Core based Web Application that makes use of Ajax calls to contact the appropriate methods, which in turn contacts the ToDoController
	by making use of the HttpClient protocol. The returned object is then Deserialized into the appropriate type which is then returned to the front end as a new Json Result. Based on the successful
	response, a JavaScript method is called to empty and then populate two <div> elements that contain the pending and completed tasks respectively.

	On initial load, the button to add elements is disabled. It will only become enabled when there is text in the task description field which is fired on every key-up event. When the add button 
	is selected an ajax post call contacts the OnPostAddNewListItem method in the code behind to add the new item to the list. The Pending and Compelete DOM elements are thus updated. When the checkbox is checked/unchecked
	the OnPostToggleListItem method is called in the code behind to amend the Complete (boolean) field to the opposite value which places it in the relevant DOM element on successful return. 

	Logging has been implemented throughout the solution to log any errors that are thrown (if any).


• If you were unable to complete any user stories, outline why and how would you have
liked to implement them.
	No user stories were unanswered

