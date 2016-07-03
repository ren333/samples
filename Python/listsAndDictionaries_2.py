#!/usr/bin/python
webster = {
	"Aardvark" : "A star of a popular children's cartoon show.",
    "Baa" : "The sound a goat makes.",
    "Carpet": "Goes on the floor.",
    "Dab": "A small amount."
}

# Add your code below!
for key in webster:
    print webster[key]

# Fizz counter
def fizz_count(x):
    count = 0
    for i in x:
        if i == "fizz":
            count += 1
            
    return count
    
fizz_count(["fizz","cat","fizz"])

# Stock take
prices = {"banana": 4,"apple": 2,"orange": 1.5,"pear": 3}
stock = {"banana": 6,"apple": 0,"orange": 32,"pear": 15}

for p in prices:
    print p
    print "price: " + str(prices[p])
    print "stock: " + str(stock[p])
