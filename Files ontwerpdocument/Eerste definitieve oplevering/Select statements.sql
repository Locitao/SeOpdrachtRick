--done/tested with SQL developer 3.2.20.10
--Shows users names if they are currently selling an item, and which item it is.

--Before you run this script, be sure to run Create tables steam and Insert data steam
--first, to ensure it works correctly.

SELECT uc.name_user, i.item_description, i.image
FROM USER_ACCOUNT uc, SALE s, ITEM_LINE il, ITEM i
WHERE uc.acc_ID = s.acc_ID
AND s.item_line_ID = il.item_line_ID
AND il.item_ID = i.item_ID;

--Show all groups, and which users belong to which groups (also show empty groups)
SELECT uc.name_user, g.group_ID, g.grp_description
FROM MEMBER_LIST ml RIGHT JOIN USER_ACCOUNT uc ON ml.acc_ID = uc.acc_ID 
RIGHT JOIN STEAM_GROUP g ON ml.group_ID = g.group_ID;

--Check which products Steam Curators own
SELECT uc.name_user AS Name, pr.pr_name AS Product_name
FROM USER_ACCOUNT uc, AC_LIBRARY l, PRODUCT pr
WHERE uc.sub_type = 'Steam Curator'
AND uc.acc_ID = l.acc_ID
AND l.product_ID = pr.product_ID;

--Show all workshops, and for those that have user content, show content_ID, description, and name of user
SELECT ws.workshop_ID, pr.pr_name, uc.content_ID, uc.uc_description, acc.name_user
FROM WORKSHOP ws LEFT JOIN USER_CONTENT uc ON ws.workshop_ID = uc.workshop_ID
LEFT JOIN USER_ACCOUNT acc ON uc.acc_ID = acc.acc_ID
JOIN PRODUCT pr ON ws.product_ID = pr.product_ID;

--Show submissions that have => 3 'good' or '1' votes.
--To determine which products on Steam Greenlight
--Will actually come to steam.
SELECT sub.submission_ID, sub.sub_description AS Description
FROM SUBMISSION sub, VOTE v
WHERE sub.submission_ID = v.submission_ID
AND v.vote = '1'
GROUP BY sub.submission_ID, sub.sub_description
HAVING COUNT(v.vote) >= 3;

--Make a list of products that have 2 or more reviews of '5'
--This could become part of an algorithm or something
--To determine popular/well-reviewed products
SELECT r.rating, r.rev_description AS Description, p.pr_name AS Product
FROM REVIEW R, PRODUCT p
WHERE r.product_ID = p.product_ID
AND r.rating = '5'
GROUP BY r.rating, r.rev_description, p.pr_name
HAVING COUNT (r.rating) >= 1;

--Show a list of products that are in no one's library (no one has bought them yet)
--This could be handy when steam would clean up their assortment of products
--To show which they could remove without angering some folks
SELECT pr.pr_name AS Product, pr.pr_description AS Description
FROM PRODUCT pr, AC_LIBRARY al
WHERE pr.product_ID NOT IN (SELECT product_ID
                     FROM AC_LIBRARY
                     WHERE product_ID >= 1)
GROUP BY pr.pr_name, pr.pr_description;

--Lately, advertising bots have been active on steam
--To weed these out, we're gonna check for accounts that own no products AND
--have no friendships.

SELECT ac.acc_ID, ac.name_user
FROM USER_ACCOUNT ac, FRIENDSHIP f, AC_LIBRARY
WHERE ac.acc_ID NOT IN (SELECT acc_ID
                        FROM FRIENDSHIP)
AND ac.acc_ID IN (SELECT acc_ID
                  FROM AC_LIBRARY
                  WHERE product_ID IS NULL)
GROUP BY ac.acc_ID, ac.name_user;

--Below a pretty simple statement, but because it's popular
--I decided to include it anyway.
--Ordering products by ascending price (lowest to highest)

SELECT pr.pr_name, pr.price
FROM PRODUCT pr
ORDER BY pr.price ASC;