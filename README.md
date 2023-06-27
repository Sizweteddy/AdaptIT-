The project consists of two applications: CapturingDetails and DisplayingDetails, which work together to capture and display client details and metrics.

CapturingDetails Application:
The CapturingDetails application allows users to capture details of clients and store them for later retrieval. It provides the following functionalities:

AddClient Method: This method in the DataRepository class adds a new client to the list of clients if a client with the same name doesn't already exist. It performs a check to ensure that duplicate clients are not added.

SaveData Method: This method in the DataRepository class serializes the list of clients to JSON format and saves it to a file. It ensures that the captured client data is persistently stored.

When the CapturingDetails application is executed, it prompts the user to enter client details such as the client name, date registered, location, and number of users. It creates a DataRepository object to handle data storage and retrieval. The captured client details are then added to the repository using the AddClient method. Finally, the updated data is saved using the SaveData method.

DisplayingDetails Application:
The DisplayingDetails application retrieves and displays various metrics based on the captured client details. It utilizes the DataRepository class to access the stored data and provides the following functionalities:

GetUsersPerLocation Method: This method in the DataRepository class calculates and returns a dictionary that shows the total number of users per location. It iterates through the list of clients and aggregates the user counts based on the location.

GetTotalUsers Method: This method in the DataRepository class calculates and returns the total number of users across all clients. It iterates through the list of clients and sums up the user counts.

GetClientsPerDate Method: This method in the DataRepository class calculates and returns a dictionary that displays the number of clients registered per date. It extracts the date from the DateRegistered property of each client and aggregates the client counts based on the date.

When the DisplayingDetails application is executed, it creates a DataRepository object to access the stored client data. It retrieves the users per location using the GetUsersPerLocation method and displays the result. It also retrieves the total number of users using the GetTotalUsers method and displays the result. Finally, it retrieves the clients per date using the GetClientsPerDate method and displays the result.

Overall, the CapturingDetails application allows users to capture and store client details, while the DisplayingDetails application retrieves and displays various metrics based on the captured data. The DataRepository class acts as an intermediary for data storage and retrieval.

