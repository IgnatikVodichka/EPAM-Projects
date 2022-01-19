Feature: Lorem

    Scenario Outline: Check that 'fish' is in the first paragraph
        Given User opens Home Page <homePage>
        When User changes language <language>
        Then User checks that first paragraph contains expected word <word>
        Examples:
            | homePage                | language | word |
            | https://www.lipsum.com/ | Русский  | рыба |