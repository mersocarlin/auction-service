# auction-service

Auction backend implementation.

## Stack used

1. C# and ASP.NET WebApi
2. SQL Server and EntityFramework
3. Repository and Service Pattern
4. Dependency Injection
5. NUnit and Moq for Unit Testing

## Sample Routes

### [GET]

#### Fetch all Buyers

`api/v1/buyer`

```JSON
[
  {
    "id": 1,
    "name": "Donald Duck"
  },
  {
    "id": 2,
    "name": "Uncle Scrooge"
  }
]
```

#### Fetch all Auctions

`/api/v1/auction`

```JSON
[
  {
    "id": 1,
    "itemId": 1,
    "bidStep": 100,
    "isFinished": false,
    "history": [
      {
        "id": 59,
        "auctionId": 1,
        "buyerId": 1,
        "createdAt": "2016-02-21T07:35:21.807",
        "auction": null,
        "buyer": {
          "id": 1,
          "name": "Donald Duck"
        }
      },
      ...
    ],
    "item": {
      "id": 1,
      "description": "The ASUS ZenWatch, which went on sale in November, recently won an iF Product Design Award - congratulations ASUS",
      "name": "ASUS ZenWatch",
      "picture": "http://www.mersocarlin.com/auction-images/watch.png",
      "startingPrice": 1500
    },
    "highestBid": 2000,
    "highestBidder": 1
  },
  ...
]
```

#### Fetch Auction by Id
`api/v1/auction/{auctionId}`


### [POST]

#### Place Bid

`api/v1/auction/bid/{auctionId}/{buyerId}`
