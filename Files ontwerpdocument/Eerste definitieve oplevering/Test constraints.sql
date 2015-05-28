--Done/tested with SQL developer 3.2.20.10
--This script tests the constraints which I've put in place in the Create script.
--For every constraint I'll explain why it shouldn't work.
--Rollbacks were doing weird, if you want to run this script multiple times,
--Be sure to run Create tables first, every time before you do run this one.

--User account constraint: this shouldn't work since sub_type isn't 'User' or 'Steam Curator'

Insert into USER_ACCOUNT
(
  acc_ID, name_user, passw, email_address, sub_type, birth_date
)
Values
(
  auto_inc_acc.nextval, 'Jan', 'banaan', 'test@test.com', 'Should fail', '10-OCT-1994'
);

--Next one should work

Insert into USER_ACCOUNT
(
  acc_ID, name_user, passw, email_address, sub_type, birth_date
)
Values
(
  auto_inc_acc.nextval, 'Jan', 'banaan', 'banaan@test.com', 'Steam Curator', '10-OCT-1994'
  

);

--Yup, one row inserted!
Select * FROM USER_ACCOUNT;
--Next one should fail, since we have a unique constraint on email_address

Insert into USER_ACCOUNT
(
  acc_ID, name_user, passw, email_address, birth_date
)
Values
(
  auto_inc_acc.nextval, 'Jan', 'banaan', 'banaan@test.com', '12-JAN-1994'
);

--Insert a product to test some constraints with and a category
Insert into PROD_CATEGORY
(
  category_ID --only category ID, so you can see the default works!
)
Values
(
  auto_inc_cat.nextval
);

Insert into PRODUCT
(
  product_ID, category_ID, pr_name, pr_description, price
)
Values
(
  auto_inc_prd.nextval, '1', 'Awesome name', 'awesome test', '59'
);

--Below we're gonna add two reviews, second one should fail because of the constraint
--Which stops a user from reviewing one product multiple times
Insert into REVIEW
(
 review_ID, rev_description, rating, acc_ID, product_ID
)
Values
(
  auto_inc_rev.nextval, 'test', '3', '2', '1'
);

Insert into REVIEW
(
 review_ID, rev_description, rating, acc_ID, product_ID
)
Values
(
  auto_inc_rev.nextval, 'test', '4', '2', '1'
);

--Should only be one review
SELECT * FROM REVIEW;

--Now check if the rating constraint works on REVIEW

Insert into REVIEW
(
 review_ID, rev_description, rating, acc_ID, product_ID
)
Values
(
  auto_inc_rev.nextval, 'test', '7', '3', '1'
);

--Still should only be one record, because 7 isn't between 1 and 5
SELECT * FROM REVIEW;

--The rest of the constraints are pretty much identical to what's been shown above
--except for the table's/column names etc.