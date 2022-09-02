using System;

namespace InvMngr
{
	/// <summary>
	/// Summary description for Declare.
	/// </summary>
	public class Declare
	{
		public Declare()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static string CustomerNewSql = 
			"INSERT INTO Account (Account, AccountType, VATRegNo, Residence, Street, Town, PostCode, Telephone1, Telephone2, Telephone3, Email) " + 
			"VALUES (?, 'CUSTOMER', ?, ?, ?, ?, ?, ?, ?, ?, ?)";

		public static string CustomerOpenSql = 
			"SELECT Account, VATRegNo, Residence, Street, Town, PostCode, Telephone1, Telephone2, Telephone3, Email FROM Account WHERE Account = ?";

        public static string CashBankSql =
            "SELECT " +
                "FORMAT(TransA.Date, 'DD/MM/YYYY'), " +
                "FORMAT(Bank.ChequeNo, '000000'), " +
                "IIF(Details.TransID IS NULL, IIF(Bank.Amount < 0, 'BANK WITHDRAWAL', 'BANK DEPOSIT'), Details.Account), " +
                "FORMAT(Cash.Amount, '0.00'), " +
                "FORMAT(Bank.Amount, '0.00'), " +
                "TransA.TransID " +
            "FROM ((TransA " +
            "LEFT JOIN [SELECT * FROM TransB WHERE TransB.Account = 'CASH']. AS Cash ON TransA.TransID = Cash.TransID) " +
            "LEFT JOIN [SELECT * FROM TransB WHERE TransB.Account = 'BANK']. AS Bank ON TransA.TransID = Bank.TransID) " +
            "LEFT JOIN [SELECT * FROM TransB WHERE TransB.Account <>  'CASH' AND TransB.Account <> 'BANK']. AS Details ON TransA.TransID = Details.TransID " +
            "ORDER BY TransA.TransID;";

		public static string CashBankByIDSql = 
			"SELECT " + 
			"FORMAT(TransA.Date, 'DD/MM/YYYY'), " + 
			"FORMAT(Bank.ChequeNo, '000000'), " + 
			"IIF(Details.TransID IS NULL, IIF(Bank.Amount < 0, 'BANK WITHDRAWAL', 'BANK DEPOSIT'), Details.Account), " + 
			"FORMAT(Cash.Amount, '0.00'), " + 
			"FORMAT(Bank.Amount, '0.00'), " +
			"TransA.TransID " + 
			"FROM ((TransA " + 
			"LEFT JOIN [SELECT * FROM TransB WHERE TransB.Account = 'CASH']. AS Cash ON TransA.TransID = Cash.TransID) " + 
			"LEFT JOIN [SELECT * FROM TransB WHERE TransB.Account = 'BANK']. AS Bank ON TransA.TransID = Bank.TransID) " + 
			"LEFT JOIN [SELECT * FROM TransB WHERE TransB.Account <>  'CASH' AND TransB.Account <> 'BANK']. AS Details ON TransA.TransID = Details.TransID " + 
			"WHERE TransA.TransID = ?;";

		public static string BankSql = 
			"SELECT " + 
				"'', " +
				"FORMAT(TransA.Date, 'DD/MM/YYYY'), " + 
				"FORMAT(Bank.ChequeNo, '000000'), " + 
				"IIF(Details.TransID IS NULL, IIF(Bank.Amount < 0, 'BANK WITHDRAWAL', 'BANK DEPOSIT'), Details.Account), " + 
				"FORMAT(Bank.Amount, '0.00'), " +
				"FORMAT(Bank.Reconciled, 'DD/MM/YYYY'), " +
				"TransA.TransID " + 
			"FROM (TransA " + 
			"INNER JOIN [SELECT * FROM TransB WHERE TransB.Account = 'BANK']. AS Bank ON TransA.TransID = Bank.TransID) " +
			"LEFT  JOIN [SELECT * FROM TransB WHERE TransB.Account <>  'CASH' AND TransB.Account <> 'BANK']. AS Details ON TransA.TransID = Details.TransID " +
			"ORDER BY TransA.TransID;";

        public static string CategorySql =
            "SELECT " +
                "Category " +
            "FROM Category " +
            "ORDER BY Category;";

        public static string CategoryByIDSql =
            "SELECT " +
                "Category " +
            "FROM Category " +
            "WHERE Category = ?";

        public static string CategoryNewSql =
            "INSERT INTO Category (Category) " +
            "VALUES (?)";

        public static string CategoryOpenSql =
            "SELECT Category FROM Category WHERE Category = ?";

        public static string ProductSql = 
            "SELECT " +
                "Category, " + 
                "Description, " + 
                "UnitPrice " + 
            "FROM " + 
                "Product " + 
            "WHERE " + 
                "(? = '' OR Category = ?) AND " + 
                "(? = '' OR Description LIKE '%' + ? + '%')" +
            "ORDER BY Category, Description;";

	}
}
