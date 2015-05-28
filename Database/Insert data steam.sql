--Insert dummy data, done/tested with SQL developer 3.2.20.10
--All the dummy data was created by me, took a few things from steam though most things came from my imagination.
--Some product names/categories came from Steam.
--User acc inserts


Insert into USER_ACCOUNT
 (
    acc_ID, name_user, passw, email_address, birth_date
 )
Values
(
    auto_inc_acc.nextval, 'Boaz Aardappel', 'dudewhereismycar', 'hipster@test.com', '11-OCT-1993'
);

Insert into USER_ACCOUNT
 (
    acc_ID, name_user, passw, email_address, birth_date, sub_type
 )
Values
(
    auto_inc_acc.nextval, 'Klaas Vaak', 'nooneknows', 'banaanemail@test.com', '15-JAN-1993', 'Steam Curator'
);

Insert into USER_ACCOUNT
 (
    acc_ID, name_user, passw, email_address, birth_date
 )
Values
(
    auto_inc_acc.nextval, 'Nikki Greene', 'Tortillas', 'friends4lyfe@spamemail.com', '20-DEC-1994'
);

Insert into USER_ACCOUNT
 (
    acc_ID, name_user, passw, email_address, birth_date
 )
 Values
 (
    auto_inc_acc.nextval, 'Rick van Duijnhoven', 'abcd', 'rvdbanaan@gmail.com', '11-OCT-1990'
 );
 
 Insert into USER_ACCOUNT
 (
    acc_ID, name_user, passw, email_address, birth_date
 )
 Values
 (
    auto_inc_acc.nextval, 'Patrick Klaassen', 'banaantjes', 'patrick@klaassen.com', '13-JAN-1992'
 );

