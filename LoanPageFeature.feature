Feature: Verify_ShortTearmLoan_WebPage
	Auden loans Page Tests for Slider and Negative and Positive Repayment day Selection

Background:
	Given I open and navigate to the Auden Short Term Loan Web Site

@smoke - The min and max amounts of Loan on slider. 
Scenario: Test that the Loans Slider remains within the Min / Max Boundaries
	Given The slider element is present
	When Slider is set to Min Position
	When Slider is set to Max Position
	Then Close the Auden Short Term Loan Web Site

@smoke - The selected slider amount is Loan amount.
Scenario: Test that the Amount displayed on Loans Slider matches the current set value
	Given Slider is set to Min Position value will be £200
	When Slider is set to Quarter Position value will be £280
	When Slider is set to Half Position value will be £350
	When Slider is set to Three Quarters Position value will be £420
	When Slider is set to Max Position value will be £500
	Then Close down the Auden Short Term Loan Web Site

@smoke - The weekend can’t be a repayment day, so it should show First Repayment Day Option as Friday.
Scenario: Test that the weekend can’t be a repayment day, so it should show First Repayment Day Option as Friday. For example, if user select repayment day as 6th Sept, which is Sunday, it will push you back and show first repayment day as Tuesday 6th Oct 2020.
	Given I click the Repayment Day Button 1 the first Repayment Negative Test value will be Wednesday 30 Oct 2020 or Thursday 1 Oct 2020
	When I click the Repayment Day Button 1 the first Repayment Positive Test value will be Thursday 1 Oct 2020 or Friday 30 Oct 2020
	When I click the Repayment Day Button 5 the first Repayment Negative Testvalue will be Wednesday 30 Sep 2020
	When I click the Repayment Day Button 5 the first Repayment Positive Test value will be Monday 5 Oct 2020
	When I click the Repayment Day Button 6 the first Repayment Negative Testvalue will be Wednesday 30 Sep 2020
	When I click the Repayment Day Button 6 the first Repayment Positive Test value will be Tuesday 6 Oct 2020
	When I click the Repayment Day Button 18 the first Repayment Negative Testvalue will be Wednesday 30 Sep 2020
	When I click the Repayment Day Button 18 the first Repayment Positive Test value will be Friday 16 Oct 2020
	When I click the Repayment Day Button 26 the first Repayment Negative Testvalue will be Wednesday 30 Sep 2020 or Monday 01 Oct 2020
	When I click the Repayment Day Button 26 the first Repayment Positive Test value will be Friday 25 Sep 2020 or Monday 26 Oct 2020
	When I click the Repayment Day Button 27 the first Repayment Negative Test value will be Wednesday 30 Sep 2020 or Monday 01 Oct 2020
	When I click the Repayment Day Button 27 the first Repayment Positive Test value will be Friday 25 Sep 2020 or Tuesday 27 Oct 2020
	When I click the Repayment Day Button Last Working Day the first Repayment Negative Test value will be Monday 01 Oct 2020 or Monday 01 Oct 2020
	When I click the Repayment Day Button Last Working Day the first Repayment Positive Test value will be Wednesday 30 Sep 2020 or Friday 30 Oct 2020
	Then Close the Auden Short Term Loan Web Site