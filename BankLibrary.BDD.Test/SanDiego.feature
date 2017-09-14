Feature: SanDiego
    In order to manipulate an account

@mytag
Scenario: Deposit money and verify balance
    Given I have an account with "20" dollars in it
    When I deposit "100" dollars 
    Then My balance should be "120" dollars

Scenario: Withdraw money and verify balance
    Given I have an account with "220" dollars in it
    When I withdraw "100" dollars 
    Then My balance should be "120" dollars

Scenario Outline: Deposit and withdraw verify balance
    Given I have an account with <initial> dollars in it
    When I deposit <deposit_amount> dollars 
    When I withdraw <withdraw_amount> dollars 
    Then My balance should be <final_balance> dollars

Examples:
    | initial | deposit_amount | withdraw_amount | final_balance |
    | "100"    | "20"      | "10"       | "110"     |
    | "200"    | "0"       | "10"       | "190"    |
    | "10"      | "8"       | "6"     |  "12"   |


Scenario: Single deposit and withdraw money and verify balance
    Given I have an account with "220" dollars in it
    When I deposit "100" dollars 
    When I withdraw "100" dollars 
    Then My balance should be "220" dollars

