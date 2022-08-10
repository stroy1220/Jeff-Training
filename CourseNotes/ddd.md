# Domain Driven Design Strategic Terms

> "Domain" just means "Where you live", "your business"

## Subdomain

Just a (supporting) domain inside the domain.

"Model" the terminology that makes sense within a particular domain.


# Solution Space

"Bounded Context"
    - "Bound" - within this, we use our own "stuff", concepts, solutions, all that stuff.
    - "Bounded" means it is sort of a "black box" to the outside world - which means that your bounded context has *autonomy* on the "how" it does stuff.



# Example Bounded Context: 

# Providing code for a Bounded Context

## "Monolith"

- One code base (one unit of deployment)
- Good Things
    - Usually fast, understandable, everything is close at hand.
    - Very clear "cause and effect"
- Stress Points
    -  Wayyy too complicated.
    - Too hard to onboard new developers. 
    - Deployments. You just can't deploy often enough to keep the business happy.
        - You try to mitigate risk by doing a lot of speculative testing.
        - "John (J.B.) Rainsberger" - "Integration tests a Scam"
    At a certain point you realize you are creating a "big ball of mud" - in other words, your monolith has different hidden bounded contexts within it.




## "Modular Monololith"

- broken up into different projects (JAR, DLLs)
- Sometimes these are run as separate services (SOA)


## Microservices

    - code that's big enough to fit in your head.
    - Assume the "how" of what you are doing is pretty wrong, almost disposable.
    - The contracts (how work gets requests, and the response) is the important part.