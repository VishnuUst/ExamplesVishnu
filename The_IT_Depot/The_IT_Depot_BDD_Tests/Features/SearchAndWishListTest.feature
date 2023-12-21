Feature: SearchAndWishListTest

This feature is Search and Wishlist the product

@End_To_End_Search_And_Wishlist_Product
Scenario: User Search Products  and WishList the particular product
	Given User is in the ITDEPOT Homepage
	When User enter a product name '<productName>' in the Search Box
	Then User redirect to the ViewProductPage
	When User click on the particularproduct '<productNo>'
	Then User redirect to the BuyNowPage
	When User click on the WishList Button
	Then User redirect to the WishListPage
	When User Click on the wishList Close Button
	Then User view the empty listpage
Examples: 
	| productName | productNo |
	| mobile      | 1         |