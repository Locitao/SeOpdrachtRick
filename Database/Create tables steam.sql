--done/tested with SQL developer 3.2.20.10.
drop table USER_ACCOUNT cascade constraints;
drop table PRODUCT cascade constraints;
drop table ORDERLIST cascade constraints;
drop table REVIEW cascade constraints;
drop table PROD_CATEGORY cascade constraints;
drop table VID_BROADCAST cascade constraints;
drop table STEAM_GROUP cascade constraints;
drop table MEMBER_LIST cascade constraints;
drop table POST cascade constraints;
drop table FORUM cascade constraints;
drop table SUBMISSION cascade constraints;
drop table WORKSHOP cascade constraints;
drop table VOTE cascade constraints;
drop table ITEM cascade constraints;
drop table ITEM_LINE cascade constraints;
drop table SALE cascade constraints;
drop table USER_CONTENT cascade constraints;
drop table AC_LIBRARY cascade constraints;
drop table FRIENDSHIP cascade constraints;
drop sequence auto_inc_acc;
drop sequence auto_inc_cat;
drop sequence auto_inc_rev;
drop sequence auto_inc_prd;
drop sequence auto_inc_vid;
drop sequence auto_inc_orl;
drop sequence auto_inc_grp;
drop sequence auto_inc_lst;
drop sequence auto_inc_frm;
drop sequence auto_inc_wks;
drop sequence auto_inc_pst;
drop sequence auto_inc_sub;
drop sequence auto_inc_itm;
drop sequence auto_inc_itl;
drop sequence auto_inc_sle;
drop sequence auto_inc_cnt;
drop sequence auto_inc_lib;

