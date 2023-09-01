CREATE TABLE Medicine(
m_id int primary key identity(1,1),
m_name varchar(50) not null,
m_price float ,
m_category varchar(50));

CREATE TABLE Prescription(
p_id int primary key identity(1,1),
cust_id int,
ph_id int,
p_date date);
CREATE TABLE Customer(
c_id int primary key identity(1,1),
c_name varchar(50) not null,
c_email varchar(50) ,
c_phone varchar(11));
CREATE TABLE Inventory(
in_id int primary key identity(1,1),
in_name varchar(50) not null,
in_location varchar(50) ,
);
CREATE TABLE Ph_Medicine(
ph_id int ,
m_id int,
primary key(ph_id,m_id)
);
CREATE TABLE Ph_Inventory(
ph_id int ,
inv_id int,
primary key(ph_id,inv_id)
);
CREATE TABLE Inv_Medicine(
inv_id int ,
m_id int,
primary key(inv_id,m_id)
);
--add data to pharmacist
insert into Pharmacist(ph_name,ph_salary,ph_email)
    values('mohamed ahmed',3000,'mohamed@gmail.com');
insert into Pharmacist(ph_name,ph_salary,ph_email)
	values('john doe', 3000, 'john.doe@gmail.com');
insert into Pharmacist(ph_name,ph_salary,ph_email)
	values('sara smith', 3000, 'sara.smith@gmail.com');
insert into Pharmacist(ph_name,ph_salary,ph_email)
    values('ahmed ali', 3000, 'ahmed.ali@gmail.com');
insert into Pharmacist(ph_name,ph_salary,ph_email)
	values('emily jones', 3000, 'emily.jones@gmail.com');
insert into Pharmacist(ph_name,ph_salary,ph_email)
	values('alexander wang', 3000, 'alexander.wang@gmail.com');
insert into Pharmacist(ph_name,ph_salary,ph_email)
	values('lisa parker', 3000, 'lisa.parker@gmail.com');
insert into Pharmacist(ph_name,ph_salary,ph_email)
	values('david wilson', 3000, 'david.wilson@gmail.com');
insert into Pharmacist(ph_name,ph_salary,ph_email)
	values('olivia brown', 3000, 'olivia.brown@gmail.com');
--add medicine data 
insert into Medicine(m_name,m_price,m_category)
	values('metformeen', 26, 'diabetes');
insert into Medicine(m_name,m_price,m_category)
	values('petadeen', 48, 'children_cold');
INSERT INTO Medicine(m_name, m_price, m_category) VALUES('ibuprofen', 10, 'pain_relief');
INSERT INTO Medicine(m_name, m_price, m_category) VALUES('amoxicillin', 15, 'antibiotics');
INSERT INTO Medicine(m_name, m_price, m_category) VALUES('loratadine', 8, 'allergy');
INSERT INTO Medicine(m_name, m_price, m_category) VALUES('omeprazole', 20, 'acid_reflux');
INSERT INTO Medicine(m_name, m_price, m_category) VALUES('paracetamol', 5, 'fever');
INSERT INTO Medicine(m_name, m_price, m_category) VALUES('vitamin C', 12, 'supplements');
insert into Pharmacist(ph_name,ph_salary,ph_email)
	values('olivia brown', 3000, 'olivia.brown@gmail.com');
--add Inventory data
insert into Inventory(in_name,in_location)
	values('Abaseery_branch', 'benisuef');
insert into Inventory(in_name,in_location)
	values('inv2_branch', 'Cairo');
