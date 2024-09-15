namespace AvoidNullCollectionsInCSharp
{
    public class NullCases
    {
        // Problem: Returning null
        public void DisplayUserPermissions(int userId)
        {
            var permissions = GetUserPermissions(userId);

            foreach (var permission in permissions) // NullReferenceException if permissions is null
            {
                Console.WriteLine(permission);
            }
        }

        public List<string> GetUserPermissions(int userId)
        {
            if (userId <= 0)
                return null; // Problem: Can cause null reference issues in loops.

            return FetchPermissionsFromDatabase(userId);
        }





        // 2. Returning Enumerable.Empty<T>()
        public IEnumerable<Product> GetProductsInCategory(int categoryId)
        {
            if (categoryId <= 0)
                return null; // Problematic: Potential null reference exception in loops.

            return QueryProductsByCategory(categoryId);
        }

        public IEnumerable<Product> GetProductsInCategory1(int categoryId)
        {
            if (categoryId <= 0)
                return Enumerable.Empty<Product>(); // Safe: Avoids null while still indicating "no results."

            return QueryProductsByCategory(categoryId);
        }






        // 3. Returning Array.Empty<T>()

        public string[] GetUserRoles(int userId)
        {
            if (userId <= 0)
                return null; // Problematic: May cause null reference exception in string[] operations.

            return FetchUserRolesFromDatabase(userId);
        }

        public string[] GetUserRoles1(int userId)
        {
            if (userId <= 0)
                return Array.Empty<string>(); // Safe: Avoids null and simplifies empty array handling.

            return FetchUserRolesFromDatabase(userId);
        }




        // Returning new List<T>()
        public List<Order> GetOrdersByCustomerId(int customerId)
        {
            if (customerId <= 0)
                return null; // Problematic: This could lead to null reference exceptions later.

            return FetchOrdersFromDatabase(customerId);
        }

        public List<Order> GetOrdersByCustomerId1(int customerId)
        {
            if (customerId <= 0)
                return new List<Order>(); // Safe: Avoids null and returns an empty collection.

            return FetchOrdersFromDatabase(customerId);
        }





        // 4. Collection Expressions
        public List<Customer> GetCustomersByCountry(string country)
        {
            if (string.IsNullOrEmpty(country))
                return null; // Problematic: Null checks required in the calling code.

            return FetchCustomersFromDatabase(country);
        }


        public List<Customer> GetCustomersByCountry1(string country)
        {
            if (string.IsNullOrEmpty(country))
                return []; // C# 12: Clean syntax to return an empty list.

            return FetchCustomersFromDatabase(country);
        }

    }
}
