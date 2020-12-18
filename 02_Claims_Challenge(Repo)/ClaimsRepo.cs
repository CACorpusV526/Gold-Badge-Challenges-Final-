using System;
using System.Collections.Generic;
using System.Data;
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

        public Claims ViewNextClaimByID(int claimID)
        {
           foreach (Claims claim in _listofClaims)
            {
                claimID = 0;
                if (claimID < claim.ClaimID)
                {
                    //claim.ClaimID += 1;
                    return claim;
                }
            }
            return null;
        }

        public bool WorkedOnClaim(int claimID)
        {
            Claims claim = ViewNextClaimByID(claimID);
            if (claim == null)
            {
                return false;
            }
            int initialCount = _listofClaims.Count;
            _listofClaims.Remove(claim);

            if (initialCount > _listofClaims.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