INSERT INTO Inventory(in_name, in_location) VALUES('Alexandria Medical Center - Alexandria', 'Alexandria');
INSERT INTO Inventory(in_name, in_location) VALUES('Giza Pharmacy - Giza', 'Giza');
--add customer data
insert into Customer(c_name,c_email,c_phone)
	values('Ahmed Samed','ahmed2@gmail.com','012345476');
 INSERT INTO Customer(c_name, c_email, c_phone) VALUES('Ahmed Samed', 'ahmed2@gmail.com', '012345476');
 INSERT INTO Customer(c_name, c_email, c_phone) VALUES('Sara Johnson', 'sara.johnson@gmail.com', '987654321');
 INSERT INTO Customer(c_name, c_email, c_phone) VALUES('Mohamed Ali', 'mohamed.ali@gmail.com', '456789012');
 INSERT INTO Customer(c_name, c_email, c_phone) VALUES('Emily Smith', 'emily.smith@gmail.com', '321098765');
 INSERT INTO Customer(c_name, c_email, c_phone) VALUES('Alex Anderson', 'alex.anderson@gmail.com', '654321098');
 INSERT INTO Customer(c_name, c_email, c_phone) VALUES('Linda Wilson', 'linda.wilson@gmail.com', '789012345');
 INSERT INTO Customer(c_name, c_email, c_phone) VALUES('David Brown', 'david.brown@gmail.com', '210987654');
 INSERT INTO Customer(c_name, c_email, c_phone) VALUES('Olivia Davis', 'olivia.davis@gmail.com', '543210987');
 INSERT INTO Customer(c_name, c_email, c_phone) VALUES('Jacob Taylor', 'jacob.taylor@gmail.com', '876543210');
 INSERT INTO Customer(c_name, c_email, c_phone) VALUES('Sophia Thompson', 'sophia.thompson@gmail.com', '109876543');
 INSERT INTO Customer(c_name, c_email, c_phone) VALUES('William Clark', 'william.clark@gmail.com', '432109876');
 INSERT INTO Customer(c_name, c_email, c_phone) VALUES('Emma Turner', 'emma.turner@gmail.com', '765432109');
 INSERT INTO Customer(c_name, c_email, c_phone) VALUES('Michael White', 'michael.white@gmail.com', '098765432');
 INSERT INTO Customer(c_name, c_email, c_phone) VALUES('Mia Martinez', 'mia.martinez@gmail.com', '321098765');
 INSERT INTO Customer(c_name, c_email, c_phone) VALUES('James Lee', 'james.lee@gmail.com', '654321098');
 --add Prescription data
