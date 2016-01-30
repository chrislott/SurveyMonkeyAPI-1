# SurveyMonkeyAPI
C# Interface to SurveyMonkey API.  Allows MS stack to easily integrate use of SurveyMonkey.
Built entirely in C# this API can enable a windows application or web application to integrate into SurveyMonkey without a lot of heart ache or researching.
SurveyTest project is included which shows how to execute all API call and how to unwrap the results of the call.   
This API allows for sending of surveys, analysis of surveys and results from surveys.  Please note SurveyMonkey API does not yet allow for creation of surveys so any survey that is going to be sent out must already be created in SurveyMonkey web interface. 
However that being said, when you "create a flow" or "send a flow" (ie send a survey for someone to respond to) it is based off an existing survey or template.  When you send it SurveyMonkey basically creates a copy of it that is now going to receive responses.  So if you want to summarize the answers from 100 people all of those people should be included in the same "flow".

