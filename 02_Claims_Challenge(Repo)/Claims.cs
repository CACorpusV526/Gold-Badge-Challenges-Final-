using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Challenge_Repo_
{
    public enum ClaimType
    {
        Car = 1,
        Home,
        Theft
    }
    public class Claims
    {
       public int ClaimID { get; set; }
       public ClaimType TypeOfClaim { get; set; }
       public string Description { get; set; }
       public double ClaimAmount { get; set; }
       public DateTime DateOfIncident { get; set; }
       public DateTime DateOfClaim { get; set; }
       public bool IsValid { get; set; }

       public Claims() { }

       public Claims (int claimID, ClaimType claimType, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            ClaimID = claimID;
            TypeOfClaim = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }

        public DataTable ClaimsTable()
        {
            DataTable claimsTable = new DataTable();
            claimsTable.Columns.Add("Claim ID", typeof(int));
            claimsTable.Columns.Add("Type", typeof(ClaimType));
            claimsTable.Columns.Add("Description", typeof(string));
            claimsTable.Columns.Add("Amount", typeof(double));
            claimsTable.Columns.Add("Date Of Accident", typeof(DateTime));
            claimsTable.Columns.Add("Date of Claim", typeof(DateTime));
            claimsTable.Columns.Add("Is Valid", typeof(bool));

            return claimsTable;
        }
    }
}
