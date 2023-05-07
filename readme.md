# Access User information from Github

# Description


* Create a net core Webapi project that has an API endpoint called retrieveUsers.
* This endpoint takes a List<string> usernames: This is a list of github usernames that will be used
to look up basic information from GitHub's public API. Only users in this list should be retrieved from
Github.
* The endpoint should take these usernames and hit GitHub's public API to get basic user
information
* This API call returns to the user a list of basic information for those users including:
* name
* login
* company
* number of followers
* number of public repositories
* The average number of followers per public repository (ie. number of followers divided by the
number of public repositories)
* The returned users have been sorted alphabetically by name
* If duplicate usernames are provided, you should not hit github multiple times and the matching
user should only be returned once
* If some usernames cannot be found, this should not fail the other usernames that were requested
* Use regular http calls to hit GitHub's API, don't use any pre made GitHub net core libraries to
integrate with GitHub's API

#Constraints


