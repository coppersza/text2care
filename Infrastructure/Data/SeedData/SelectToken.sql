SELECT StoreRecipientUID,
    StoreUID,
    RecipientUID,
    EmployeeUID,
    DATE_FORMAT(DateRegistered, '%Y-%m-%dT%TZ') as DateRegistered
FROM text2caredb.storerecipient;

SELECT TokenUID,
    DonatorUID,
    TokenName,
    StoreUID,
    ProductId,
    StoreMealUID,
    RecipientUID,
    CostPrice,
    SalesPrice,
    DATE_FORMAT(DateCreated, '%Y-%m-%dT%TZ') as DateCreated ,
    DATE_FORMAT(DateStoreAssigned, '%Y-%m-%dT%TZ') as DateStoreAssigned ,
    DATE_FORMAT(DateAssigned, '%Y-%m-%dT%TZ') as DateAssigned ,
    DATE_FORMAT(DateCollected, '%Y-%m-%dT%TZ') as DateCollected ,
    DATE_FORMAT(DateRelease, '%Y-%m-%dT%TZ') as DateRelease ,
    DATE_FORMAT(DateExpire, '%Y-%m-%dT%TZ') as DateExpire ,
    FoodCollected,
    ImageURL,
    ShortURL,
    Valid,
    RecipientName,
    DonatorName
FROM text2caredb.token
ORDER BY DateCreated;

-- SELECT TokenUID,
--     DonatorUID,
--     TokenName,
--     StoreUID,
--     StoreMealUID,
--     RecipientUID,
--     CostPrice,
--     SalesPrice,
--     DATE_FORMAT(DateCreated, '%Y-%m-%dT%TZ') as DateCreated ,
--     DATE_FORMAT(DateStoreAssigned, '%Y-%m-%dT%TZ') as DateStoreAssigned ,
--     DATE_FORMAT(DateAssigned, '%Y-%m-%dT%TZ') as DateAssigned ,
--     DATE_FORMAT(DateCollected, '%Y-%m-%dT%TZ') as DateCollected ,
--     DATE_FORMAT(DateRelease, '%Y-%m-%dT%TZ') as DateRelease ,
--     DATE_FORMAT(DateExpire, '%Y-%m-%dT%TZ') as DateExpire ,
--     FoodCollected,
--     ImageURL,
--     ShortURL,
--     Valid,
--     RecipientName,
--     DonatorName
-- FROM text2caredb.token
-- WHERE DateCreated >= '2022-03-24T12:27:21Z'
-- ORDER BY DateCreated
