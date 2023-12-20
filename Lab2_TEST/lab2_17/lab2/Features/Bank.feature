Feature: Add Customer

  Scenario: Add Customer
    Given I am on the banking website
    When I select "Bank Manager Login" option
    Then I click Add Customer
    And I enter firstname
    And I enter lastname
    And I enter post code
    When I click Add Customer
    Then I should see a success message
    Then I should close Chrome