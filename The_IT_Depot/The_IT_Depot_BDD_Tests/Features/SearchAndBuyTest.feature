Feature: SearchAndBuyTest

This Feature is for searching the products and buy a particular product.

@End_To_End_Search_And_Buy_Product
Scenario: User Search Products  and Buy the particular product
	Given User is in the ITDEPOT Homepage
	When User enter a product name '<productName>' in the Search Box
	Then User redirect to the ViewProductPage
	When User Click on the sortBy box and click on the category '<categoryname>'
	And User Click on subCatagories '<position>'
	When User click on the particularproduct '<productNo>'
	Then User redirect to the BuyNowPage
	When User click on the BuyNow Button
	Then User redirect to the ShoppingCartPage
	When User click on the Quatity and enter quantity '<qty>'
	And User click on the Checkout Button
	Then User Redirect to the checkoutpage
	When User Type Name in the input box '<Name>'
	And  User Type Email in the input box '<Email>'
	And User Type Mobile Number in the input box '<Mobile>'
	And User Type Password in the input box '<password>'
	And User Type Confirm Password in the input box '<confirmPassword>'
	And User click on the signup button
	Then User Redirect to the checkout page
Examples: 
	| productName | categoryname | position | productNo | qty | Name | Email             | Mobile     | password | confirmPassword |
	| mobile      | price_desc   | 5        | 1         | 2   | Mark | Mark223@gmail.com | 9897654534 | Mark98*  | Mark98*         |

