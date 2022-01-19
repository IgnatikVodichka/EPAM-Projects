Feature: Smoke
  As a user I want to test main general functionality
  So that I can be sure that the main functions I need are on the website and operate correctly

  Scenario Outline: Check visibility of main elements on the home page
    Given User opens Home page '<homePage>'
    When Home page is loaded
    Then User checks header is visible
    And User checks search field is visible
    And User checks main widgets are visible
    And User checks cart is visible
    And User checks footer is visible

    Examples:
      | homePage                |
      | https://www.amazon.com/ |



  Scenario Outline: Check that search result is in current URL
    Given User opens Home page '<homePage>'
    When Home page is loaded
    And User checks search field is visible
    And User enters keyword '<keyword>' into search input
    And User presses ENTER button to search
    Then User checks that search keyword '<keyword>' is in current URL

    Examples:
      | homePage                | keyword  |
      | https://www.amazon.com/ | iphone   |



  Scenario Outline: Check that search results are displayed on the page correctly
    Given User opens Home page '<homePage>'
    When Home page is loaded
    And User checks search field is visible
    And User enters keyword '<keyword>' into search input
    And User presses ENTER button to search
    Then User checks that search results contain correct products names from keyword '<keyword>'
    And User checks that search results contain correct amount '<expectedAmount>' of products

    Examples:
      | homePage                | keyword  | expectedAmount |
      | https://www.amazon.com/ | MacBook  |       16       |



  Scenario Outline: Check that shipping location is correct
    Given User opens Home page '<homePage>'
    When Home page is loaded
    And User checks location '<location>' is correct
    And User enters keyword '<keyword>' into search input
    And User presses ENTER button to search
    Then User checks that first item has correct shipping '<shipping>' location

    Examples:
      | homePage                | location  | keyword     | shipping         |
      | https://www.amazon.com/ | Ukraine   | weed wacker | Ships to Ukraine |



  Scenario Outline: Check that item added to cart correctly
    Given User opens Home page '<homePage>'
    When Home page is loaded
    And User clicks the All menu
    And User clicks on electronics sub-menu
    And User clicks on headphones sub-menu
    And User chooses TOZO brand checkbox for filtering
    And User clicks on first item after filtering
    And User clicks add to cart button
    Then User checks items count '<cartItemsCount>' in the cart

    Examples:
      | homePage                | cartItemsCount |
      | https://www.amazon.com/ |        1       |