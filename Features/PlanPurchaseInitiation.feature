Feature: Plan Purchase Initation

@mytag
Scenario: Purchase Initiation
	Given user is on hostinger page
	And user adds hosting plan to a cart "<type>"
	And user select period "<period>"
	When user selects payment method "<payment>"
	Then displayed information is correct

Examples: 
| type | period | payment |
| 2    | 3      | 4       |