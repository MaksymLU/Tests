Feature: Deposit

@deposit
Scenario Outline: Customer deposit with valid data
    Given Customer with details:<Name>,<Amount>
    When I log in as a "Customer"
    And I navigate to "Deposit" page
    And fill the data
    And I submit the form
    Then Message should be Deposit Successful

    Examples: 
    | Name             | Amount |
    | Harry Potter     | 20     |
    | Ron Weasly       | 30     |
    | Hermoine Granger | 154    |
    | Albus Dumbledore | 123    |
    | Albus Dumbledore | 14     |

@depositError
Scenario Outline: Customer deposit with wrong data
    Given Customer with details:<Name>,<Amount>
    When I log in as a "Customer"
    And I navigate to "Deposit" page
    And fill the data
    And I submit the form
    Then Message shouldn't be displayed
    
    Examples: 
    | Name             | Amount |
    | Albus Dumbledore |        |
    | Harry Potter     | 0      |
    | Ron Weasly       | -1     |
    | Hermoine Granger |        |
    | Hermoine Granger | -4     |
    | Albus Dumbledore | -123   |
    | Albus Dumbledore | -140   |
    | Ron Weasly       |        |