INSERT INTO Prescription(p_date, cust_id, ph_id) VALUES('2022-02-02', 1, 1);
INSERT INTO Prescription(p_date, cust_id, ph_id) VALUES('2022-02-03', 2, 1);
INSERT INTO Prescription(p_date, cust_id, ph_id) VALUES('2022-02-04', 3, 2);
INSERT INTO Prescription(p_date, cust_id, ph_id) VALUES('2022-02-05', 4, 2);
INSERT INTO Prescription(p_date, cust_id, ph_id) VALUES('2022-02-06', 5, 3);
INSERT INTO Prescription(p_date, cust_id, ph_id) VALUES('2022-02-07', 6, 3);
INSERT INTO Prescription(p_date, cust_id, ph_id) VALUES('2022-02-08', 7, 4);
INSERT INTO Prescription(p_date, cust_id, ph_id) VALUES('2022-02-09', 8, 4);
INSERT INTO Prescription(p_date, cust_id, ph_id) VALUES('2022-02-10', 9, 5);
INSERT INTO Prescription(p_date, cust_id, ph_id) VALUES('2022-02-11', 10, 5);
INSERT INTO Prescription(p_date, cust_id, ph_id) VALUES('2022-02-12', 11, 6);
INSERT INTO Prescription(p_date, cust_id, ph_id) VALUES('2022-02-13', 12, 6);
INSERT INTO Prescription(p_date, cust_id, ph_id) VALUES('2022-02-14', 13, 7);
INSERT INTO Prescription(p_date, cust_id, ph_id) VALUES('2022-02-15', 14, 7);
INSERT INTO Prescription(p_date, cust_id, ph_id) VALUES('2022-02-16', 15, 8);
--add Ph_Medicine data
INSERT INTO Ph_Medicine(ph_id, m_id) VALUES(1, 2);
INSERT INTO Ph_Medicine(ph_id, m_id) VALUES(1, 3);
INSERT INTO Ph_Medicine(ph_id, m_id) VALUES(1, 4);
INSERT INTO Ph_Medicine(ph_id, m_id) VALUES(1, 5);
INSERT INTO Ph_Medicine(ph_id, m_id) VALUES(2, 3);
INSERT INTO Ph_Medicine(ph_id, m_id) VALUES(2, 6);
INSERT INTO Ph_Medicine(ph_id, m_id) VALUES(2, 7);
INSERT INTO Ph_Medicine(ph_id, m_id) VALUES(3, 2);
INSERT INTO Ph_Medicine(ph_id, m_id) VALUES(3, 4);
INSERT INTO Ph_Medicine(ph_id, m_id) VALUES(3, 8);
INSERT INTO Ph_Medicine(ph_id, m_id) VALUES(4, 1);
INSERT INTO Ph_Medicine(ph_id, m_id) VALUES(4, 3);
INSERT INTO Ph_Medicine(ph_id, m_id) VALUES(4, 5);
INSERT INTO Ph_Medicine(ph_id, m_id) VALUES(5, 2);
INSERT INTO Ph_Medicine(ph_id, m_id) VALUES(5, 6);
INSERT INTO Ph_Medicine(ph_id, m_id) VALUES(5, 9);
INSERT INTO Ph_Medicine(ph_id, m_id) VALUES(6, 1);
INSERT INTO Ph_Medicine(ph_id, m_id) VALUES(6, 4);
INSERT INTO Ph_Medicine(ph_id, m_id) VALUES(6, 7);
INSERT INTO Ph_Medicine(ph_id, m_id) VALUES(6, 8);
INSERT INTO Ph_Inventory(ph_id, inv_id) VALUES(1,4);
--add Ph_Inventory data
INSERT INTO Ph_Inventory(ph_id, inv_id) VALUES(1, 4);
INSERT INTO Ph_Inventory(ph_id, inv_id) VALUES(1, 2);
INSERT INTO Ph_Inventory(ph_id, inv_id) VALUES(2, 3);
INSERT INTO Ph_Inventory(ph_id, inv_id) VALUES(3, 1);
INSERT INTO Ph_Inventory(ph_id, inv_id) VALUES(3, 2);
INSERT INTO Ph_Inventory(ph_id, inv_id) VALUES(4, 3);
--add Inv_Medicine data
INSERT INTO Inv_Medicine(inv_id, m_id) VALUES(1, 4);
INSERT INTO Inv_Medicine(inv_id, m_id) VALUES(1, 6);
INSERT INTO Inv_Medicine(inv_id, m_id) VALUES(1, 8);
INSERT INTO Inv_Medicine(inv_id, m_id) VALUES(2, 2);
INSERT INTO Inv_Medicine(inv_id, m_id) VALUES(2, 5);
INSERT INTO Inv_Medicine(inv_id, m_id) VALUES(2, 7);
INSERT INTO Inv_Medicine(inv_id, m_id) VALUES(3, 1);
INSERT INTO Inv_Medicine(inv_id, m_id) VALUES(3, 3);
INSERT INTO Inv_Medicine(inv_id, m_id) VALUES(3, 4);
INSERT INTO Inv_Medicine(inv_id, m_id) VALUES(4, 2);
INSERT INTO Inv_Medicine(inv_id, m_id) VALUES(4, 4);
INSERT INTO Inv_Medicine(inv_id, m_id) VALUES(4, 6);
INSERT INTO Inv_Medicine(inv_id, m_id) VALUES(1, 3);
INSERT INTO Inv_Medicine(inv_id, m_id) VALUES(4, 5);
INSERT INTO Inv_Medicine(inv_id, m_id) VALUES(1, 2);
INSERT INTO Inv_Medicine(inv_id, m_id) VALUES(3, 1);
INSERT INTO Inv_Medicine(inv_id, m_id) VALUES(3, 7);
INSERT INTO Inv_Medicine(inv_id, m_id) VALUES(2, 3);
INSERT INTO Inv_Medicine(inv_id, m_id) VALUES(3, 2);
INSERT INTO Inv_Medicine(inv_id, m_id) VALUES(2, 1);
