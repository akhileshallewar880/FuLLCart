-- SQLite
INSERT INTO Category (Name,Description)
VALUES 
    ('Phone', 'Description for phone'),
    ('Tablet','Description for Phone A'),
    ('Smartwatch','Description for Phone B'),
    ('Laptop',  'Description for Phone C'),
    ('Camera',  'Description for Phone D')


INSERT INTO Products (Name, Price, Description, CategoryId)
VALUES 
    ('Smartphone A', 699.99, 'Description for Smartphone A', 1),
    ('Smartphone B', 799.99, 'Description for Smartphone B', 1),
    ('Smartphone C', 899.99, 'Description for Smartphone C', 1),
    ('Smartphone D', 999.99, 'Description for Smartphone D', 1),
    ('Smartphone E', 1099.99, 'Description for Smartphone E', 1);

INSERT INTO Products (Name, Price, Description, CategoryId)
VALUES 
    ('Tablet A', 299.99, 'Description for Tablet A', 2),
    ('Tablet B', 399.99, 'Description for Tablet B', 2),
    ('Tablet C', 499.99, 'Description for Tablet C', 2),
    ('Tablet D', 599.99, 'Description for Tablet D', 2),
    ('Tablet E', 699.99, 'Description for Tablet E', 2);

INSERT INTO Products (Name, Price, Description, CategoryId)
VALUES 
    ('Smartwatch A', 199.99, 'Description for Smartwatch A', 3),
    ('Smartwatch B', 299.99, 'Description for Smartwatch B', 3),
    ('Smartwatch C', 399.99, 'Description for Smartwatch C', 3),
    ('Smartwatch D', 499.99, 'Description for Smartwatch D', 3),
    ('Smartwatch E', 599.99, 'Description for Smartwatch E', 3);

INSERT INTO Products (Name, Price, Description, CategoryId)
VALUES 
    ('Laptop A', 799.99, 'Description for Laptop A', 4),
    ('Laptop B', 899.99, 'Description for Laptop B', 4),
    ('Laptop C', 999.99, 'Description for Laptop C', 4),
    ('Laptop D', 1099.99, 'Description for Laptop D', 4),
    ('Laptop E', 1199.99, 'Description for Laptop E', 4);

INSERT INTO Products (Name, Price, Description, CategoryId)
VALUES 
    ('Camera A', 299.99, 'Description for Camera A', 5),
    ('Camera B', 399.99, 'Description for Camera B', 5),
    ('Camera C', 499.99, 'Description for Camera C', 5),
    ('Camera D', 599.99, 'Description for Camera D', 5),
    ('Camera E', 699.99, 'Description for Camera E', 5);
