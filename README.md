# Meetup.com to Weather Forcast API

This API mashup takes in a Meetup.com group urlname, and indicates the upcoming forcasts for all events in that group (if available).

This is meant to be used for demo purposes of executing ASP.NET Core 1.0 against AWS Lambda + API Gateway for a serverless Microservice.

Before executing, you'll need to add an environment variable for your meetup.com API token:
https://secure.meetup.com/meetup_api/key/
As Environment Variable: "MeetupApiToken" = { your api key }

![Build Badge](https://spscommerce.visualstudio.com/_apis/public/build/definitions/8eb3e96a-2d99-4b77-b70f-f8a88667f6ea/138/badge)