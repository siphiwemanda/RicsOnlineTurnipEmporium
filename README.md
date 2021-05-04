My website offers 3 different payment methods, PayPal, Debit Card and Bitcoin. When a customer makes a payment the MakePayment method will receive the payment type, amount, and account details. Using the sample solution provided, define a common abstraction for the payment providers and use the Factory Pattern to provide payment specific implementations so that the MakePayment method doesn’t have to know about each payment provider.
No need for proper payment integration, use the fake payment Servers in the solution.
Bonus points for test driving the implementation and following SOLID principles around dependency inversion, single responsibility, and Liskov’s substitution principle. 
