Check out https://confluence.mediware.com/pages/viewpage.action?pageId=46990487 for the most details

## Hello World Teammates

* Johnny Serrano
* Sayali Mohadikar
* Deepika Dasari
* Ray Yelle

# HelloWorld.SimpleWebsiteTechnologies/ Tools used :
Circle CI,Docker, Selenium, C#- DotNet Core, Nunit

# Running in Circle CI is recommended : To run in CircleCI
1. We do have two repositories one for Hackathon Submission and another for the Circle CI integration (since circle ci needed to read from a repository).  The code is only modified slightly (something is commented out in the circle ci version).

2. Simply go here to see the build result: https://circleci.com/gh/mediwareinc/Hackathon.HelloWorld/7
This demonstrates the entire flow where we can create a service in memory and immediately attach to it and call tests on it.
You can check the logs and see the atlas service runs as well as the unit test and that unit test passes - this unit test is doing a UI call to a website, clicking a link, and verifying that the page loads
3. If you want it to run again, modify something in the repo so the build is triggered: 
https://github.com/mediwareinc/Hackathon.HelloWorld
4. What is commented out? 
The process to start selenium since in circle ci we have a docker image which launches selenium
comment out: https://github.com/mediwareinc/Hackathon.HelloWorld/blob/c102df7389674394ac35091d6835890b1d465036/Tests/HelloWorld.SimpleWebsite.Tests/Factory/UiTestServerFactory.cs#L34
docker image: https://github.com/mediwareinc/Hackathon.HelloWorld/blob/c102df7389674394ac35091d6835890b1d465036/.circleci/config.yml#L15
