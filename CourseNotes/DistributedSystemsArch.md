


```vb
Dim customer as Customer
set customer = new Customer()

customer.Name = "Bob Smith"
customer.Email = "bob@aol.com"
customer.CreditLimit = 5000

//customer.Save()
```

Network Saturation
- Sysadmin and open and secure TCP Ports.


```vb
Dim customer as CustomerMessage
set customer = new CustomerMessage()

customer.Name = "Bob Smith"
customer.Email = "bob@aol.com"
customer.CreditLimit = 5000

Dim externalService as CustomerService
set externalService = new CustomerService()

externalService.Save(customer)
' Continue
```