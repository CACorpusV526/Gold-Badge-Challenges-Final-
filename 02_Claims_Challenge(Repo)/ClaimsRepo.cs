using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Challenge_Repo_
{
    public class ClaimsRepo
    {
        private List<Claims> _listofClaims = new List<Claims>();

        public void AddClaimToList(Claims claim)
        {
            _listofClaims.Add(claim);
        }

        public List<Claims> GetClaimsList()
        {
            return _listofClaims;
        }

        public void ViewNextClaim()
        {

        }
    }
}
