Feature: Critical
  As a User I want to test everyday critical path

  Scenario Outline: Check that we will not log in with wrong e-mail
    Given User opens Home page '<homePage>'
    When Home page is loaded
    And User clicks on SignIn button
    And User enters wrong email '<wrongEmail>' and submits
    Then User checks if alert message displayed

    Examples:
      | homePage                | wrongEmail           |
      | https://www.amazon.com/ | mulmebitri@vusra.com |


    
  Scenario Outline: Check registration form will not be submitted with wrong or empty fields
    Given User opens Home page '<homePage>'
    When Home page is loaded
    And User clicks on SignIn button
    And User clicks on create account button
    And User enters name '<name>'
    And User enters email '<email>'
    And User enters password '<password>'
    And User enters wrong confirmation password '<confirmationPassword>'
    And User clicks on continue button
    Then User checks that alert '<alert>' is displayed

    Examples:
      | homePage                | email                | name           | password | confirmationPassword | alert                |
      | https://www.amazon.com/ | mulmebitri@vusra.com | Test Testovich | 123456   | 123356               | Passwords must match |



  Scenario Outline: Check language
    Given User opens Home page '<homePage>'
    When Home page is loaded
    And User hovers over the flag in the header to change language
    And User chooses the '<language>'
    And User hovers over Accounts & Lists
    Then User checks that sign in button text is translated '<translated>'

    Examples:
      | homePage                | language     | translated   |
      | https://www.amazon.com/ | Español      | Identifícate |
      | https://www.amazon.com/ | Deutsch      | Anmelden     |



  Scenario Outline: Change Country
    Given User opens Home page '<homePage>'
    When Home page is loaded
    And User scrolls down and clicks change Country button
    And User chooses country '<country>'
    And User clicks to go to web-site of that country
    And User switches to new tab
    Then User checks that flag of the country '<countryFlag>' is displayed on the page

    Examples:
      | homePage                | country     | countryFlag     |
      | https://www.amazon.com/ | Canada      | icp-nav-flag-ca |
      | https://www.amazon.com/ | India       | icp-nav-flag-in |



  Scenario Outline: Check that currency change working correctly
    Given User opens Home page '<homePage>'
    When Home page is loaded
    And User scrolls down to bottom and clicks Change currency button
    And User choose another currency type '<currencyCode>'
    And User clicks button save changes
    And User clicks the All menu
    And User clicks on Computers sub-menu
    And User clicks on Computer Components sub-menu
    Then User checks that all prices contain currency type '<currencyCode>'

    Examples:
      | homePage                  | currencyCode |
      | https://www.amazon.com/   | INR          |
      | https://www.amazon.com/   | EUR          |