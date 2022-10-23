UPDATE text2caredb.token
SET
ProductId = 1
WHERE StoreUID = '00000000-0000-0000-0000-000000000000';

SELECT * FROM text2caredb.token
LEFT OUTER JOIN text2caredb.recipient on token.RecipientUID = recipient.RecipientUID
WHERE recipient.RecipientUID IS NULL

UPDATE text2caredb.token
SET
StoreUID = '00000000-0000-0000-0000-000000000000'
WHERE StoreUID IS NULL;

UPDATE text2caredb.token
SET
ProductId = 1
WHERE ProductId IS NULL;

UPDATE text2caredb.token
SET
ProductId = 5
WHERE StoreUID = 'A32AB0CB-40DA-4AB6-ADD9-FB20210BB308';

UPDATE text2caredb.token
SET
ProductId = 7
WHERE StoreUID = 'A4A5EDB5-DEBB-40E0-B991-B3D14A06E7F0';

UPDATE text2caredb.token
SET
ProductId = 9
WHERE StoreUID = 'EC22775F-5A67-4009-8CE8-AE628A6288D2';

UPDATE text2caredb.token
SET
DonatorUID = upper(DonatorUID);

UPDATE text2caredb.token
SET
StoreUID = upper(StoreUID);

UPDATE text2caredb.token
SET
RecipientUID = upper(RecipientUID);