--inserts for product category
Insert into PROD_CATEGORY
 (
    category_ID, cat_description
 )
 Values
 (
    auto_inc_cat.nextval, 'MMORPG'
 );
 
 Insert into PROD_CATEGORY
 (
    category_ID, cat_description
 )
 Values
 (
    auto_inc_cat.nextval, 'Racing'
 );
 
 Insert into PROD_CATEGORY
 (
    category_ID, cat_description
 )
 Values
 (
    auto_inc_cat.nextval, 'Fighting'
 );
 
 Insert into PROD_CATEGORY
 (
    category_ID, cat_description
 )
 Values
 (
    auto_inc_cat.nextval, 'Roundabouts and stuff'
 );
 
  --inserts for products
 Insert into PRODUCT
 (
  product_ID, category_ID, pr_name, pr_description, price
 )
 Values
 (
  auto_inc_prd.nextval, '1', 'Cities: Skylines', 'Best game ever with roads and stuff.', '50'
 );
 
 Insert into PRODUCT
 (
  product_ID, category_ID, pr_name, pr_description, price
 )
 Values
 (
  auto_inc_prd.nextval, '3', 'Team fortress 2', 'Where is HL3?', '25'
 );
 
 Insert into PRODUCT
 (
  product_ID, category_ID, pr_name, pr_description, price
 )
 Values
 (
  auto_inc_prd.nextval, '2', 'Forza', 'HL3 confirmed', '3'
 );
 
 Insert into PRODUCT
 (
  product_ID, category_ID, pr_name, pr_description, price
 )
 Values
 (
  auto_inc_prd.nextval, '1', 'Halo 2', 'Best shit for XBOX ever', '59'
 );
 
 Insert into PRODUCT
 (
  product_ID, category_ID, pr_name, pr_description, price
 )
 Values
 (
  auto_inc_prd.nextval, '1', 'Halo 3', 'Cheap knock-off', '29'
 );
 --inserts for reviews
 Insert into REVIEW
 (
    review_ID, rev_description, rating, acc_ID, product_ID
 )
 Values
 (
   auto_inc_rev.nextval, 'Terrible 0/10 would not buy', '1', '3', '1'
 );
  Insert into REVIEW
 (
    review_ID, rev_description, rating, acc_ID, product_ID
 )
 Values
 (
    auto_inc_rev.nextval, 'This game is really god damn great 10/10 would buy a beer', '5', '4', '2'
 );
  Insert into REVIEW
 (
    review_ID, rev_description, rating, acc_ID, product_ID
 )
 Values
 (
    auto_inc_rev.nextval, 'This game is awful. Seriously.', '1', '1', '1'
 );
 
 Insert into REVIEW
 (
    review_ID, rev_description, rating, acc_ID, product_ID
 )
 Values
 (
    auto_inc_rev.nextval, 'Damn so good I would date it', '5', '3', '2'
 );

 --inserts for orderlists
 Insert into ORDERLIST
 (
  orderlist_ID, amount, discount, product_ID
 )
 Values
 (
  auto_inc_orl.nextval, '3', '5', '1'
 );
 
 Insert into ORDERLIST
 (
  orderlist_ID, amount, discount, product_ID
 )
 Values
 (
  auto_inc_orl.nextval, '7', '0', '3'
 );
 
 Insert into ORDERLIST
 (
  orderlist_ID, amount, discount, product_ID
 )
 Values
 (
  auto_inc_orl.nextval, '1', '0', '3'
 );
 --insert for a broadcast
 Insert into VID_BROADCAST
 (
  acc_ID, broadcast_ID, br_description
 )
 Values
 (
  '1', auto_inc_vid.nextval, 'Streaming HL3 come see!'
 );
 
 Insert into VID_BROADCAST
 (
  acc_ID, broadcast_ID, br_description
 )
 Values
 (
  '3', auto_inc_vid.nextval, 'You fell for it did you not...'
 );
 
 --Inserts for groups
 
 Insert into STEAM_GROUP
 (
  group_ID, grp_description
 )
 Values
 (
  auto_inc_grp.nextval, 'This group is for all dutch TF2 players'
 );
 
  Insert into STEAM_GROUP
 (
  group_ID, grp_description
 )
 Values
 (
  auto_inc_grp.nextval, 'Valve release HL3 PLOX'
 );
 
 Insert into STEAM_GROUP
 (
  group_ID, grp_description
 )
 Values
 (
  auto_inc_grp.nextval, 'This group should have no members.'
 );
 
 Insert into STEAM_GROUP
 (
  group_ID, grp_description
 )
 Values
 (
  auto_inc_grp.nextval, 'Cities: skylines is the best.'
 );
 
 --This one's for two member lists, one for each group
 Insert into MEMBER_LIST
 (
  list_ID, group_ID, acc_ID
 )
 Values
 (
  auto_inc_lst.nextval, '1', '1'
 );
 
 Insert into MEMBER_LIST
 (
  list_ID, group_ID, acc_ID
 )
 Values
 (
  auto_inc_lst.nextval, '2', '3'
 );
 
 Insert into MEMBER_LIST
 (
  list_ID, group_ID, acc_ID
 )
 Values
 (
  auto_inc_lst.nextval, '1', '3'
 );
 
 Insert into FORUM
 (
  forum_ID, forum_description
 )
 Values
 (
  auto_inc_frm.nextval, 'For everyone who wants HL3'
 );
 
 Insert into FORUM
 (
  forum_ID, forum_description
 )
 Values
 (
  auto_inc_frm.nextval, 'Dutch forum'
 );
 --inserts for two workshops
 Insert into WORKSHOP
 (
  workshop_ID, product_ID
 )
 Values
 (
  auto_inc_wks.nextval, '1'
 );
 
 Insert into WORKSHOP
 (
  workshop_ID, product_ID
 )
 Values
 (
  auto_inc_wks.nextval, '2'
 );
 
 Insert into WORKSHOP
 (
  workshop_ID, product_ID
 )
 Values
 (
  auto_inc_wks.nextval, '3'
 );
 
 Insert into POST
 (
  post_ID, forum_ID, acc_ID, post_date
 )
 Values
 (
  auto_inc_pst.nextval, '1', '1', TO_DATE('11-OCT-2014 10:10:00', 'dd-mm-yyyy hh24:mi:ss')
 );
 
 Insert into POST
 (
  post_ID, forum_ID, acc_ID, post_date
 )
 Values
 (
  auto_inc_pst.nextval, '2', '3', TO_DATE('12-JAN-2014 12:55:42', 'dd-mm-yyyy hh24:mi:ss')
 );
 
 Insert into POST
 (
  post_ID, forum_ID, acc_ID, post_date
 )
 Values
 (
  auto_inc_pst.nextval, '1', '4', TO_DATE('24-JAN-2015 14:32:00', 'dd-mm-yyyy hh24:mi:ss')
 );
