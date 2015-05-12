using System;
using Microsoft.AspNet.Identity;

namespace BLWTraining.Models
{
    public partial class IdentityRole : IRole<int>
    {
        public IdentityRole(string name)
        {
            this._name = name;
        }

        public IdentityRole(String name, int id)
        {
            this._name = name;
            this._id = id;
        }
    }
}