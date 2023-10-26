Feature: Car API
  In order to fetch cars of a specified type
  As a consumer of the API
  I want to ensure that the API returns the correct response

  @carApi
  Scenario: Validate Get cars of a valid type
    Given the "GET" car API is available
    When I request GET <CarType>
    Then the response status code should be 200
    And the response should contain cars of type <CarType>
    And The Response Time should be less than 1000 milliseconds
    Examples:
    |CarType|
	|Saloon|
	|SUV|
	|Hatchback|

  @carApi
  Scenario: Validate Get cars by passing cars of a valid type in different cases
    Given the "GET" car API is available
    When I request GET <CarType>
    Then the response status code should be 200
    And the response should contain cars of type <CarType>
    And The Response Time should be less than 1000 milliseconds
    Examples:
    |CarType|
	|saloon|
	|suv|
	|hatchback|
    |SALOON|
	|SUV|
	|HATCHBACK|
    |SaLoon|
	|SuV|
	|hatchBack|

  @carApi
  Scenario: Validate Get cars by passing invalid car types
    Given the "GET" car API is available
    When I request GET <CarType>
    Then the response status code should be 404
    And the response should contain data for invalid <CarType>
    And The Response Time should be less than 1000 milliseconds
    Examples:
    |CarType|
	||
	|SU|
	|HATCH*|
    |*aloon*|
	|123|