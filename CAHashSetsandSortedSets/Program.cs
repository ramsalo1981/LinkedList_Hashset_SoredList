namespace CAHashSetsandSortedSets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var cust1 = new Customer { Name = "Issam A", Telephone = "+1 123 123 4565" };
            //var cust2 = new Customer { Name = "Issam A", Telephone = "+1 123 123 4565" };
            //Console.WriteLine(cust1 == cust2);
            //Console.WriteLine(object.ReferenceEquals(cust1, cust2));
            //Console.WriteLine(cust1.Telephone.GetHashCode());
            //Console.WriteLine(cust2.Telephone.GetHashCode());
            //Console.WriteLine(cust1.Equals(cust2));


            var customers = new List<Customer>
            {
             new Customer { Name = "Issam A", Telephone = "+1 123 123 4565" },
             new Customer { Name = "Reem S", Telephone = "+1 123 123 4566" },
             new Customer { Name = "Issam B", Telephone = "+1 123 123 4567" },
             new Customer { Name = "Abeer A", Telephone = "+1 123 123 4568" },
             new Customer { Name = "Salem D", Telephone = "+1 123 123 4569" }

            };

            Console.WriteLine("Hashset");
            Console.WriteLine("-------");

            var custhashset1 = new HashSet<Customer>(customers);
            //Add new element but same in he list <=> will not add
            custhashset1.Add(new Customer { Name = "Issam A", Telephone = "+1 123 123 4565" });// not added
            custhashset1.Add(new Customer { Name = "Iss", Telephone = "+1 123 123 4565" });//not added <=> same telefone
            custhashset1.Add(new Customer { Name = "Issam A", Telephone = "+1 123 123 0000" });//added <=> not same telefone
            custhashset1.Add(new Customer { Name = "Iss A", Telephone = "+1 123 123 0010" });//added <=> not same telefone

            foreach (var customer in custhashset1)
            {
                Console.WriteLine(customer);
            }
            Console.WriteLine("---------------------------------");

            var customers2 = new List<Customer>
            {
             new Customer { Name = "Essam A", Telephone = "+1 123 123 4533" },
             new Customer { Name = "Rim S", Telephone = "+1 123 123 4554" }

            };
            var custhashset2 = new HashSet<Customer>(customers2);
            custhashset1.UnionWith(custhashset2);

            foreach (var customer in custhashset1)
            {
                Console.WriteLine(customer);
            }
            Console.WriteLine("---------------------------------");

            Console.WriteLine("SortedSet");
            Console.WriteLine("-------");

            var customerSortedSet = new SortedSet<Customer>(customers);

            foreach (var customer in customerSortedSet)
            {
                Console.WriteLine(customer);
            }
            Console.WriteLine("------------------------------");
            customerSortedSet.Add(new Customer { Name = "Baker S", Telephone = "+1 123 123 3354" });
            foreach (var customer in customerSortedSet)
            {
                Console.WriteLine(customer);
            }
            Console.ReadKey();
        }
    }
    class Customer : IComparable<Customer>
    {
        public string Name { get; set; }
        public string Telephone { get; set; }

        

        public override bool Equals(object? obj)
        {
            var customer = obj as Customer;
            if (customer is null) return false;
            return this.Telephone.Equals(customer.Telephone);
        }
        public override int GetHashCode()
        {
            var hash = 17;
            hash = hash * 23 + this.Telephone.GetHashCode();
            return hash;
        }

        public int CompareTo(Customer? other)
        {
            if (object.ReferenceEquals(this, other))
                return 0;
            if (other is null) return -1;

            return this.Name.CompareTo(other.Name);

        }
        public override string ToString()
        {
            return $"{Name} ({Telephone})";
        }

    }
}