CREATE TABLE transactions (
    id INT PRIMARY KEY IDENTITY(1,1),
    transaction_type NVARCHAR(50) NOT NULL CHECK (TransactionType IN ('Income','Expense','Loan','Repayment','Saving')),
    transaction_description TEXT NOT NULL,
    amount DECIMAL(10, 2) NOT NULL,
    atansaction_date DATETIME NOT NULL
);