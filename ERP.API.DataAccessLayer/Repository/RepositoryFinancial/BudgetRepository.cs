namespace ERP.API.DataAccessLayer.Repository.RepositoryFinancial
{
    public class BudgetRepository : Repository<Budget>, IBudgetRepository
    {
        public BudgetRepository(string connectionString) : base(connectionString)
        {
        }
        // تحويل البيانات من SqlDataReader إلى Budget
        protected override Budget Map(SqlDataReader reader)
        {
            return new Budget
            {
                BudgetID = reader["BudgetID"] as int?,
                Balance = reader["Balance"] as decimal?,
                TransactionType = reader["TransactionType"].ToString(),
                Amount = reader["Amount"] as decimal?,
                Description = reader["Description"].ToString(),
                TransactionDate = reader["TransactionDate"] as DateTime?,

                // التأكد من قراءة TenantID و UserId من قاعدة البيانات (إذا كانت موجودة)
                //TenantID = reader["TenantID"] as Guid?,
                //UserId = reader["UserId"].ToString()
            };
        }

        // إضافة المعلمات اللازمة للإجراءات المخزنة Add/Update بناءً على BudgetDTO
        protected override void AddParameters(SqlCommand command, Budget budget )
        {
            if (budget != null && budget.BudgetID.HasValue && budget.BudgetID > 0)
            {
                command.Parameters.AddWithValue("@BudgetID", budget.BudgetID ?? (object)DBNull.Value);
            }
            command.Parameters.AddWithValue("@Balance", budget.Balance ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@TransactionType", budget.TransactionType ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Amount", budget.Amount ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Description", budget.Description ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@TransactionDate", budget.TransactionDate ?? (object)DBNull.Value);

        }
    }
}