Create table USER_ACCOUNT
 (
  acc_ID number(10) NOT NULL, -- acc ID, primary key
  name_user varchar2(25) NOT NULL, -- name of acc holder
  passw varchar2(25) NOT NULL, --password of the acc
  steam_balance number(10) DEFAULT '0', --amount of cash on the account
  email_address varchar2(75) UNIQUE NOT NULL, --email address of acc holder
  --Avatar (moet een plaatje worden, geen idee hoe je dit aan geeft
  sub_type varchar2(15) DEFAULT 'User', --if acc is sub_type curator, this'll be steam curator
  birth_date date NOT NULL, --birthdate of user
  PRIMARY KEY (acc_ID),
  CONSTRAINT s_type CHECK (sub_type = 'User' OR sub_type = 'Steam Curator')
 );


Create table PROD_CATEGORY
  (
    category_ID number(10) NOT NULL, --primary key
    cat_description varchar2(255) DEFAULT 'Default description, change me please', --short description of category
    PRIMARY KEY (category_ID)
  );
 
Create table PRODUCT
  (
    product_ID number(10) NOT NULL, --primary key
    category_ID number(10) NOT NULL, --FK from category
    pr_name varchar2(20) NOT NULL, --name of the product
    pr_description varchar2(255) NOT NULL, --short description of the product
    price number(5) NOT NULL, --max price is 999,99, hence 5 numbers
    PRIMARY KEY (product_ID),
    FOREIGN KEY (category_ID) REFERENCES PROD_CATEGORY (category_ID)
  );

Create table REVIEW
  (
    review_ID number(10) NOT NULL, --primary key
    rev_description varchar2(3000) DEFAULT 'This is the default description, please change!', --text of the review, max 250 characters
    rating number(1) NOT NULL, --rating, minimum 1 max 5
    acc_ID number(10) NOT NULL, --FK from user_account
    product_ID number(10) NOT NULL, --FK from product, every review belongs to a product
    PRIMARY KEY (review_ID),
    FOREIGN KEY (acc_ID) REFERENCES USER_ACCOUNT (acc_ID),
    FOREIGN KEY (product_ID) REFERENCES PRODUCT (product_ID),
    CONSTRAINT uniqueCombo UNIQUE (product_ID, acc_ID),
    CONSTRAINT ratingLvl CHECK ((rating >= 1) AND (rating <= 5))
    
  );
 
Create table ORDERLIST
  (
  orderlist_ID number(10), --primary key of every order list
  amount number(2) DEFAULT '1', --amount of items that item has been bought, max 99
  discount number(2) DEFAULT '0', --discount %
  product_ID number(10), --FK from product, references product
  PRIMARY KEY (orderlist_ID),
  FOREIGN KEY (product_ID) REFERENCES PRODUCT (product_ID)
  );
  
Create table VID_BROADCAST
(
  acc_ID number(10), --FK from account, part of primary key
  broadcast_ID number(10), --primary key together with acc_ID
  br_description varchar2(250) DEFAULT 'Default description, change me please.', --short description of broadcast
  PRIMARY KEY (acc_ID, broadcast_ID),
  FOREIGN KEY (acc_ID) REFERENCES USER_ACCOUNT (acc_ID)
);

Create table STEAM_GROUP
(
  group_ID number(10), --primary key of the group
  grp_description varchar2(250) DEFAULT 'Default description, change me please.', --description of the group
  PRIMARY KEY (group_ID)
);

Create table MEMBER_LIST
(
  list_ID number(10), --primary key of the list
  group_ID number(10) NOT NULL, --FK from which group the list belongs to
  acc_ID number(10) , --FK's from acc, which members are in the list
  PRIMARY KEY (list_ID, group_ID),
  FOREIGN KEY (acc_ID) REFERENCES USER_ACCOUNT (acc_ID),
  FOREIGN KEY (group_ID) REFERENCES STEAM_GROUP (group_ID)
);

Create table FORUM
(
  forum_ID number(5), --primary key for every forum, not that many fora so PK ain't long
  forum_description varchar2(250) DEFAULT 'Default description. Change me please.', --short description of the forum
  PRIMARY KEY (forum_ID)
);

Create table WORKSHOP
(
  workshop_ID number(5), --PK of every workshop
  product_ID number(10), --FK from a product
  PRIMARY KEY (workshop_ID),
  FOREIGN KEY (product_ID) REFERENCES PRODUCT (product_ID)
);

Create table POST
(
  post_ID number(10), --primary key of every post
  forum_ID number(5), --forum to which the post belongs
  workshop_ID number(5), --FK from workshop
  acc_ID number(10), --FK from account, so you know who made the post
  post_date date NOT NULL, --date the post was posted
  PRIMARY KEY (post_ID, acc_ID),
  FOREIGN KEY (acc_ID) REFERENCES USER_ACCOUNT (acc_ID),
  FOREIGN KEY (forum_ID) REFERENCES FORUM (forum_ID),
  FOREIGN KEY (workshop_ID) REFERENCES WORKSHOP (workshop_ID),
  CONSTRAINT checkShopForum CHECK ((forum_ID != NULL) OR (workshop_ID != NULL))
);

Create table SUBMISSION
(
  submission_ID number(10), --PK to track every submission to greenlight
  sub_description varchar2(750) DEFAULT 'Default description, please change me.', --description of the submission
  PRIMARY KEY (submission_ID)
);

Create table VOTE
(
  submission_ID number(10), --FK/part of primary key, from submission
  acc_ID number(10), --FK to show/keep track of who voted
  vote number(1) NOT NULL, --To track the vote, yes/no option (0 is no, 1 is yes)
  PRIMARY KEY (submission_ID, acc_ID),
  FOREIGN KEY (submission_ID) REFERENCES SUBMISSION (submission_ID),
  FOREIGN KEY (acc_ID) REFERENCES USER_ACCOUNT (acc_ID),
  CONSTRAINT voteNR CHECK ((vote >= 0) AND (vote <= 1))
);

Create table ITEM
(
  item_ID number(10), --PK of item
  item_description varchar2(250) DEFAULT 'This is the default description, change me please.', --description of the item
  image varchar2(100), --probably gonna be a link of sorts to an image table (with an image in it)
  PRIMARY KEY (item_ID)
);

Create table ITEM_LINE
(
  item_line_ID number(10), --PK of every item_line
  item_ID number(10) NOT NULL, --FK from item
  acc_ID number(10) NOT NULL, --FK from user_account
  PRIMARY KEY (item_line_ID),
  FOREIGN KEY (item_ID) REFERENCES ITEM (item_ID),
  FOREIGN KEY (acc_ID) REFERENcES USER_ACCOUNT (acc_ID)
);

Create table SALE
(
  sale_ID number(10), --Part of PK of every sale
  item_line_ID number(10) NOT NULL, --FK from item_line
  acc_ID number(10), --FK/part of PK from acc
  price number(5) NOT NULL, --price of the sale, max 999,99
  PRIMARY KEY (sale_ID, acc_ID),
  FOREIGN KEY (item_line_ID) REFERENCES ITEM_LINE (item_line_ID),
  FOREIGN KEY (acc_ID) REFERENCES USER_ACCOUNT (acc_ID)
);

Create table USER_CONTENT
(
  content_ID number(10), --Part of PK of UC
  workshop_ID number(5), --Part of PK of UC, from workshop
  uc_description varchar2(1000) DEFAULT 'This is a default description, change me please.', --Description of UC
  acc_ID number(10) NOT NULL, --acc who made this user_content
  PRIMARY KEY (content_ID, workshop_ID),
  FOREIGN KEY (workshop_ID) REFERENCES WORKSHOP (workshop_ID),
  FOREIGN KEY (acc_ID) REFERENCES USER_ACCOUNT (acc_ID)
);

Create table AC_LIBRARY
(
  library_ID number(10), --PK of library
  acc_ID number(10), --FK from acc, because every library belongs to an acc
  product_ID number(10) DEFAULT NULL, --FK from product, could be multiple?
  PRIMARY KEY (library_ID, acc_ID),
  FOREIGN KEY (acc_ID) REFERENCES USER_ACCOUNT (acc_ID),
  FOREIGN KEY (product_ID) REFERENCES PRODUCT (product_ID)
  
);

Create table FRIENDSHIP
(
  acc_ID number(10), --first part of PK
  acc_ID2 number(10), --2nd part of PK
  PRIMARY KEY (acc_ID, acc_ID2),
  FOREIGN KEY (acc_ID) REFERENCES USER_ACCOUNT (acc_ID),
  FOREIGN KEY (acc_ID2) REFERENCES USER_ACCOUNT (acc_ID)
);

--Create a sequence for auto-increment for every table that has a number as primary key
 
Create sequence auto_inc_acc
start with 1
increment by 1
maxvalue 9999999999;

Create sequence auto_inc_cat
start with 1
increment by 1
maxvalue 9999999999;

Create sequence auto_inc_rev
start with 1
increment by 1
maxvalue 9999999999;

Create sequence auto_inc_prd
start with 1
increment by 1
maxvalue 9999999999;

Create sequence auto_inc_orl
start with 1
increment by 1
maxvalue 9999999999;

Create sequence auto_inc_vid
start with 1
increment by 1
maxvalue 9999999999;

Create sequence auto_inc_grp
start with 1
increment by 1
maxvalue 9999999999;

Create sequence auto_inc_lst
start with 1
increment by 1
maxvalue 9999999999;

Create sequence auto_inc_frm
start with 1
increment by 1
maxvalue 99999;

Create sequence auto_inc_wks
start with 1
increment by 1
maxvalue 99999;

Create sequence auto_inc_pst
start with 1
increment by 1
maxvalue 9999999999;

Create sequence auto_inc_sub
start with 1
increment by 1
maxvalue 9999999999;

Create sequence auto_inc_itm
start with 1
increment by 1
maxvalue 9999999999;

Create sequence auto_inc_itl
start with 1
increment by 1
maxvalue 9999999999;

Create sequence auto_inc_sle
start with 1
increment by 1
maxvalue 9999999999;

Create sequence auto_inc_cnt
start with 1
increment by 1
maxvalue 9999999999;

Create sequence auto_inc_lib
start with 1
increment by 1
maxvalue 9999999999;