--Inserts for submissions
 Insert into SUBMISSION
 (
  submission_ID, sub_description
 )
 Values
 (
  auto_inc_sub.nextval, 'This is my most awesome game yet guys, really! Game is free, 50 bucks per dlc!'
 );
 
 Insert into SUBMISSION
 (
  submission_ID, sub_description
 )
 Values
 (
  auto_inc_sub.nextval, 'Yall better vote on this or cruz will be president.'
 );
 
 --Inserts for votes
 Insert into VOTE
 (
  submission_ID, acc_ID, vote
 )
 Values
 (
  '1', '1', '1'
 );
 
 Insert into VOTE
 (
  submission_ID, acc_ID, vote
 )
 Values
 (
  '1', '2', '1'
 );
 
 Insert into VOTE
 (
  submission_ID, acc_ID, vote
 )
 Values
 (
  '1', '3', '1'
 );
 
 Insert into VOTE
 (
  submission_ID, acc_ID, vote
 )
 Values
 (
  '2', '3', '0'
 );
 
 --Inserts for items
 Insert into ITEM
 (
  item_ID, item_description, image
 )
 Values
 (
  auto_inc_itm.nextval, 'Be sure to check the link! Over to the right -->', 'i.imgur.com/pJHTONC.jpg'
 );
 
 Insert into ITEM
 (
  item_ID, item_description, image
 )
 Values
 (
  auto_inc_itm.nextval, 'Seriously though, check it out. Over to the right -->', 'http://i.imgur.com/C7Gyohu.png'
 );
 
 --Inserts for item_line's
 Insert into ITEM_LINE
 (
  item_line_ID, item_ID, acc_ID
 )
 Values
 (
  auto_inc_itl.nextval, '1', '1'
 );
 
 Insert into ITEM_LINE
 (
  item_line_ID, item_ID, acc_ID
 )
 Values
 (
  auto_inc_itl.nextval, '2', '3'
 );
 
 --inserts for SALE
 Insert into SALE
 (
  sale_ID, item_line_ID, acc_ID, price
 )
 Values
 (
  auto_inc_sle.nextval, '1', '1', '69'
 );
 
 Insert into SALE
 (
  sale_ID, item_line_ID, acc_ID, price
 )
 Values
 (
  auto_inc_sle.nextval, '2', '3', '42'
 );
 
 --Inserts for user-content
 Insert into USER_CONTENT
 (
  content_ID, workshop_ID, uc_description, acc_ID
 )
 Values
 (
  auto_inc_cnt.nextval, '1', 'This user content is practically needed to play the game yo', '1'
 );
 
 Insert into USER_CONTENT
 (
  content_ID, workshop_ID, uc_description, acc_ID
 )
 Values
 (
  auto_inc_cnt.nextval, '2', '420 and stuff', '4'
 );
 
 --inserts for AC_LIBRARY
 
 Insert into AC_LIBRARY
 (
  library_ID, acc_ID, product_ID
 )
 Values
 (
  auto_inc_lib.nextval, '1', '1'
 );
 
 Insert into AC_LIBRARY
 (
  library_ID, acc_ID, product_ID
 )
 Values
 ( 
  auto_inc_lib.nextval, '1', '2'
 );
 
 Insert into AC_LIBRARY
 (
  library_ID, acc_ID, product_ID
 )
 Values
 (
  auto_inc_lib.nextval, '2', '1'
 );
 
 Insert into AC_LIBRARY
 (
  library_ID, acc_ID
 )
 Values
 (
  auto_inc_lib.nextval, '3'
 );
 
 Insert into AC_LIBRARY
 (
  library_ID, acc_ID
 )
 Values
 (
  auto_inc_lib.nextval, '2'
 );
 
 --Inserts for friendship
 Insert into FRIENDSHIP
 (
  acc_ID, acc_ID2
 )
 Values
 (
  '1', '3'
 );
 
 Insert into FRIENDSHIP
 (
  acc_ID, acc_ID2
 )
 Values
 (
  '1', '4'
 );