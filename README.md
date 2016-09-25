# Weather Test

4Com code test for prospective .NET developers.

### Prerequisites

Follow the instructions at https://www.microsoft.com/net/core to install .NET Core

### Brief

Using the APIs in this repository, create an application or website which given a location, will query and then display an aggregated weather result.

We find this challenge normally takes a few hours to complete, however you may spend as much time as you would like to produce a result you are happy with and believe meets all the requirements.
Your code should be written in a way that shows you have a good understanding of common software design patterns and SOLID principles.
Should there be any aspects, which given more time you would have refactored, please add a README, or comments, explaining what you would like to have done.

You should submit a link to your repository (GitHub, GitLab, BitBucket, etc), rather than a compiled application / link to the deployed website.

If you believe the brief is unclear in anyway or you have any questions please ask. 

### Requirements

Your application/website should:
* Display the aggregated (average) result, both temperature and wind speed, from any APIs it has queried
**Julius** *A simple enumeration has been used to list APIs. The assumption taken is all APIs will be queried and this is transparent to the end user*
* Allow the user to choose which measurement unit they want results displayed in. Wind should be MPH or KPH and temperature should be Celsius or Fahrenheit
* Allow for more APIs to be easily added in the future
* Allow for other units of measure to be easily added in the future
* Gracefully handle one or more of the APIs being down or slow to respond
**Julius** *All calls to APIs are asynchronous meaning the page will not be blocked (have latency issues). This however can be improved by also introducing a timeout in future to cater for scenarios where it takes longer periods of time for APIs to respond*
**Julius** *The test website does not have client side or server side user input validation. In the event the user doesn't specify a location, the APIs have been gracefully handled and the user will get no results. Instead it will be 0 Celsius and 0 Kph. This can be improved to show user friendly message.


It should pass the following tests:
*	Given temperatures of 10c from bbc and 68f from accuweather when searching then display either 15c or 59f depending on what the user has chosen
*	Given wind speeds of 8kph from bbc and 10mph from accuweather when searching then display either 12kph or 7.5mph depending on what the user has chosen
**Julius** *No integration tests have been added for the sample website due to time constraints*
**Julius** *Every time the end user does a query, there will be a server trip. This can be improved in future to do some unit conversions on client side, say if the location was not changed and the user merely wants to view measurements in differnt units.
